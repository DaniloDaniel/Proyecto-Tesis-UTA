using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//Referencias EmguCV
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
using Emgu.CV.ML;


namespace Sistema_Reconocimiento_Facial
{
    public partial class Form1 : Form
    {
        List<Mat> dataTrain;
        Matrix<float> matrizMat;

        Matrix<int> labelTrain;

        HOGDescriptor desHog;
        List<List<float>> dataTrainHOG;

        Mat dataTrainMat;
        int descriptorSize;
        
        CascadeClassifier faceDetector;
        Mat imgMat;
        SVM model;

        public Form1()
        {
            InitializeComponent();
            loadDatatraining();
            hog();
            calculateDescriptorsHOG();

            dataTrainMat = new Mat(new Size((int)dataTrainHOG[0].Count(), dataTrainHOG.Count()), DepthType.Cv32F, 1); //	Mat(Size, DepthType, Int32)

            convertVectorToMatrix();
            try
            {
                //Creación del SVM
                //Definición de parámetros
                model = new SVM();
                model.C = 100;
                model.Type = SVM.SvmType.CSvc;
                //model.Coef0 = 0.0; //TODO:Revisar o eliminar
                //model.Degree = 3; //TODO:Revisar o eliminar
                //model.Nu = 0.5;//TODO:Revisar o eliminar
                //model.P = 0.1;//TODO:Revisar o eliminar
                model.Gamma = 0.005;
                model.SetKernel(SVM.SvmKernelType.Linear);
                model.TermCriteria = new MCvTermCriteria(1000, 1e-6);
                model.Train(dataTrainMat, Emgu.CV.ML.MlEnum.DataLayoutType.RowSample, labelTrain); //<==== BUG posible solucion http://answers.opencv.org/question/93012/svm-training-data-error/
                model.Save("svm.txt");

                testIt();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror: " + ex.Message, "Módulo .:. Form1 ");
            }


            


        }

        public static IEnumerable<FileInfo> GetFilesByExtensions(DirectoryInfo dir, params string[] extensions)
        {
            if (extensions == null)
                throw new ArgumentNullException("extensions");
            IEnumerable<FileInfo> files = dir.EnumerateFiles();
            return files.Where(f => extensions.Contains(f.Extension));
        }

