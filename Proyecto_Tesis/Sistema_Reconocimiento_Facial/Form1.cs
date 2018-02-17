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
        private static string pathCascadeFace = "haarcascade_frontalface_default.xml";
        private static string pathCascadeEye = "haarcascade_eye.xml";

        private List<Mat> dataTrain; //Datos de entrenamiento.
        private Matrix<int> labelTrain; //Etiquetas para datos de entrenamiento.
        private List<List<float>> dataTrainHOG; //Descriptores HOG para datos de entrenamiento.
        private Mat dataTrainMat; //Datos de entrenamiento formateados para la SVM.

        private SVM model; //Modelo de entrenamiento.

        private int sizeDescriptor; //Tamaño fijo para todos los decriptores.
        private int countDescriptors; //Cantidad de descriptores (debe ser igual al número de muestras).
        private static int imgCount = 0; //Número de muestras.

        public Form1()
        {
            InitializeComponent();
            try
            {
                loadDatatraining(ref dataTrain, ref labelTrain);
                calculateDescriptorsHOG(dataTrain, ref dataTrainHOG, out sizeDescriptor, out countDescriptors);
                dataTrainMat = new Mat(new Size(sizeDescriptor , countDescriptors), DepthType.Cv32F, 1); //	Mat(Size, DepthType, Int32)
                convertVectorToMatrix(ref dataTrainMat, dataTrainHOG);
                model = training(dataTrainMat, labelTrain);

                //Test
                IImage img = new Mat(@"E:\Repositorio-Proyecto-Tesis-UTA\Proyecto-Tesis-UTA\Proyecto_Tesis\Sistema_Reconocimiento_Facial\resources\data-test\test-4.jpg", ImreadModes.Color);
                testIt(img);
                //testIt();
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

        //Fuente: http://blogs.interknowlogy.com/2013/10/27/emgucv-rotating-face-images-to-align-eyes/#comment-233480
        public static Image<Gray, byte> alignEyes(Image<Gray, byte> image)
        {
            CascadeClassifier eyeDetectorTest = new CascadeClassifier(pathCascadeEye);
            Rectangle[] eyes = eyeDetectorTest.DetectMultiScale(image, 1.1, 10, new Size(20, 20));
            try
            {
                //Rotar la imagen únicamente cuando se detectan ambos ojos
                if (eyes.Count() == 2)
                {
                    var deltaY = (eyes[1].Y + eyes[1].Height / 2) - (eyes[0].Y + eyes[0].Height / 2);
                    var deltaX = (eyes[1].X + eyes[1].Width / 2) - (eyes[0].X + eyes[0].Width / 2);

                    //El ángulo resultante está expresado en radianes, por lo que es necesaria una conversión a grados.
                    double degrees = Math.Atan2(deltaY, deltaX) * 180 / Math.PI;
                    if (Math.Abs(degrees) < 35)
                    {
                        image = image.Rotate(-degrees, new Gray(0));
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo .:. AlignEyes");
            }
            return image;
        }

        public Mat preProcessing(Image<Gray,Byte> frame)
        {
            Mat imgMat = null;
            CascadeClassifier faceDetector = new CascadeClassifier(pathCascadeFace);
            try
            {
                frame = alignEyes(frame);
                //Detección de rostros en la  imagen, debería encontrar un solo rostro por imagen
                foreach (Rectangle face in faceDetector.DetectMultiScale(frame, 1.1, 10, new Size(20, 20), Size.Empty))
                {
                    CvInvoke.Rectangle(frame, face, new MCvScalar(255, 255, 255));
                    //A continuación sigue el proceso de Preprocesado de la imagen
                    //este consiste en los siguientes pasos: convertir escala de grises, 
                    // recorte, escalado y rotación de imagen (con base en los ojos).
                    frame.ROI = Rectangle.Empty;
                    //Estableciendo tamaño de región de interés
                    Rectangle roi = new Rectangle(face.X, face.Y, face.Width, face.Height); //Región de interés
                    frame.ROI = roi;
                    Image<Gray, Byte> imgResize = frame.Copy(roi); //Recorte de imagen (rostro)
                    imgResize = imgResize.Resize(64, 64, Inter.Linear, false); //Escalado de imagen 64x64 px.
                    imgResize._EqualizeHist(); //Ecualización de histograma de imagen.
                    imgMat = imgResize.Mat;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo .:. preProcessing");
            }
            return imgMat;
        }

        public void loadDatatraining(ref List<Mat> dataTrain, ref Matrix<int> labelTrain)
        {
            try
            {
                dataTrain = new List<Mat>();
                // Especificar ruta de origen para datos de entrenamiento
                var path = new DirectoryInfo(Path.Combine(Application.StartupPath, "resources/data-train"));
                string[] dirsDataTrain = Directory.GetDirectories(@path.ToString());
                int tamDataTrain = 0;
                int classID = 0;
                foreach (var folder in dirsDataTrain)
                {
                    string[] subDir = Directory.GetFiles(folder.ToString(), "*.jpg");
                    tamDataTrain += (int) subDir.Length;
                }
                labelTrain = new Matrix<int>(tamDataTrain, 1); //Este valor queda definido según el tamaño de la muestra.

                //Se procede a cargar todas las imágenes de entrenamiento
                //se utiliza una sentencia de repetición en caso de existir 
                //una categorización distribuida en carpetas.
                foreach (DirectoryInfo classFolder in path.EnumerateDirectories())
                {
                    string nameFolder = classFolder.Name;
                    classID += 1;
                    // Clasificar la imágenes según su extensión (compresión de imagen).
                    FileInfo[] files = GetFilesByExtensions(classFolder, ".jpg", ".png").ToArray();

                    // Iterar por carpeta, buscando imágenes
                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo file = files[i];
                        IImage img = new Mat(file.FullName, ImreadModes.Color);
                        UMat imgGray = new UMat();
                        CvInvoke.CvtColor(img, imgGray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

                        //Todas las muestras deben ser preprocesadas.
                        Mat imgMat = preProcessing(imgGray.ToImage<Gray, Byte>());
                        //Etiquetando datos de entrada
                        labelTrain[imgCount, 0] = (int)classID;
                        //Agregando una imagen de tipo Mat a la lista
                        dataTrain.Add(imgMat);
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

        public void calculateDescriptorsHOG(List<Mat> dataTrain, ref List<List<float>> dataTrainHOG, out int sizeDescriptor, out int countDescriptors)
        {
            //HOGDescriptor(Size winSize, Size blockSize, Size blockStride, Size cellSize, int nbins = 9, int derivAperture = 1, double winSigma = -1, double L2HysThreshold = 0.2, bool gammaCorrection = true);
            HOGDescriptor HOG = new HOGDescriptor(new Size(64, 64), new Size(8, 8), new Size(4, 4), new Size(8, 8), 9, 1, -1, 0.2, true);
            dataTrainHOG = new List<List<float>>();
            //Aplicar por imagen de entrenamiento el descriptor HOG
            try
            {
                float[] descriptor;
                for (int y = 0; y < dataTrain.Count; y++)
                {
                    List<float> descriptors = new List<float>();
                    Image<Gray, Byte> imgByte = (dataTrain.ElementAt(y)).ToImage<Gray, Byte>();
                    descriptor = HOG.Compute(imgByte, new Size(64, 64), new Size(0, 0), null); //Se supone de debería retornar un vector de float vector<float>
                    descriptors = descriptor.OfType<float>().ToList();//debo convertir float[] to List<float>
                    dataTrainHOG.Add(descriptors);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror: " + ex.Message, "Módulo .:. calculateDescriptorsHOG");
            }
            //Tamaño de un descriptor
            finally
            {
                sizeDescriptor = (int) dataTrainHOG[0].Count();
                countDescriptors = (int) dataTrainHOG.Count();
            }
        }

        public void convertVectorToMatrix(ref Mat dataTrainMat, List<List<float>> dataTrainHOG)
        {

            try
            {
                //Convertir un objeto Mat a Matrix para acceder a sus datos
                Matrix<float> matrizMat = new Matrix<float>(dataTrainMat.Rows, dataTrainMat.Cols, dataTrainMat.NumberOfChannels);
                dataTrainMat.CopyTo(matrizMat);

                for (int i = 0; i < dataTrainHOG.Count(); i++) //Número de descriptores
                {
                    for (int j = 0; j < dataTrainHOG[0].Count(); j++) //Tamaño del descriptor
                    {
                        
                        matrizMat[i, j] = (float) dataTrainHOG[i].ElementAt(j);
                    }
                }
                //Volcar los datos procesados al objeto dataTrainMat
                matrizMat.Mat.CopyTo(dataTrainMat);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: "+ ex.Message, "Módulo .:. convertVectorToMatrix");
            }            
        }

        public SVM training(Mat dataTrainMat, Matrix<int> labelTrain)
        {
            //Creación del SVM
            //Definición de parámetros
            SVM model = new SVM();
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

            return model;
        }

        public void testIt(IImage frame)
        {

            int sizeDescriptor;
            int countDescriptors;
            List<Mat> dataTest = new List<Mat>();
            List<List<float>>  dataTestHOG = new List<List<float>>();
            UMat frameGray = new UMat();
            CvInvoke.CvtColor(frame, frameGray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

            Image<Gray, byte> frameOriginal = alignEyes(frameGray.ToImage<Gray, byte>());
            Image<Gray,byte> frameFormat = alignEyes(frameGray.ToImage<Gray, byte>());
            Mat frameMat = preProcessing(frameFormat);
            dataTest.Add(frameMat);

            calculateDescriptorsHOG(dataTest, ref dataTestHOG, out sizeDescriptor, out countDescriptors);
            Mat dataTestMat = new Mat(new Size(sizeDescriptor, countDescriptors), DepthType.Cv32F, 1); //	Mat(Size, DepthType, Int32)
            convertVectorToMatrix(ref dataTestMat, dataTestHOG);

            float result = model.Predict(dataTestMat);
            Console.WriteLine("El sujeto corresponde a la clase: " + result.ToString());

            var border = new Rectangle(0, 0, 200, 40);
            frameOriginal.Draw(border, new Gray(0), -1);
            frameOriginal.Draw(border, new Gray(0));
            CvInvoke.PutText(frameOriginal, result.ToString(), new Point(10, border.Height - 10), FontFace.HersheySimplex, 1.0, new Bgr(Color.Blue).MCvScalar);
            pbImagenOriginal.Image = frameOriginal.Bitmap;
        }
    }
}