        public void loadDatatraining()
        {
            faceDetector = new CascadeClassifier("haarcascade_frontalface_default.xml");
            // Especificar ruta de origen para datos de entrenamiento
            var path = new DirectoryInfo(Path.Combine(Application.StartupPath, "resources/data-train"));
            string[] dirsDataTrain = Directory.GetDirectories(@path.ToString());
            int tamDataTrain = 0;
            int imgCount = 0;
            int classID = 0;
            foreach (var folder in dirsDataTrain)
            {
                string[] subDir = Directory.GetFiles(folder.ToString(), "*.jpg");
                tamDataTrain += (int) subDir.Length;
            }
            dataTrain = new List<Mat>();
            labelTrain = new Matrix<int>(tamDataTrain, 1); //Este valor queda definido según el tamaño de la muestra.

            //Se procede a cargar todas las imágenes de entrenamiento
            //se utiliza una sentencia de repetición en caso de existir 
            //una categorización distribuida en carpetas.
            try
            {

                foreach (DirectoryInfo classFolder in path.EnumerateDirectories())
                {
                    string nameFolder = classFolder.Name;
                    classID += 1;
                    // Clasificar la imágenes según su extensión (compresión de imagen)
                    FileInfo[] files = GetFilesByExtensions(classFolder, ".jpg", ".png").ToArray();

                    // Iterar por carpeta, buscando imágenes
                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo file = files[i];  
                        IImage img = new Mat(file.FullName, ImreadModes.Color);
                        UMat imgGray = new UMat();
                        CvInvoke.CvtColor(img, imgGray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                        //Detección de rostros en la una imagen, debería encontrar un sólo rostro por imagen
                        foreach (Rectangle face in faceDetector.DetectMultiScale(imgGray, 1.1, 10, new Size(20, 20), Size.Empty))
                        {
                            CvInvoke.Rectangle(img, face, new MCvScalar(255, 255, 255));

                            //A continuación sigue el proceso de Preprocesado de la imagen
                            //este consiste en los siguientes pasos: convertir escala de grises, recorte y escalado.
                            //TODO: ajustar rostro en función del ojo derecho

                            //Conversión de tipo Mat a Image<Brg, Byte>
                            Image<Gray, Byte> image = imgGray.ToImage<Gray, Byte>();
                            image.ROI = Rectangle.Empty;
                            //Estableciendo tamaño de región de interés
                            Rectangle roi = new Rectangle(face.X, face.Y, face.Width, face.Height);
                            image.ROI = roi;
                            Image<Gray, Byte> imgResize = image.Copy(roi);
                            imgResize = imgResize.Resize(64, 64, Inter.Linear, false);
                            imgResize._EqualizeHist();
                            imgMat = imgResize.Mat;
                        }
                        //Agregando una imagen de tipo Mat a la lista
                        dataTrain.Add(imgMat);
                        //Etiquetando datos de entrada
                        labelTrain[imgCount, 0] = (int)classID;
                        imgCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror: "+ex.Message, "Módulo .:. loadDatatraining: ");
            }
            Console.WriteLine("Número total de imágenes cargadas: {0}", imgCount);

        }

        public HOGDescriptor hog()
        {
            desHog = new HOGDescriptor(new Size(64, 64), new Size(8, 8), new Size(4, 4), new Size(8, 8), 9, 1, -1, 0.2, true);
            //HOGDescriptor(Size winSize, Size blockSize, Size blockStride, Size cellSize, int nbins = 9, int derivAperture = 1, double winSigma = -1, double L2HysThreshold = 0.2, bool gammaCorrection = true);
            return desHog;
        }

        public void calculateDescriptorsHOG()
        {
            //Aplicar por imagen de entrenamiento el descriptor HOG
            try
            {
                dataTrainHOG = new List<List<float>>();
                float[] descriptor;

                for (int y = 0; y < dataTrain.Count; y++)
                {
                    List<float> descriptors = new List<float>();

                    Image<Gray, Byte> imgByte = (dataTrain.ElementAt(y)).ToImage<Gray, Byte>();

                    descriptor = desHog.Compute(imgByte, new Size(64, 64), new Size(0, 0), null); //Se supone de debería retornar un vector de float vector<float>
                    descriptors = descriptor.OfType<float>().ToList();//debo convertir float[] to List<float>
                    dataTrainHOG.Add(descriptors);
                }
                //Tamaño de un descriptor
                descriptorSize = dataTrainHOG[0].Count();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror: " + ex.Message, "Módulo .:. calculateDescriptorsHOG");
            }

        }

        public void convertVectorToMatrix()
        {

            try
            {
                //Convertir un objeto Mat a Matrix para acceder a sus datos
                matrizMat= new Matrix<float>(dataTrainMat.Rows, dataTrainMat.Cols, dataTrainMat.NumberOfChannels);               
                dataTrainMat.CopyTo(matrizMat);

                for (int i = 0; i < dataTrainHOG.Count(); i++)
                {
                    for (int j = 0; j < dataTrainHOG[0].Count(); j++)
                    {
                        
                        matrizMat[i, j] = (float) dataTrainHOG[i].ElementAt(j);
                    }
                }
                //Volcar los datos procesados al objeto dataTrainMat
                //Comprobar que efectivamente se está copiando
                matrizMat.Mat.CopyTo(dataTrainMat);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: "+ ex.Message, "Módulo .:. convertVectorToMatrix");
            }            
        }

        public void testIt()
        {
            try
            {
                
                List<Mat> dataTest = new List<Mat>();
                CascadeClassifier faceDetectorTest = new CascadeClassifier("haarcascade_frontalface_default.xml");
                CascadeClassifier eyeDetectorTest = new CascadeClassifier("haarcascade_eye.xml");
                //TODO: Se debe aplicar el proceso de detección de un rostro en la imagen
                //y a esto ROI aplicar el preprocesado
                IImage img = new Mat(@"E:\Repositorio-Proyecto-Tesis-UTA\Proyecto-Tesis-UTA\Proyecto_Tesis\Sistema_Reconocimiento_Facial\resources\data-test\test-2.jpg", ImreadModes.Color);
                UMat imgGray = new UMat();
                CvInvoke.CvtColor(img, imgGray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                Image<Gray, Byte> imgRotate = imgGray.ToImage<Gray, Byte>();
                //TODO: ajustar rostro en función del ojo derecho
                Rectangle[] eyes = eyeDetectorTest.DetectMultiScale(img, 1.1, 10, new Size(20, 20));
                //Rotar la imagen únicamente cuando se detectan ambos ojos
                if(eyes.Count() == 2 )
                {
                    var deltaY = (eyes[1].Y + eyes[1].Height / 2) - (eyes[0].Y + eyes[0].Height / 2);
                    var deltaX = (eyes[1].X + eyes[1].Width / 2) - (eyes[0].X + eyes[0].Width / 2);
                    double degrees = Math.Atan2(deltaY, deltaX) * 180 / Math.PI;
                    if (Math.Abs(degrees) < 35)
                    {
                        imgRotate = imgRotate.Rotate(-degrees, new Gray(0));
                    }
                }
                //Detección de rostros en la una imagen, debería encontrar un sólo rostro por imagen
                foreach (Rectangle face in faceDetectorTest.DetectMultiScale(imgRotate, 1.1, 10, new Size(20, 20), Size.Empty))
                {
                    CvInvoke.Rectangle(img, face, new MCvScalar(255, 255, 255));

                    //A continuación sigue el proceso de Preprocesado de la imagen
                    //este consiste en los siguientes pasos: convertir escala de grises, recorte y escalado.
                    
                    //Conversión de tipo Mat a Image<Brg, Byte>
                    Image<Gray, Byte> imgTest = imgGray.ToImage<Gray, Byte>();
                    //TODO:Rotar tomando como base el ojo derecho
                    imgTest.ROI = Rectangle.Empty;
                    //Estableciendo tamaño de región de interés
                    Rectangle roi = new Rectangle(face.X, face.Y, face.Width, face.Height);
                    imgTest.ROI = roi;
                    Image<Gray, Byte> imgResize = imgTest.Copy(roi);
                    imgResize = imgResize.Resize(64, 64, Inter.Linear, false);
                    pbImageRecortada.Image = imgResize.Bitmap; //Imagen recortada
                    imgResize._EqualizeHist();
                    
                    
                    Mat imgMatTest = new Mat(new Size(64, 64), DepthType.Cv32F, 1);
                    imgMatTest = imgResize.Mat;
                    pbImagenOriginal.Image = img.Bitmap; //Imagen original
                    pbImageEcualizada.Image = imgResize.Bitmap;//Imagen recortada ecualizada
                    dataTest.Add(imgMatTest);
                }
                

                //TODO: Instanciar un objeto de tipo HOG
                HOGDescriptor testHog = new HOGDescriptor(new Size(64, 64), new Size(8, 8), new Size(4, 4), new Size(8, 8), 9, 1, -1, 0.2, true);


                //TODO: Calcular descriptor HOG de la imagen
                List<List<float>> dataTestHOG = new List<List<float>>();
                float[] descriptor;

                for (int y = 0; y < dataTest.Count; y++) //Debería tener el valor de 1
                {
                    List<float> descriptors = new List<float>();

                    Image<Gray, Byte> imgByte = (dataTest.ElementAt(y)).ToImage<Gray, Byte>();

                    descriptor = testHog.Compute(imgByte, new Size(64, 64), new Size(0, 0), null);
                    descriptors = descriptor.OfType<float>().ToList();
                    dataTestHOG.Add(descriptors);
                }
                int descriptorSizeTest = dataTestHOG[0].Count();

                //TODO: Definir objeto de tipo Mat con formato Cv32F
                Mat dataTestMat = new Mat(new Size((int)dataTestHOG[0].Count(), dataTestHOG.Count()), DepthType.Cv32F, 1);


                //TODO: Convertir Vector a Matrix

                Matrix<float> matrizMat2 = new Matrix<float>(dataTestMat.Rows, dataTestMat.Cols, dataTestMat.NumberOfChannels);
                dataTestMat.CopyTo(matrizMat);

                for (int i = 0; i < dataTestHOG.Count(); i++)
                {
                    for (int j = 0; j < dataTestHOG[0].Count(); j++)
                    {
                        matrizMat2[i, j] = (float)dataTestHOG[i].ElementAt(j);
                    }
                }
                matrizMat2.Mat.CopyTo(dataTestMat);

                float result = model.Predict(dataTestMat);
                MessageBox.Show(result.ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo .:. testIt");
            }
        }
    }
}