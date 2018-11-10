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
//Referencias para categorizar muestras
using Microsoft.VisualBasic.Devices;
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
        private int WIDTH_FRAME_CAMERA = 1280;
        private int HEIGHT_FRAME_CAMERA = 720;
        private int WIDTH_WINDOW = 640;
        private int HEIGHT_WINDOW = 360;
        private double porcentajeAceptacionMax;
        private double porcentajeAceptacionMin;
        private Computer myComputer = new Computer();

        //Estructura de dato para búsqueda rápida de una persona por etiqueta/clase.
        private Dictionary<int, string> listSearch;
        private Dictionary<int, Person> listPersons;
        //Datos de entrenamiento.
        private List<Mat> dataTrain;
        private List<Mat> dataRoi1;
        private List<Mat> dataRoi2;
        private List<Mat> dataRoi3;
        private List<Mat> dataRoi4;
        private List<Mat> dataRoi5;
        private List<Mat> dataRoi6;
        private List<Mat> dataRoi7;
        private List<Mat> dataRoi8;
        private List<Mat> dataRoi9;
        private List<Mat> dataRoi10;
        private List<Mat> dataRoi11;
        private List<Mat> dataRoi12;
        private List<Mat> dataRoi13;
        private List<Mat> dataRoi14;
        private List<Mat> dataRoi15;
        private List<Mat> dataRoi16;
        private List<Mat> dataRoi17;
        private List<Mat> dataRoi18;
        private List<Mat> dataRoi19;
        private List<Mat> dataRoi20;
        private List<Mat> dataRoi21;
        private List<Mat> dataRoi22;
        private List<Mat> dataRoi23;
        private List<Mat> dataRoi24;
        private List<Mat> dataRoi25;
        private List<Mat> dataRoi26;
        private List<Mat> dataRoi27;
        private List<Mat> dataRoi28;
        private List<Mat> dataRoi29;
        private List<Mat> dataRoi30;
        private List<Mat> dataRoi31;
        private List<Mat> dataRoi32;
        private List<Mat> dataRoi33;
        private List<Mat> dataRoi34;
        private List<Mat> dataRoi35;
        private List<Mat> dataRoi36;
        private List<Mat> dataRoi37;
        private List<Mat> dataRoi38;
        private List<Mat> dataRoi39;
        private List<Mat> dataRoi40;
        private List<Mat> dataRoi41;
        private List<Mat> dataRoi42;
        private List<Mat> dataRoi43;
        private List<Mat> dataRoi44;
        private List<Mat> dataRoi45;
        private List<Mat> dataRoi46;
        private List<Mat> dataRoi47;
        private List<Mat> dataRoi48;
        private List<Mat> dataRoi49;
        private List<Mat> dataRoi50;
        private List<Mat> dataRoi51;
        private List<Mat> dataRoi52;
        private List<Mat> dataRoi53;
        private List<Mat> dataRoi54;
        private List<Mat> dataRoi55;
        private List<Mat> dataRoi56;
        private List<Mat> dataRoi57;
        private List<Mat> dataRoi58;
        private List<Mat> dataRoi59;
        private List<Mat> dataRoi60;
        private List<Mat> dataRoi61;
        private List<Mat> dataRoi62;
        private List<Mat> dataRoi63;
        private List<Mat> dataRoi64;
        //Etiquetas para datos de entrenamiento.
        private Matrix<int> labelTrain;
        //Descriptores HOG para datos de entrenamiento. 
        private List<List<float>> dataTrainHOG;
        private List<List<float>> dataRoi1HOG;
        private List<List<float>> dataRoi2HOG;
        private List<List<float>> dataRoi3HOG;
        private List<List<float>> dataRoi4HOG;
        private List<List<float>> dataRoi5HOG;
        private List<List<float>> dataRoi6HOG;
        private List<List<float>> dataRoi7HOG;
        private List<List<float>> dataRoi8HOG;
        private List<List<float>> dataRoi9HOG;
        private List<List<float>> dataRoi10HOG;
        private List<List<float>> dataRoi11HOG;
        private List<List<float>> dataRoi12HOG;
        private List<List<float>> dataRoi13HOG;
        private List<List<float>> dataRoi14HOG;
        private List<List<float>> dataRoi15HOG;
        private List<List<float>> dataRoi16HOG;
        private List<List<float>> dataRoi17HOG;
        private List<List<float>> dataRoi18HOG;
        private List<List<float>> dataRoi19HOG;
        private List<List<float>> dataRoi20HOG;
        private List<List<float>> dataRoi21HOG;
        private List<List<float>> dataRoi22HOG;
        private List<List<float>> dataRoi23HOG;
        private List<List<float>> dataRoi24HOG;
        private List<List<float>> dataRoi25HOG;
        private List<List<float>> dataRoi26HOG;
        private List<List<float>> dataRoi27HOG;
        private List<List<float>> dataRoi28HOG;
        private List<List<float>> dataRoi29HOG;
        private List<List<float>> dataRoi30HOG;
        private List<List<float>> dataRoi31HOG;
        private List<List<float>> dataRoi32HOG;
        private List<List<float>> dataRoi33HOG;
        private List<List<float>> dataRoi34HOG;
        private List<List<float>> dataRoi35HOG;
        private List<List<float>> dataRoi36HOG;
        private List<List<float>> dataRoi37HOG;
        private List<List<float>> dataRoi38HOG;
        private List<List<float>> dataRoi39HOG;
        private List<List<float>> dataRoi40HOG;
        private List<List<float>> dataRoi41HOG;
        private List<List<float>> dataRoi42HOG;
        private List<List<float>> dataRoi43HOG;
        private List<List<float>> dataRoi44HOG;
        private List<List<float>> dataRoi45HOG;
        private List<List<float>> dataRoi46HOG;
        private List<List<float>> dataRoi47HOG;
        private List<List<float>> dataRoi48HOG;
        private List<List<float>> dataRoi49HOG;
        private List<List<float>> dataRoi50HOG;
        private List<List<float>> dataRoi51HOG;
        private List<List<float>> dataRoi52HOG;
        private List<List<float>> dataRoi53HOG;
        private List<List<float>> dataRoi54HOG;
        private List<List<float>> dataRoi55HOG;
        private List<List<float>> dataRoi56HOG;
        private List<List<float>> dataRoi57HOG;
        private List<List<float>> dataRoi58HOG;
        private List<List<float>> dataRoi59HOG;
        private List<List<float>> dataRoi60HOG;
        private List<List<float>> dataRoi61HOG;
        private List<List<float>> dataRoi62HOG;
        private List<List<float>> dataRoi63HOG;
        private List<List<float>> dataRoi64HOG;
        //Datos de entrenamiento formateados para la SVM.
        private Mat dataTrainMat;
        private Mat dataRoi1Mat;
        private Mat dataRoi2Mat;
        private Mat dataRoi3Mat;
        private Mat dataRoi4Mat;
        private Mat dataRoi5Mat;
        private Mat dataRoi6Mat;
        private Mat dataRoi7Mat;
        private Mat dataRoi8Mat;
        private Mat dataRoi9Mat;
        private Mat dataRoi10Mat;
        private Mat dataRoi11Mat;
        private Mat dataRoi12Mat;
        private Mat dataRoi13Mat;
        private Mat dataRoi14Mat;
        private Mat dataRoi15Mat;
        private Mat dataRoi16Mat;
        private Mat dataRoi17Mat;
        private Mat dataRoi18Mat;
        private Mat dataRoi19Mat;
        private Mat dataRoi20Mat;
        private Mat dataRoi21Mat;
        private Mat dataRoi22Mat;
        private Mat dataRoi23Mat;
        private Mat dataRoi24Mat;
        private Mat dataRoi25Mat;
        private Mat dataRoi26Mat;
        private Mat dataRoi27Mat;
        private Mat dataRoi28Mat;
        private Mat dataRoi29Mat;
        private Mat dataRoi30Mat;
        private Mat dataRoi31Mat;
        private Mat dataRoi32Mat;
        private Mat dataRoi33Mat;
        private Mat dataRoi34Mat;
        private Mat dataRoi35Mat;
        private Mat dataRoi36Mat;
        private Mat dataRoi37Mat;
        private Mat dataRoi38Mat;
        private Mat dataRoi39Mat;
        private Mat dataRoi40Mat;
        private Mat dataRoi41Mat;
        private Mat dataRoi42Mat;
        private Mat dataRoi43Mat;
        private Mat dataRoi44Mat;
        private Mat dataRoi45Mat;
        private Mat dataRoi46Mat;
        private Mat dataRoi47Mat;
        private Mat dataRoi48Mat;
        private Mat dataRoi49Mat;
        private Mat dataRoi50Mat;
        private Mat dataRoi51Mat;
        private Mat dataRoi52Mat;
        private Mat dataRoi53Mat;
        private Mat dataRoi54Mat;
        private Mat dataRoi55Mat;
        private Mat dataRoi56Mat;
        private Mat dataRoi57Mat;
        private Mat dataRoi58Mat;
        private Mat dataRoi59Mat;
        private Mat dataRoi60Mat;
        private Mat dataRoi61Mat;
        private Mat dataRoi62Mat;
        private Mat dataRoi63Mat;
        private Mat dataRoi64Mat;
        //Modelo de entrenamiento.
        private SVM model;
        private SVM modelRoi1;
        private SVM modelRoi2;
        private SVM modelRoi3;
        private SVM modelRoi4;
        private SVM modelRoi5;
        private SVM modelRoi6;
        private SVM modelRoi7;
        private SVM modelRoi8;
        private SVM modelRoi9;
        private SVM modelRoi10;
        private SVM modelRoi11;
        private SVM modelRoi12;
        private SVM modelRoi13;
        private SVM modelRoi14;
        private SVM modelRoi15;
        private SVM modelRoi16;
        private SVM modelRoi17;
        private SVM modelRoi18;
        private SVM modelRoi19;
        private SVM modelRoi20;
        private SVM modelRoi21;
        private SVM modelRoi22;
        private SVM modelRoi23;
        private SVM modelRoi24;
        private SVM modelRoi25;
        private SVM modelRoi26;
        private SVM modelRoi27;
        private SVM modelRoi28;
        private SVM modelRoi29;
        private SVM modelRoi30;
        private SVM modelRoi31;
        private SVM modelRoi32;
        private SVM modelRoi33;
        private SVM modelRoi34;
        private SVM modelRoi35;
        private SVM modelRoi36;
        private SVM modelRoi37;
        private SVM modelRoi38;
        private SVM modelRoi39;
        private SVM modelRoi40;
        private SVM modelRoi41;
        private SVM modelRoi42;
        private SVM modelRoi43;
        private SVM modelRoi44;
        private SVM modelRoi45;
        private SVM modelRoi46;
        private SVM modelRoi47;
        private SVM modelRoi48;
        private SVM modelRoi49;
        private SVM modelRoi50;
        private SVM modelRoi51;
        private SVM modelRoi52;
        private SVM modelRoi53;
        private SVM modelRoi54;
        private SVM modelRoi55;
        private SVM modelRoi56;
        private SVM modelRoi57;
        private SVM modelRoi58;
        private SVM modelRoi59;
        private SVM modelRoi60;
        private SVM modelRoi61;
        private SVM modelRoi62;
        private SVM modelRoi63;
        private SVM modelRoi64;
        //Tamaño fijo para todos los descriptores.
        private int sizeDescriptor;
        private int sizeRoi1Descriptor;
        //Cantidad de descriptores (debe ser igual al número de muestras).
        private int countDescriptors;
        private int countRoi1Descriptors;
        //Número de muestras.
        private static int imgCount = 0;
        //Parámetos SVM's
        private int C;
        private double gamma;
        private double coef0;
        private int degree;
        private double nu;
        private double P;

        private VideoCapture _capture = null;

        private Mat _frame;

        //Nombre de sujetos
        private string sujetoDesconocido;
        private string sujetoIdentificado;

        //Variables Extras
        private static int conteoRostrosFragmentados = 0;
        private int conteoFrames = 0;
        private Boolean isWorking = false;
        private Dictionary<string,string> sujetosEvaluados;
        private DataTable dtSujetos;
        private int nroSujetosHallados=0;
        private VideoWriter VideoW;
        private Boolean isRecording = false;

        public Form1()
        {
            InitializeComponent();
            try
            {
                //this.cleanSamples();
                this.crearTabla();
                CheckForIllegalCrossThreadCalls = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror: " + ex.Message, "Módulo .:. Form1 ");
            }
        }

        private void crearTabla()
        {
            this.dtSujetos = new DataTable("Sujeto-Hallados");
            this.dtSujetos.Columns.Add("id", System.Type.GetType("System.Int32"));
            this.dtSujetos.Columns.Add("nombre", System.Type.GetType("System.String"));
            this.dtSujetos.Columns.Add("fecha_registro", System.Type.GetType("System.String"));
            
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dgvSujetos.DataSource = this.dtSujetos;

            //Inicializar grid de fotos de sujetos encontrados
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "Foto";
            imgCol.Name = "Foto";
            this.dgvFotosSujetosEncontradas.Columns.Add(imgCol);
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            try
            {
                if (_capture != null && _capture.Ptr != IntPtr.Zero)
                {
                    _capture.Retrieve(_frame, 0);
                    if (this.isRecording) this.VideoW.Write(_frame);
                    // Revisar el acoumulador de puntuación de los sujetos cada 5 seg.
                    // y reinicar lo acumuladores personales
                    if (this.conteoFrames == 30 && this.isWorking==true)
                    {
                        //Se revisa si el lapso definido (5 seg.) fue identificado algún sujeto
                        //Posterior, se reinician los acumuladores
                        this.evaluacionConteoFramesPositivos();
                        this.limpiarConteoFramesPositivos();
                        this.conteoFrames = 0;
                    }
                    this.conteoFrames += 1;
                    if (this.isWorking)
                    {
                        if (this.conteoFrames % 10 == 0)
                        {
                            List<Face> faceDetected = new List<Face>();
                            faceDetected = detectFaces(_frame.ToImage<Gray, Byte>().Resize(this.WIDTH_FRAME_CAMERA, this.HEIGHT_FRAME_CAMERA, Inter.Linear, false)); //Intenta buscar un rostro en el frame
                            if (faceDetected.Count > 0)
                            {
                                this.testItFragmentFactor4(_frame.ToImage<Bgr, byte>());
                            }
                            else
                            {
                                //this.pbImagenOriginal.Image = _frame.ToImage<Bgr, Byte>().Resize(this.WIDTH_WINDOW, this.HEIGHT_WINDOW, Inter.Linear, false).Bitmap;
                                this.pbImagenOriginal.Image = this.evaluationIfDrawFaces(_frame).Bitmap;
                            }
                        }
                        else
                        {
                            //this.pbImagenOriginal.Image = _frame.ToImage<Bgr, Byte>().Resize(this.WIDTH_WINDOW, this.HEIGHT_WINDOW, Inter.Linear, false).Bitmap;
                            this.pbImagenOriginal.Image = this.evaluationIfDrawFaces(_frame).Bitmap;
                        }
                    }
                    else
                    {
                        //this.pbImagenOriginal.Image = _frame.ToImage<Bgr, Byte>().Resize(this.WIDTH_WINDOW, this.HEIGHT_WINDOW, Inter.Linear, false).Bitmap;
                        this.pbImagenOriginal.Image = this.evaluationIfDrawFaces(_frame).Bitmap;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo .:. ProcessFrame");
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

        public List<Face> detectFaces(Image<Gray, Byte> frame)
        {
            CascadeClassifier faceDetector = new CascadeClassifier(pathCascadeFace);
            List<Face> listFaces = new List<Face>();

            foreach (Rectangle faceRec in faceDetector.DetectMultiScale(frame, 1.1, 10, new Size(20, 20), Size.Empty))
            {
                CvInvoke.Rectangle(frame, faceRec, new MCvScalar(255, 255, 255));
                CvInvoke.Rectangle(frame, faceRec, new Bgr(Color.Red).MCvScalar, 2);
                frame.ROI = Rectangle.Empty;
                //Estableciendo tamaño de región de interés
                Rectangle roi = new Rectangle(faceRec.X, faceRec.Y, faceRec.Width, faceRec.Height); //Región de interés
                frame.ROI = roi;
                Image<Gray, Byte> faceRoi = frame.Copy(roi);
                Face face = new Face(faceRoi,faceRec);
                listFaces.Add(face);
            }
            return listFaces;
        }

        public Mat preProcessingDataTrain(Image<Gray,Byte> frame)
        {
            Mat imgMat = null;
            CascadeClassifier faceDetector = new CascadeClassifier(pathCascadeFace);
            try
            {
                frame = frame.Resize(1280, 720, Inter.Linear, false);
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

        public void loadDatatraining(ref List<Mat> dataTrain, ref Matrix<int> labelTrain, string pathOrigin)
        {
            try
            {
                imgCount = 0;
                dataTrain = new List<Mat>();
                listSearch = new Dictionary<int, string>();
                listPersons = new Dictionary<int, Person>();
                // Especificar ruta de origen para datos de entrenamiento
                var path = new DirectoryInfo(pathOrigin);
                string[] dirsDataTrain = Directory.GetDirectories(@path.ToString());
                int tamDataTrain = 0;
                int classID = 0;
                foreach (var folder in dirsDataTrain)
                {
                    string[] subDir = Directory.GetFiles(folder.ToString(), "*.jpg");
                    tamDataTrain += (int)subDir.Length;
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
                    //Agregando una persona a una lista de los más buscados.
                    listSearch.Add(classID, nameFolder);
                    Person sujeto = new Person();
                    sujeto.Nombre = nameFolder;
                    sujeto.NroVotos = 0;
                    sujeto.ConteoFramePositivos = 0;
                    listPersons.Add(classID,sujeto);
                    // Iterar por carpeta, buscando imágenes
                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo file = files[i];
                        IImage img = new Mat(file.FullName, ImreadModes.Color);
                        UMat imgGray = new UMat();
                        CvInvoke.CvtColor(img, imgGray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

                        //Todas las muestras deben ser preprocesadas.
                        Mat imgMat = preProcessingDataTrain(imgGray.ToImage<Gray, Byte>().Resize(1280, 720, Inter.Linear, false));
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
                MessageBox.Show("Eror: " + ex.Message, "Módulo .:. loadDatatraining: ");
            }
            Console.WriteLine("Número total de imágenes cargadas: {0}", imgCount);

        }
        public List<Mat> preProcessingDataTest(List<Face> facesDetected)
        {
            List<Mat> listImgMat = new List<Mat>();
            try
            {
                //Detección de rostros en la  imagen, debería encontrar un solo rostro por imagen
                foreach ( Face person in facesDetected)
                {
                    Image<Gray, Byte> faceAlign = alignEyes(person.FaceOnly);
                    faceAlign = faceAlign.Resize(64, 64, Inter.Linear, false); //Escalado de imagen 64x64 px.
                    faceAlign._EqualizeHist(); //Ecualización de histograma de imagen.
                    listImgMat.Add(faceAlign.Mat);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo .:. preProcessing");
            }
            return listImgMat;
        }
        
        //Fragmentación por factor de 1
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
                sizeDescriptor = (int)dataTrainHOG[0].Count();
                countDescriptors = (int)dataTrainHOG.Count();
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
            model.Train(dataTrainMat, Emgu.CV.ML.MlEnum.DataLayoutType.RowSample, labelTrain);
            //model.Save("model_svm.txt");

            return model;
        }
        public void testIt(IImage frame)
        {
            int sizeDescriptor;
            int countDescriptors;
            List<Mat> dataTest = new List<Mat>();
            List<List<float>> dataTestHOG = new List<List<float>>();
            UMat frameGray = new UMat();
            List<Face> faceDetected = new List<Face>();

            CvInvoke.CvtColor(frame, frameGray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            Image<Bgr, Byte> frameBgr = new Image<Bgr, Byte>(frame.Bitmap);

            faceDetected = detectFaces(frameGray.ToImage<Gray, Byte>().Resize(this.WIDTH_FRAME_CAMERA, this.HEIGHT_FRAME_CAMERA, Inter.Linear, false)); //Encuentra una lista de rostros hallados en el frame.
            dataTest = preProcessingDataTest(faceDetected); //Realiza una preprocesado a todos los rostros hallados.

            //SSi encuentra al menos un rostro
            if (dataTest.Count() >= 1)
            {
                calculateDescriptorsHOG(dataTest, ref dataTestHOG, out sizeDescriptor, out countDescriptors);
                Mat dataTestMat = new Mat(new Size(sizeDescriptor, countDescriptors), DepthType.Cv32F, 1); //	Mat(Size, DepthType, Int32)
                convertVectorToMatrix(ref dataTestMat, dataTestHOG);

                for (int numPerson = 0; numPerson < faceDetected.Count(); numPerson++)
                {
                    float result = model.Predict(dataTestMat.Row(numPerson));//Indicar la fila ha predecir
                    Face face = faceDetected.ElementAt(numPerson);
                    //Pintar y etiquetar
                    string nombre = listSearch[(int)result];
                    CvInvoke.Rectangle(frameBgr, face.Roi, new MCvScalar(0, 0, 255));
                    CvInvoke.PutText(frameBgr, nombre, new Point(face.Roi.X, face.Roi.Y), FontFace.HersheySimplex, 1.0, new Bgr(Color.Blue).MCvScalar);
                    pbImagenOriginal.Image = frameBgr.Bitmap;
                }
            }
            else
            {
                pbImagenOriginal.Image = frameBgr.Bitmap;
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

                        matrizMat[i, j] = (float)dataTrainHOG[i].ElementAt(j);
                    }
                }
                //Volcar los datos procesados al objeto dataTrainMat
                matrizMat.Mat.CopyTo(dataTrainMat);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo .:. convertVectorToMatrix");
            }
        }

        //Fragmentación por factor de 4
        public void fragmentImageFactor4(ref List<Mat> data)
        {
            int jump = 32;
            dataRoi1 = new List<Mat>();
            dataRoi2 = new List<Mat>();
            dataRoi3 = new List<Mat>();
            dataRoi4 = new List<Mat>();

            Image<Gray, Byte> roiAux;
            try
            {
                foreach (Mat face in data)
                {
                    Image<Gray, Byte> img = face.ToImage<Gray, Byte>();
                    Rectangle roi1 = new Rectangle(jump * 0, jump * 0, jump, jump); //1,1
                    Rectangle roi2 = new Rectangle(jump * 1, jump * 0, jump, jump); //1,2

                    Rectangle roi3 = new Rectangle(jump * 0, jump * 1, jump, jump); //2,1
                    Rectangle roi4 = new Rectangle(jump * 1, jump * 1, jump, jump); //2,2

                    roiAux = img.Copy(roi1);
                    dataRoi1.Add(roiAux.Mat);

                    roiAux = img.Copy(roi2);
                    dataRoi2.Add(roiAux.Mat);

                    roiAux = img.Copy(roi3);
                    dataRoi3.Add(roiAux.Mat);

                    roiAux = img.Copy(roi4);
                    dataRoi4.Add(roiAux.Mat);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo .:. fragmentImage");
            }
        }
        public void calculateFragmentDescriptorsHOGFactor4(ref List<Mat> dataTrain, ref List<List<float>> dataTrainHOG)
        {
            //HOGDescriptor(Size winSize, Size blockSize, Size blockStride, Size cellSize, int nbins = 9, int derivAperture = 1, double winSigma = -1, double L2HysThreshold = 0.2, bool gammaCorrection = true);
            HOGDescriptor HOG = new HOGDescriptor(new Size(32, 32), new Size(16, 16), new Size(8, 8), new Size(8, 8), 9, 1, -1, 0.2, true);
            dataTrainHOG = new List<List<float>>();
            //Aplicar por imagen de entrenamiento el descriptor HOG
            try
            {
                float[] descriptor;
                for (int y = 0; y < dataTrain.Count; y++)
                {
                    List<float> descriptors = new List<float>();
                    Image<Gray, Byte> imgByte = (dataTrain.ElementAt(y)).ToImage<Gray, Byte>();
                    descriptor = HOG.Compute(imgByte, new Size(16, 16), new Size(0, 0), null);
                    descriptors = descriptor.OfType<float>().ToList();
                    dataTrainHOG.Add(descriptors);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror: " + ex.Message, "Módulo .:. calculateDescriptorsHOG");
            }
        }
        public void convertFragmentVectorToMatrixFactor4(ref Mat dataTrainMat, List<List<float>> dataTrainHOG)
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

                        matrizMat[i, j] = (float)dataTrainHOG[i].ElementAt(j);
                    }
                }
                //Volcar los datos procesados al objeto dataTrainMat
                matrizMat.Mat.CopyTo(dataTrainMat);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo .:. convertVectorToMatrix");
            }
        }
        public SVM trainingFragmentFactor4(Mat dataTrainMat, Matrix<int> labelTrain)
        {
            //Creación del SVM
            //Definición de parámetros
            SVM model = new SVM();
            model.C = this.C; //100
            model.Type = SVM.SvmType.CSvc;
            model.Coef0 = this.coef0;
            model.Degree = this.degree;
            model.Nu = this.nu;
            model.P = this.P;
            model.Gamma = this.gamma;//0.005
            model.SetKernel(SVM.SvmKernelType.Linear);
            model.TermCriteria = new MCvTermCriteria(1000, 1e-6);
            model.Train(dataTrainMat, Emgu.CV.ML.MlEnum.DataLayoutType.RowSample, labelTrain);
            //model.Save("model_svm.txt");

            return model;
        }
        public void testItFragmentFactor4(IImage frame)
        {
            List<Mat> dataTest = new List<Mat>();
            List<List<float>> dataTestHOG = new List<List<float>>();

            UMat frameGray = new UMat();
            List<Face> faceDetected = new List<Face>();
            try
            {
                CvInvoke.CvtColor(frame, frameGray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                Image<Bgr, Byte> frameBgr = new Image<Bgr, Byte>(frame.Bitmap);
                //Encuentra una lista de rostros hallados en el frame.
                faceDetected = detectFaces(frameGray.ToImage<Gray, Byte>().Resize(this.WIDTH_WINDOW, this.HEIGHT_WINDOW, Inter.Linear, false));
                //Realiza una preprocesado a todos los rostros hallados.
                dataTest = preProcessingDataTest(faceDetected); 

                this.fragmentImageFactor4(ref dataTest);
                //SSi encuentra al menos un rostro
                if (dataTest.Count() >= 1)
                {
                    //calculateDescriptorsHOG(dataTest, ref dataTestHOG, out sizeDescriptor, out countDescriptors);
                    this.calculateFragmentDescriptorsHOGFactor4(ref dataRoi1, ref dataRoi1HOG);
                    this.calculateFragmentDescriptorsHOGFactor4(ref dataRoi2, ref dataRoi2HOG);
                    this.calculateFragmentDescriptorsHOGFactor4(ref dataRoi3, ref dataRoi3HOG);
                    this.calculateFragmentDescriptorsHOGFactor4(ref dataRoi4, ref dataRoi4HOG);

                    //Mat dataTestMat = new Mat(new Size(sizeDescriptor, countDescriptors), DepthType.Cv32F, 1); //	Mat(Size, DepthType, Int32)
                    this.dataRoi1Mat = new Mat(new Size(dataRoi1HOG[0].Count(), dataRoi1HOG.Count()), DepthType.Cv32F, 1);
                    this.dataRoi2Mat = new Mat(new Size(dataRoi2HOG[0].Count(), dataRoi2HOG.Count()), DepthType.Cv32F, 1);
                    this.dataRoi3Mat = new Mat(new Size(dataRoi3HOG[0].Count(), dataRoi3HOG.Count()), DepthType.Cv32F, 1);
                    this.dataRoi4Mat = new Mat(new Size(dataRoi4HOG[0].Count(), dataRoi4HOG.Count()), DepthType.Cv32F, 1);

                    //convertVectorToMatrix(ref dataTestMat, dataTestHOG);
                    this.convertFragmentVectorToMatrixFactor4(ref dataRoi1Mat, dataRoi1HOG);
                    this.convertFragmentVectorToMatrixFactor4(ref dataRoi2Mat, dataRoi2HOG);
                    this.convertFragmentVectorToMatrixFactor4(ref dataRoi3Mat, dataRoi3HOG);
                    this.convertFragmentVectorToMatrixFactor4(ref dataRoi4Mat, dataRoi4HOG);

                    for (int numPerson = 0; numPerson < faceDetected.Count(); numPerson++)
                    {
                        //Indicar la fila ha predecir
                        this.acumuladorPrediccion((int)modelRoi1.Predict(dataRoi1Mat.Row(numPerson)));
                        this.acumuladorPrediccion((int)modelRoi2.Predict(dataRoi2Mat.Row(numPerson)));
                        this.acumuladorPrediccion((int)modelRoi3.Predict(dataRoi3Mat.Row(numPerson)));
                        this.acumuladorPrediccion((int)modelRoi4.Predict(dataRoi4Mat.Row(numPerson)));

                        int resultado = this.evaluationPredictionFactor4();
                        if (resultado == 0) resultado = this.evaluationPrediction2Factor4();

                        if (resultado != 0)
                        {
                            Person sujeto = listPersons[resultado];
                            sujeto.ConteoFramePositivos += 1;
                            sujeto.Foto = faceDetected.ElementAt(numPerson);
                            //Pintar y etiquetar
                            string nombre = listSearch[resultado];
                            this.sujetoIdentificado = sujeto.Nombre;
                            Console.WriteLine(this.sujetoIdentificado);
                        }
                        else
                        {
                            Console.WriteLine("No fue posible identificar la muesta ingresada");
                            this.sujetoIdentificado = "No Identificado";
                        }
                        this.limpiarAcumuladorPrediccion();
                        this.pbImagenOriginal.Image = frameBgr.Resize(this.WIDTH_WINDOW, this.HEIGHT_WINDOW, Inter.Linear, false).Bitmap;
                    }
                }
                else
                {
                    this.sujetoIdentificado = "No Hay Rostro";
                    this.pbImagenOriginal.Image = frameBgr.Resize(this.WIDTH_WINDOW, this.HEIGHT_WINDOW, Inter.Linear, false).Bitmap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo .:. testItFragmentFactor4");
            }
        }
        public void trainingDataFactor4()
        {
            this.fragmentImageFactor4(ref dataTrain);
            //calculateDescriptorsHOG(dataTrain, ref dataTrainHOG, out sizeDescriptor, out countDescriptors);
            this.calculateFragmentDescriptorsHOGFactor4(ref dataRoi1, ref dataRoi1HOG);
            this.calculateFragmentDescriptorsHOGFactor4(ref dataRoi2, ref dataRoi2HOG);
            this.calculateFragmentDescriptorsHOGFactor4(ref dataRoi3, ref dataRoi3HOG);
            this.calculateFragmentDescriptorsHOGFactor4(ref dataRoi4, ref dataRoi4HOG);
           
            //dataTrainMat = new Mat(new Size(sizeDescriptor, countDescriptors), DepthType.Cv32F, 1); //	Mat(Size, DepthType, Int32)
            this.dataRoi1Mat = new Mat(new Size(dataRoi1HOG[0].Count(), dataRoi1HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi2Mat = new Mat(new Size(dataRoi2HOG[0].Count(), dataRoi2HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi3Mat = new Mat(new Size(dataRoi3HOG[0].Count(), dataRoi3HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi4Mat = new Mat(new Size(dataRoi4HOG[0].Count(), dataRoi4HOG.Count()), DepthType.Cv32F, 1);

            //convertVectorToMatrix(ref dataTrainMat, dataTrainHOG);
            this.convertFragmentVectorToMatrixFactor4(ref dataRoi1Mat, dataRoi1HOG);
            this.convertFragmentVectorToMatrixFactor4(ref dataRoi2Mat, dataRoi2HOG);
            this.convertFragmentVectorToMatrixFactor4(ref dataRoi3Mat, dataRoi3HOG);
            this.convertFragmentVectorToMatrixFactor4(ref dataRoi4Mat, dataRoi4HOG);
   
            //model = training(dataTrainMat, labelTrain);
            modelRoi1 = this.trainingFragmentFactor4(dataRoi1Mat, labelTrain);
            modelRoi2 = this.trainingFragmentFactor4(dataRoi2Mat, labelTrain);
            modelRoi3 = this.trainingFragmentFactor4(dataRoi3Mat, labelTrain);
            modelRoi4 = this.trainingFragmentFactor4(dataRoi4Mat, labelTrain);
        }

        //Fragmentación por 16
        public void fragmentImageFactor16(ref List<Mat> data)
        {

            int jump = 16;
            dataRoi1 = new List<Mat>();
            dataRoi2 = new List<Mat>();
            dataRoi3 = new List<Mat>();
            dataRoi4 = new List<Mat>();
            dataRoi5 = new List<Mat>();
            dataRoi6 = new List<Mat>();
            dataRoi7 = new List<Mat>();
            dataRoi8 = new List<Mat>();
            dataRoi9 = new List<Mat>();
            dataRoi10 = new List<Mat>();
            dataRoi11 = new List<Mat>();
            dataRoi12 = new List<Mat>();
            dataRoi13 = new List<Mat>();
            dataRoi14 = new List<Mat>();
            dataRoi15 = new List<Mat>();
            dataRoi16 = new List<Mat>();

            Image<Gray, Byte> roiAux;
            try
            {
                foreach (Mat face in data)
                {

                    Image<Gray, Byte> img = face.ToImage<Gray, Byte>();
                    Rectangle roi1 = new Rectangle(jump * 0, jump * 0, jump, jump); //1,1
                    Rectangle roi2 = new Rectangle(jump * 1, jump * 0, jump, jump); //1,2
                    Rectangle roi3 = new Rectangle(jump * 2, jump * 0, jump, jump); //1,3
                    Rectangle roi4 = new Rectangle(jump * 3, jump * 0, jump, jump); //1,4

                    Rectangle roi5 = new Rectangle(jump * 0, jump * 1, jump, jump); //2,1
                    Rectangle roi6 = new Rectangle(jump * 1, jump * 1, jump, jump); //2,2
                    Rectangle roi7 = new Rectangle(jump * 2, jump * 1, jump, jump); //2,3
                    Rectangle roi8 = new Rectangle(jump * 3, jump * 1, jump, jump); //2,4

                    Rectangle roi9 = new Rectangle(jump * 0, jump * 2, jump, jump); //3,1
                    Rectangle roi10 = new Rectangle(jump * 1, jump * 2, jump, jump); //3,2
                    Rectangle roi11 = new Rectangle(jump * 2, jump * 2, jump, jump); //3,3
                    Rectangle roi12 = new Rectangle(jump * 3, jump * 2, jump, jump); //3,4

                    Rectangle roi13 = new Rectangle(jump * 0, jump * 3, jump, jump); //4,1
                    Rectangle roi14 = new Rectangle(jump * 1, jump * 3, jump, jump); //4,2
                    Rectangle roi15 = new Rectangle(jump * 2, jump * 3, jump, jump); //4,3
                    Rectangle roi16 = new Rectangle(jump * 3, jump * 3, jump, jump); //4,4

                    roiAux = img.Copy(roi1);
                    dataRoi1.Add(roiAux.Mat);

                    roiAux = img.Copy(roi2);
                    dataRoi2.Add(roiAux.Mat);

                    roiAux = img.Copy(roi3);
                    dataRoi3.Add(roiAux.Mat);

                    roiAux = img.Copy(roi4);
                    dataRoi4.Add(roiAux.Mat);

                    roiAux = img.Copy(roi5);
                    dataRoi5.Add(roiAux.Mat);

                    roiAux = img.Copy(roi6);
                    dataRoi6.Add(roiAux.Mat);

                    roiAux = img.Copy(roi7);
                    dataRoi7.Add(roiAux.Mat);

                    roiAux = img.Copy(roi8);
                    dataRoi8.Add(roiAux.Mat);

                    roiAux = img.Copy(roi9);
                    dataRoi9.Add(roiAux.Mat);

                    roiAux = img.Copy(roi10);
                    dataRoi10.Add(roiAux.Mat);

                    roiAux = img.Copy(roi11);
                    dataRoi11.Add(roiAux.Mat);

                    roiAux = img.Copy(roi12);
                    dataRoi12.Add(roiAux.Mat);

                    roiAux = img.Copy(roi13);
                    dataRoi13.Add(roiAux.Mat);

                    roiAux = img.Copy(roi14);
                    dataRoi14.Add(roiAux.Mat);

                    roiAux = img.Copy(roi15);
                    dataRoi15.Add(roiAux.Mat);

                    roiAux = img.Copy(roi16);
                    dataRoi16.Add(roiAux.Mat);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo .:. fragmentImage");
            }
        }
        public void calculateFragmentDescriptorsHOGFactor16(ref List<Mat> dataTrain, ref List<List<float>> dataTrainHOG)
        {
            //HOGDescriptor(Size winSize, Size blockSize, Size blockStride, Size cellSize, int nbins = 9, int derivAperture = 1, double winSigma = -1, double L2HysThreshold = 0.2, bool gammaCorrection = true);
            HOGDescriptor HOG = new HOGDescriptor(new Size(16, 16), new Size(8, 8), new Size(4, 4), new Size(4, 4), 9, 1, -1, 0.2, true);
            dataTrainHOG = new List<List<float>>();
            //Aplicar por imagen de entrenamiento el descriptor HOG
            try
            {
                float[] descriptor;
                for (int y = 0; y < dataTrain.Count; y++)
                {
                    List<float> descriptors = new List<float>();
                    Image<Gray, Byte> imgByte = (dataTrain.ElementAt(y)).ToImage<Gray, Byte>();
                    descriptor = HOG.Compute(imgByte, new Size(8, 8), new Size(0, 0), null); 
                    descriptors = descriptor.OfType<float>().ToList();
                    dataTrainHOG.Add(descriptors);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror: " + ex.Message, "Módulo .:. calculateDescriptorsHOG");
            }
        }
        public void convertFragmentVectorToMatrixFactor16(ref Mat dataTrainMat, List<List<float>> dataTrainHOG)
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

                        matrizMat[i, j] = (float)dataTrainHOG[i].ElementAt(j);
                    }
                }
                //Volcar los datos procesados al objeto dataTrainMat
                matrizMat.Mat.CopyTo(dataTrainMat);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo .:. convertVectorToMatrix");
            }
        }
        public SVM trainingFragmentFactor16(Mat dataTrainMat, Matrix<int> labelTrain)
        {
            //Creación del SVM
            //Definición de parámetros
            SVM model = new SVM();
            model.C = this.C;//100;
            model.Type = SVM.SvmType.CSvc;
            model.Coef0 = this.coef0;
            model.Degree = this.degree;
            model.Nu = this.nu;
            model.P = this.P;
            model.Gamma = this.gamma;//0.005
            model.SetKernel(SVM.SvmKernelType.Linear);
            model.TermCriteria = new MCvTermCriteria(1000, 1e-6);
            model.Train(dataTrainMat, Emgu.CV.ML.MlEnum.DataLayoutType.RowSample, labelTrain);
            //model.Save("model_svm.txt");

            return model;
        }
        public void testItFragmentFactor16(IImage frame)
        {
            List<Mat> dataTest = new List<Mat>();
            List<List<float>> dataTestHOG = new List<List<float>>();

            UMat frameGray = new UMat();
            List<Face> faceDetected = new List<Face>();

            CvInvoke.CvtColor(frame, frameGray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            Image<Bgr, Byte> frameBgr = new Image<Bgr, Byte>(frame.Bitmap);

            faceDetected = detectFaces(frameGray.ToImage<Gray, Byte>().Resize(this.WIDTH_FRAME_CAMERA, this.HEIGHT_FRAME_CAMERA, Inter.Linear, false)); //Encuentra una lista de rostros hallados en el frame.
            dataTest = preProcessingDataTest(faceDetected); //Realiza una preprocesado a todos los rostros hallados.

            this.fragmentImageFactor16(ref dataTest);
            //SSi encuentra al menos un rostro
            if (dataTest.Count() >= 1)
            {
                //calculateDescriptorsHOG(dataTest, ref dataTestHOG, out sizeDescriptor, out countDescriptors);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi1, ref dataRoi1HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi2, ref dataRoi2HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi3, ref dataRoi3HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi4, ref dataRoi4HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi5, ref dataRoi5HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi6, ref dataRoi6HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi7, ref dataRoi7HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi8, ref dataRoi8HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi9, ref dataRoi9HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi10, ref dataRoi10HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi11, ref dataRoi11HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi12, ref dataRoi12HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi13, ref dataRoi13HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi14, ref dataRoi14HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi15, ref dataRoi15HOG);
                this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi16, ref dataRoi16HOG);

                //Mat dataTestMat = new Mat(new Size(sizeDescriptor, countDescriptors), DepthType.Cv32F, 1); //	Mat(Size, DepthType, Int32)
                this.dataRoi1Mat = new Mat(new Size(dataRoi1HOG[0].Count(), dataRoi1HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi2Mat = new Mat(new Size(dataRoi2HOG[0].Count(), dataRoi2HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi3Mat = new Mat(new Size(dataRoi3HOG[0].Count(), dataRoi3HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi4Mat = new Mat(new Size(dataRoi4HOG[0].Count(), dataRoi4HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi5Mat = new Mat(new Size(dataRoi5HOG[0].Count(), dataRoi5HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi6Mat = new Mat(new Size(dataRoi6HOG[0].Count(), dataRoi6HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi7Mat = new Mat(new Size(dataRoi7HOG[0].Count(), dataRoi7HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi8Mat = new Mat(new Size(dataRoi8HOG[0].Count(), dataRoi8HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi9Mat = new Mat(new Size(dataRoi9HOG[0].Count(), dataRoi9HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi10Mat = new Mat(new Size(dataRoi10HOG[0].Count(), dataRoi10HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi11Mat = new Mat(new Size(dataRoi11HOG[0].Count(), dataRoi11HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi12Mat = new Mat(new Size(dataRoi12HOG[0].Count(), dataRoi12HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi13Mat = new Mat(new Size(dataRoi13HOG[0].Count(), dataRoi13HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi14Mat = new Mat(new Size(dataRoi14HOG[0].Count(), dataRoi14HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi15Mat = new Mat(new Size(dataRoi15HOG[0].Count(), dataRoi15HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi16Mat = new Mat(new Size(dataRoi16HOG[0].Count(), dataRoi16HOG.Count()), DepthType.Cv32F, 1);
                //convertVectorToMatrix(ref dataTestMat, dataTestHOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi1Mat, dataRoi1HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi2Mat, dataRoi2HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi3Mat, dataRoi3HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi4Mat, dataRoi4HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi5Mat, dataRoi5HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi6Mat, dataRoi6HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi7Mat, dataRoi7HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi8Mat, dataRoi8HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi9Mat, dataRoi9HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi10Mat, dataRoi10HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi11Mat, dataRoi11HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi12Mat, dataRoi12HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi13Mat, dataRoi13HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi14Mat, dataRoi14HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi15Mat, dataRoi15HOG);
                this.convertFragmentVectorToMatrixFactor16(ref dataRoi16Mat, dataRoi16HOG);
                for (int numPerson = 0; numPerson < faceDetected.Count(); numPerson++)
                {
                    //Indicar la fila ha predecir
                    this.acumuladorPrediccion( (int) modelRoi1.Predict(dataRoi1Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi2.Predict(dataRoi2Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi3.Predict(dataRoi3Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi4.Predict(dataRoi4Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi5.Predict(dataRoi5Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi6.Predict(dataRoi6Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi7.Predict(dataRoi7Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi8.Predict(dataRoi8Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi9.Predict(dataRoi9Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi10.Predict(dataRoi10Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi11.Predict(dataRoi11Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi12.Predict(dataRoi12Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi13.Predict(dataRoi13Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi14.Predict(dataRoi14Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi15.Predict(dataRoi15Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi16.Predict(dataRoi16Mat.Row(numPerson)) );

                    int resultado = this.evaluationPredictionFactor16();
                    if (resultado == 0) resultado = this.evaluationPrediction2Factor16();
                    if (resultado != 0)
                    {
                        Person sujeto = listPersons[resultado];
                        Face face = faceDetected.ElementAt(numPerson);
                        //Pintar y etiquetar
                        string nombre = listSearch[resultado];
                        CvInvoke.Rectangle(frameBgr, face.Roi, new MCvScalar(0, 0, 255));
                        this.sujetoIdentificado = sujeto.Nombre;
                    }
                    else
                    {
                        Console.WriteLine("No fue posible identificar la muesta ingresada");
                        this.sujetoIdentificado = "No Identificado";
                    }
                    this.limpiarAcumuladorPrediccion();
                    pbImagenOriginal.Image = frameBgr.Bitmap;
                }
            }
            else
            {
                pbImagenOriginal.Image = frameBgr.Bitmap;
            }
        }
        public void trainingDataFactor16()
        {
            this.fragmentImageFactor16(ref dataTrain);
            //calculateDescriptorsHOG(dataTrain, ref dataTrainHOG, out sizeDescriptor, out countDescriptors);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi1, ref dataRoi1HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi2, ref dataRoi2HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi3, ref dataRoi3HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi4, ref dataRoi4HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi5, ref dataRoi5HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi6, ref dataRoi6HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi7, ref dataRoi7HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi8, ref dataRoi8HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi9, ref dataRoi9HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi10, ref dataRoi10HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi11, ref dataRoi11HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi12, ref dataRoi12HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi13, ref dataRoi13HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi14, ref dataRoi14HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi15, ref dataRoi15HOG);
            this.calculateFragmentDescriptorsHOGFactor16(ref dataRoi16, ref dataRoi16HOG);
            //dataTrainMat = new Mat(new Size(sizeDescriptor, countDescriptors), DepthType.Cv32F, 1); //	Mat(Size, DepthType, Int32)
            this.dataRoi1Mat = new Mat(new Size(dataRoi1HOG[0].Count(), dataRoi1HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi2Mat = new Mat(new Size(dataRoi2HOG[0].Count(), dataRoi2HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi3Mat = new Mat(new Size(dataRoi3HOG[0].Count(), dataRoi3HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi4Mat = new Mat(new Size(dataRoi4HOG[0].Count(), dataRoi4HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi5Mat = new Mat(new Size(dataRoi5HOG[0].Count(), dataRoi5HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi6Mat = new Mat(new Size(dataRoi6HOG[0].Count(), dataRoi6HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi7Mat = new Mat(new Size(dataRoi7HOG[0].Count(), dataRoi7HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi8Mat = new Mat(new Size(dataRoi8HOG[0].Count(), dataRoi8HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi9Mat = new Mat(new Size(dataRoi9HOG[0].Count(), dataRoi9HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi10Mat = new Mat(new Size(dataRoi10HOG[0].Count(), dataRoi10HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi11Mat = new Mat(new Size(dataRoi11HOG[0].Count(), dataRoi11HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi12Mat = new Mat(new Size(dataRoi12HOG[0].Count(), dataRoi12HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi13Mat = new Mat(new Size(dataRoi13HOG[0].Count(), dataRoi13HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi14Mat = new Mat(new Size(dataRoi14HOG[0].Count(), dataRoi14HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi15Mat = new Mat(new Size(dataRoi15HOG[0].Count(), dataRoi15HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi16Mat = new Mat(new Size(dataRoi16HOG[0].Count(), dataRoi16HOG.Count()), DepthType.Cv32F, 1);
            //convertVectorToMatrix(ref dataTrainMat, dataTrainHOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi1Mat, dataRoi1HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi2Mat, dataRoi2HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi3Mat, dataRoi3HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi4Mat, dataRoi4HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi5Mat, dataRoi5HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi6Mat, dataRoi6HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi7Mat, dataRoi7HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi8Mat, dataRoi8HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi9Mat, dataRoi9HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi10Mat, dataRoi10HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi11Mat, dataRoi11HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi12Mat, dataRoi12HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi13Mat, dataRoi13HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi14Mat, dataRoi14HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi15Mat, dataRoi15HOG);
            this.convertFragmentVectorToMatrixFactor16(ref dataRoi16Mat, dataRoi16HOG);
            //model = training(dataTrainMat, labelTrain);
            modelRoi1 = this.trainingFragmentFactor16(dataRoi1Mat, labelTrain);
            modelRoi2 = this.trainingFragmentFactor16(dataRoi2Mat, labelTrain);
            modelRoi3 = this.trainingFragmentFactor16(dataRoi3Mat, labelTrain);
            modelRoi4 = this.trainingFragmentFactor16(dataRoi4Mat, labelTrain);
            modelRoi5 = this.trainingFragmentFactor16(dataRoi5Mat, labelTrain);
            modelRoi6 = this.trainingFragmentFactor16(dataRoi6Mat, labelTrain);
            modelRoi7 = this.trainingFragmentFactor16(dataRoi7Mat, labelTrain);
            modelRoi8 = this.trainingFragmentFactor16(dataRoi8Mat, labelTrain);
            modelRoi9 = this.trainingFragmentFactor16(dataRoi9Mat, labelTrain);
            modelRoi10 = this.trainingFragmentFactor16(dataRoi10Mat, labelTrain);
            modelRoi11 = this.trainingFragmentFactor16(dataRoi11Mat, labelTrain);
            modelRoi12 = this.trainingFragmentFactor16(dataRoi12Mat, labelTrain);
            modelRoi13 = this.trainingFragmentFactor16(dataRoi13Mat, labelTrain);
            modelRoi14 = this.trainingFragmentFactor16(dataRoi14Mat, labelTrain);
            modelRoi15 = this.trainingFragmentFactor16(dataRoi15Mat, labelTrain);
            modelRoi16 = this.trainingFragmentFactor16(dataRoi16Mat, labelTrain);
        }

        //Fragmentación por 64
        public void fragmentImageFactor64(ref List<Mat> data)
        {

            int jump = 8;
            dataRoi1 = new List<Mat>();
            dataRoi2 = new List<Mat>();
            dataRoi3 = new List<Mat>();
            dataRoi4 = new List<Mat>();
            dataRoi5 = new List<Mat>();
            dataRoi6 = new List<Mat>();
            dataRoi7 = new List<Mat>();
            dataRoi8 = new List<Mat>();
            dataRoi9 = new List<Mat>();
            dataRoi10 = new List<Mat>();
            dataRoi11 = new List<Mat>();
            dataRoi12 = new List<Mat>();
            dataRoi13 = new List<Mat>();
            dataRoi14 = new List<Mat>();
            dataRoi15 = new List<Mat>();
            dataRoi16 = new List<Mat>();
            dataRoi17 = new List<Mat>();
            dataRoi18 = new List<Mat>();
            dataRoi19 = new List<Mat>();
            dataRoi20 = new List<Mat>();
            dataRoi21 = new List<Mat>();
            dataRoi22 = new List<Mat>();
            dataRoi23 = new List<Mat>();
            dataRoi24 = new List<Mat>();
            dataRoi25 = new List<Mat>();
            dataRoi26 = new List<Mat>();
            dataRoi27 = new List<Mat>();
            dataRoi28 = new List<Mat>();
            dataRoi29 = new List<Mat>();
            dataRoi30 = new List<Mat>();
            dataRoi31 = new List<Mat>();
            dataRoi32 = new List<Mat>();
            dataRoi33 = new List<Mat>();
            dataRoi34 = new List<Mat>();
            dataRoi35 = new List<Mat>();
            dataRoi36 = new List<Mat>();
            dataRoi37 = new List<Mat>();
            dataRoi38 = new List<Mat>();
            dataRoi39 = new List<Mat>();
            dataRoi40 = new List<Mat>();
            dataRoi41 = new List<Mat>();
            dataRoi42 = new List<Mat>();
            dataRoi43 = new List<Mat>();
            dataRoi44 = new List<Mat>();
            dataRoi45 = new List<Mat>();
            dataRoi46 = new List<Mat>();
            dataRoi47 = new List<Mat>();
            dataRoi48 = new List<Mat>();
            dataRoi49 = new List<Mat>();
            dataRoi50 = new List<Mat>();
            dataRoi51 = new List<Mat>();
            dataRoi52 = new List<Mat>();
            dataRoi53 = new List<Mat>();
            dataRoi54 = new List<Mat>();
            dataRoi55 = new List<Mat>();
            dataRoi56 = new List<Mat>();
            dataRoi57 = new List<Mat>();
            dataRoi58 = new List<Mat>();
            dataRoi59 = new List<Mat>();
            dataRoi60 = new List<Mat>();
            dataRoi61 = new List<Mat>();
            dataRoi62 = new List<Mat>();
            dataRoi63 = new List<Mat>();
            dataRoi64 = new List<Mat>();
            Image <Gray, Byte> roiAux;
            try
            {
                foreach (Mat face in data)
                {

                    Image<Gray, Byte> img = face.ToImage<Gray, Byte>();
                    Rectangle roi1 = new Rectangle(jump * 0, jump * 0, jump, jump); //1,1
                    Rectangle roi2 = new Rectangle(jump * 1, jump * 0, jump, jump); //1,2
                    Rectangle roi3 = new Rectangle(jump * 2, jump * 0, jump, jump); //1,3
                    Rectangle roi4 = new Rectangle(jump * 3, jump * 0, jump, jump); //1,4
                    Rectangle roi5 = new Rectangle(jump * 4, jump * 0, jump, jump); //1,5
                    Rectangle roi6 = new Rectangle(jump * 5, jump * 0, jump, jump); //1,6
                    Rectangle roi7 = new Rectangle(jump * 6, jump * 0, jump, jump); //1,7
                    Rectangle roi8 = new Rectangle(jump * 7, jump * 0, jump, jump); //1,8

                    Rectangle roi9 = new Rectangle(jump * 0, jump * 1, jump, jump); //2,1
                    Rectangle roi10 = new Rectangle(jump * 1, jump * 1, jump, jump); //2,2
                    Rectangle roi11 = new Rectangle(jump * 2, jump * 1, jump, jump); //2,3
                    Rectangle roi12 = new Rectangle(jump * 3, jump * 1, jump, jump); //2,4
                    Rectangle roi13 = new Rectangle(jump * 4, jump * 1, jump, jump); //2,5
                    Rectangle roi14 = new Rectangle(jump * 5, jump * 1, jump, jump); //2,6
                    Rectangle roi15 = new Rectangle(jump * 6, jump * 1, jump, jump); //2,7
                    Rectangle roi16 = new Rectangle(jump * 7, jump * 1, jump, jump); //2,8

                    Rectangle roi17 = new Rectangle(jump * 0, jump * 2, jump, jump); //3,1
                    Rectangle roi18 = new Rectangle(jump * 1, jump * 2, jump, jump); //3,2
                    Rectangle roi19 = new Rectangle(jump * 2, jump * 2, jump, jump); //3,3
                    Rectangle roi20 = new Rectangle(jump * 3, jump * 2, jump, jump); //3,4
                    Rectangle roi21 = new Rectangle(jump * 4, jump * 2, jump, jump); //3,5
                    Rectangle roi22 = new Rectangle(jump * 5, jump * 2, jump, jump); //3,6
                    Rectangle roi23 = new Rectangle(jump * 6, jump * 2, jump, jump); //3,7
                    Rectangle roi24 = new Rectangle(jump * 7, jump * 2, jump, jump); //3,8

                    Rectangle roi25 = new Rectangle(jump * 0, jump * 3, jump, jump); //4,1
                    Rectangle roi26 = new Rectangle(jump * 1, jump * 3, jump, jump); //4,2
                    Rectangle roi27 = new Rectangle(jump * 2, jump * 3, jump, jump); //4,3
                    Rectangle roi28 = new Rectangle(jump * 3, jump * 3, jump, jump); //4,4
                    Rectangle roi29 = new Rectangle(jump * 4, jump * 3, jump, jump); //4,5
                    Rectangle roi30 = new Rectangle(jump * 5, jump * 3, jump, jump); //4,6
                    Rectangle roi31 = new Rectangle(jump * 6, jump * 3, jump, jump); //4,7
                    Rectangle roi32 = new Rectangle(jump * 7, jump * 3, jump, jump); //4,8

                    Rectangle roi33 = new Rectangle(jump * 0, jump * 4, jump, jump); //5,1
                    Rectangle roi34 = new Rectangle(jump * 1, jump * 4, jump, jump); //5,2
                    Rectangle roi35 = new Rectangle(jump * 2, jump * 4, jump, jump); //5,3
                    Rectangle roi36 = new Rectangle(jump * 3, jump * 4, jump, jump); //5,4
                    Rectangle roi37 = new Rectangle(jump * 4, jump * 4, jump, jump); //5,5
                    Rectangle roi38 = new Rectangle(jump * 5, jump * 4, jump, jump); //5,6
                    Rectangle roi39 = new Rectangle(jump * 6, jump * 4, jump, jump); //5,7
                    Rectangle roi40 = new Rectangle(jump * 7, jump * 4, jump, jump); //5,8

                    Rectangle roi41 = new Rectangle(jump * 0, jump * 5, jump, jump); //6,1
                    Rectangle roi42 = new Rectangle(jump * 1, jump * 5, jump, jump); //6,2
                    Rectangle roi43 = new Rectangle(jump * 2, jump * 5, jump, jump); //6,3
                    Rectangle roi44 = new Rectangle(jump * 3, jump * 5, jump, jump); //6,4
                    Rectangle roi45 = new Rectangle(jump * 4, jump * 5, jump, jump); //6,5
                    Rectangle roi46 = new Rectangle(jump * 5, jump * 5, jump, jump); //6,6
                    Rectangle roi47 = new Rectangle(jump * 6, jump * 5, jump, jump); //6,7
                    Rectangle roi48 = new Rectangle(jump * 7, jump * 5, jump, jump); //6,8

                    Rectangle roi49 = new Rectangle(jump * 0, jump * 6, jump, jump); //7,1
                    Rectangle roi50 = new Rectangle(jump * 1, jump * 6, jump, jump); //7,2
                    Rectangle roi51 = new Rectangle(jump * 2, jump * 6, jump, jump); //7,3
                    Rectangle roi52 = new Rectangle(jump * 3, jump * 6, jump, jump); //7,4
                    Rectangle roi53 = new Rectangle(jump * 4, jump * 6, jump, jump); //7,5
                    Rectangle roi54 = new Rectangle(jump * 5, jump * 6, jump, jump); //7,6
                    Rectangle roi55 = new Rectangle(jump * 6, jump * 6, jump, jump); //7,7
                    Rectangle roi56 = new Rectangle(jump * 7, jump * 6, jump, jump); //7,8

                    Rectangle roi57 = new Rectangle(jump * 0, jump * 7, jump, jump); //8,1
                    Rectangle roi58 = new Rectangle(jump * 1, jump * 7, jump, jump); //8,2
                    Rectangle roi59 = new Rectangle(jump * 2, jump * 7, jump, jump); //8,3
                    Rectangle roi60 = new Rectangle(jump * 3, jump * 7, jump, jump); //8,4
                    Rectangle roi61 = new Rectangle(jump * 4, jump * 7, jump, jump); //8,5
                    Rectangle roi62 = new Rectangle(jump * 5, jump * 7, jump, jump); //8,6
                    Rectangle roi63 = new Rectangle(jump * 6, jump * 7, jump, jump); //8,7
                    Rectangle roi64 = new Rectangle(jump * 7, jump * 7, jump, jump); //8,8

                    roiAux = img.Copy(roi1);
                    dataRoi1.Add(roiAux.Mat);

                    roiAux = img.Copy(roi2);
                    dataRoi2.Add(roiAux.Mat);

                    roiAux = img.Copy(roi3);
                    dataRoi3.Add(roiAux.Mat);

                    roiAux = img.Copy(roi4);
                    dataRoi4.Add(roiAux.Mat);

                    roiAux = img.Copy(roi5);
                    dataRoi5.Add(roiAux.Mat);

                    roiAux = img.Copy(roi6);
                    dataRoi6.Add(roiAux.Mat);

                    roiAux = img.Copy(roi7);
                    dataRoi7.Add(roiAux.Mat);

                    roiAux = img.Copy(roi8);
                    dataRoi8.Add(roiAux.Mat);

                    roiAux = img.Copy(roi9);
                    dataRoi9.Add(roiAux.Mat);

                    roiAux = img.Copy(roi10);
                    dataRoi10.Add(roiAux.Mat);

                    roiAux = img.Copy(roi11);
                    dataRoi11.Add(roiAux.Mat);

                    roiAux = img.Copy(roi12);
                    dataRoi12.Add(roiAux.Mat);

                    roiAux = img.Copy(roi13);
                    dataRoi13.Add(roiAux.Mat);

                    roiAux = img.Copy(roi14);
                    dataRoi14.Add(roiAux.Mat);

                    roiAux = img.Copy(roi15);
                    dataRoi15.Add(roiAux.Mat);

                    roiAux = img.Copy(roi16);
                    dataRoi16.Add(roiAux.Mat);

                    roiAux = img.Copy(roi17);
                    dataRoi17.Add(roiAux.Mat);

                    roiAux = img.Copy(roi18);
                    dataRoi18.Add(roiAux.Mat);

                    roiAux = img.Copy(roi19);
                    dataRoi19.Add(roiAux.Mat);

                    roiAux = img.Copy(roi20);
                    dataRoi20.Add(roiAux.Mat);

                    roiAux = img.Copy(roi21);
                    dataRoi21.Add(roiAux.Mat);

                    roiAux = img.Copy(roi22);
                    dataRoi22.Add(roiAux.Mat);

                    roiAux = img.Copy(roi23);
                    dataRoi23.Add(roiAux.Mat);

                    roiAux = img.Copy(roi24);
                    dataRoi24.Add(roiAux.Mat);

                    roiAux = img.Copy(roi25);
                    dataRoi25.Add(roiAux.Mat);

                    roiAux = img.Copy(roi26);
                    dataRoi26.Add(roiAux.Mat);

                    roiAux = img.Copy(roi27);
                    dataRoi27.Add(roiAux.Mat);

                    roiAux = img.Copy(roi28);
                    dataRoi28.Add(roiAux.Mat);

                    roiAux = img.Copy(roi29);
                    dataRoi29.Add(roiAux.Mat);

                    roiAux = img.Copy(roi30);
                    dataRoi30.Add(roiAux.Mat);

                    roiAux = img.Copy(roi31);
                    dataRoi31.Add(roiAux.Mat);

                    roiAux = img.Copy(roi32);
                    dataRoi32.Add(roiAux.Mat);

                    roiAux = img.Copy(roi33);
                    dataRoi33.Add(roiAux.Mat);

                    roiAux = img.Copy(roi34);
                    dataRoi34.Add(roiAux.Mat);

                    roiAux = img.Copy(roi35);
                    dataRoi35.Add(roiAux.Mat);

                    roiAux = img.Copy(roi36);
                    dataRoi36.Add(roiAux.Mat);

                    roiAux = img.Copy(roi37);
                    dataRoi37.Add(roiAux.Mat);

                    roiAux = img.Copy(roi38);
                    dataRoi38.Add(roiAux.Mat);

                    roiAux = img.Copy(roi39);
                    dataRoi39.Add(roiAux.Mat);

                    roiAux = img.Copy(roi40);
                    dataRoi40.Add(roiAux.Mat);

                    roiAux = img.Copy(roi41);
                    dataRoi41.Add(roiAux.Mat);

                    roiAux = img.Copy(roi42);
                    dataRoi42.Add(roiAux.Mat);

                    roiAux = img.Copy(roi43);
                    dataRoi43.Add(roiAux.Mat);

                    roiAux = img.Copy(roi44);
                    dataRoi44.Add(roiAux.Mat);

                    roiAux = img.Copy(roi45);
                    dataRoi45.Add(roiAux.Mat);

                    roiAux = img.Copy(roi46);
                    dataRoi46.Add(roiAux.Mat);

                    roiAux = img.Copy(roi47);
                    dataRoi47.Add(roiAux.Mat);

                    roiAux = img.Copy(roi48);
                    dataRoi48.Add(roiAux.Mat);

                    roiAux = img.Copy(roi49);
                    dataRoi49.Add(roiAux.Mat);

                    roiAux = img.Copy(roi50);
                    dataRoi50.Add(roiAux.Mat);

                    roiAux = img.Copy(roi51);
                    dataRoi51.Add(roiAux.Mat);

                    roiAux = img.Copy(roi52);
                    dataRoi52.Add(roiAux.Mat);

                    roiAux = img.Copy(roi53);
                    dataRoi53.Add(roiAux.Mat);

                    roiAux = img.Copy(roi54);
                    dataRoi54.Add(roiAux.Mat);

                    roiAux = img.Copy(roi55);
                    dataRoi55.Add(roiAux.Mat);

                    roiAux = img.Copy(roi56);
                    dataRoi56.Add(roiAux.Mat);

                    roiAux = img.Copy(roi57);
                    dataRoi57.Add(roiAux.Mat);

                    roiAux = img.Copy(roi58);
                    dataRoi58.Add(roiAux.Mat);

                    roiAux = img.Copy(roi59);
                    dataRoi59.Add(roiAux.Mat);

                    roiAux = img.Copy(roi60);
                    dataRoi60.Add(roiAux.Mat);

                    roiAux = img.Copy(roi61);
                    dataRoi61.Add(roiAux.Mat);

                    roiAux = img.Copy(roi62);
                    dataRoi62.Add(roiAux.Mat);

                    roiAux = img.Copy(roi63);
                    dataRoi63.Add(roiAux.Mat);

                    roiAux = img.Copy(roi64);
                    dataRoi64.Add(roiAux.Mat);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo .:. fragmentImage");
            }
        }
        public void calculateFragmentDescriptorsHOGFactor64(ref List<Mat> dataTrain, ref List<List<float>> dataTrainHOG)
        {
            //HOGDescriptor(Size winSize, Size blockSize, Size blockStride, Size cellSize, int nbins = 9, int derivAperture = 1, double winSigma = -1, double L2HysThreshold = 0.2, bool gammaCorrection = true);
            HOGDescriptor HOG = new HOGDescriptor(new Size(8, 8), new Size(4, 4), new Size(2, 2), new Size(2, 2), 9, 1, -1, 0.2, true);
            dataTrainHOG = new List<List<float>>();
            //Aplicar por imagen de entrenamiento el descriptor HOG
            try
            {
                float[] descriptor;
                for (int y = 0; y < dataTrain.Count; y++)
                {
                    List<float> descriptors = new List<float>();
                    Image<Gray, Byte> imgByte = (dataTrain.ElementAt(y)).ToImage<Gray, Byte>();
                    descriptor = HOG.Compute(imgByte, new Size(4, 4), new Size(0, 0), null);
                    descriptors = descriptor.OfType<float>().ToList();
                    dataTrainHOG.Add(descriptors);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror: " + ex.Message, "Módulo .:. calculateDescriptorsHOG");
            }
        }
        public void convertFragmentVectorToMatrixFactor64(ref Mat dataTrainMat, List<List<float>> dataTrainHOG)
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

                        matrizMat[i, j] = (float)dataTrainHOG[i].ElementAt(j);
                    }
                }
                //Volcar los datos procesados al objeto dataTrainMat
                matrizMat.Mat.CopyTo(dataTrainMat);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Módulo .:. convertVectorToMatrix");
            }
        }
        public SVM trainingFragmentFactor64(Mat dataTrainMat, Matrix<int> labelTrain)
        {
            //Creación del SVM
            //Definición de parámetros
            SVM model = new SVM();
            model.C = this.C;//100
            model.Type = SVM.SvmType.CSvc;
            model.Coef0 = this.coef0;
            model.Degree = this.degree;
            model.Nu = this.nu;
            model.P = this.P;
            model.Gamma = this.gamma;//0.005
            model.SetKernel(SVM.SvmKernelType.Linear);
            model.TermCriteria = new MCvTermCriteria(1000, 1e-6);
            model.Train(dataTrainMat, Emgu.CV.ML.MlEnum.DataLayoutType.RowSample, labelTrain);
            //model.Save("model_svm.txt");

            return model;
        }
        public void testItFragmentFactor64(IImage frame)
        {
            List<Mat> dataTest = new List<Mat>();
            List<List<float>> dataTestHOG = new List<List<float>>();

            UMat frameGray = new UMat();
            List<Face> faceDetected = new List<Face>();

            CvInvoke.CvtColor(frame, frameGray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            Image<Bgr, Byte> frameBgr = new Image<Bgr, Byte>(frame.Bitmap);

            faceDetected = detectFaces(frameGray.ToImage<Gray, Byte>().Resize(this.WIDTH_FRAME_CAMERA, this.HEIGHT_FRAME_CAMERA, Inter.Linear, false)); //Encuentra una lista de rostros hallados en el frame.
            dataTest = preProcessingDataTest(faceDetected); //Realiza una preprocesado a todos los rostros hallados.

            this.fragmentImageFactor64(ref dataTest);
            //SSi encuentra al menos un rostro
            if (dataTest.Count() >= 1)
            {
                //calculateDescriptorsHOG(dataTest, ref dataTestHOG, out sizeDescriptor, out countDescriptors);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi1, ref dataRoi1HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi2, ref dataRoi2HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi3, ref dataRoi3HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi4, ref dataRoi4HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi5, ref dataRoi5HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi6, ref dataRoi6HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi7, ref dataRoi7HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi8, ref dataRoi8HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi9, ref dataRoi9HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi10, ref dataRoi10HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi11, ref dataRoi11HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi12, ref dataRoi12HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi13, ref dataRoi13HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi14, ref dataRoi14HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi15, ref dataRoi15HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi16, ref dataRoi16HOG);

                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi17, ref dataRoi17HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi18, ref dataRoi18HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi19, ref dataRoi19HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi20, ref dataRoi20HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi21, ref dataRoi21HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi22, ref dataRoi22HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi23, ref dataRoi23HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi24, ref dataRoi24HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi25, ref dataRoi25HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi26, ref dataRoi26HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi27, ref dataRoi27HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi28, ref dataRoi28HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi29, ref dataRoi29HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi30, ref dataRoi30HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi31, ref dataRoi31HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi32, ref dataRoi32HOG);

                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi33, ref dataRoi33HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi34, ref dataRoi34HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi35, ref dataRoi35HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi36, ref dataRoi36HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi37, ref dataRoi37HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi38, ref dataRoi38HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi39, ref dataRoi39HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi40, ref dataRoi40HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi41, ref dataRoi41HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi42, ref dataRoi42HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi43, ref dataRoi43HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi44, ref dataRoi44HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi45, ref dataRoi45HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi46, ref dataRoi46HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi47, ref dataRoi47HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi48, ref dataRoi48HOG);

                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi49, ref dataRoi49HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi50, ref dataRoi50HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi51, ref dataRoi51HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi52, ref dataRoi52HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi53, ref dataRoi53HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi54, ref dataRoi54HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi55, ref dataRoi55HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi56, ref dataRoi56HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi57, ref dataRoi57HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi58, ref dataRoi58HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi59, ref dataRoi59HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi60, ref dataRoi60HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi61, ref dataRoi61HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi62, ref dataRoi62HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi63, ref dataRoi63HOG);
                this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi64, ref dataRoi64HOG);

                //Mat dataTestMat = new Mat(new Size(sizeDescriptor, countDescriptors), DepthType.Cv32F, 1); //	Mat(Size, DepthType, Int32)

                this.dataRoi1Mat = new Mat(new Size(dataRoi1HOG[0].Count(), dataRoi1HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi2Mat = new Mat(new Size(dataRoi2HOG[0].Count(), dataRoi2HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi3Mat = new Mat(new Size(dataRoi3HOG[0].Count(), dataRoi3HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi4Mat = new Mat(new Size(dataRoi4HOG[0].Count(), dataRoi4HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi5Mat = new Mat(new Size(dataRoi5HOG[0].Count(), dataRoi5HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi6Mat = new Mat(new Size(dataRoi6HOG[0].Count(), dataRoi6HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi7Mat = new Mat(new Size(dataRoi7HOG[0].Count(), dataRoi7HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi8Mat = new Mat(new Size(dataRoi8HOG[0].Count(), dataRoi8HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi9Mat = new Mat(new Size(dataRoi9HOG[0].Count(), dataRoi9HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi10Mat = new Mat(new Size(dataRoi10HOG[0].Count(), dataRoi10HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi11Mat = new Mat(new Size(dataRoi11HOG[0].Count(), dataRoi11HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi12Mat = new Mat(new Size(dataRoi12HOG[0].Count(), dataRoi12HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi13Mat = new Mat(new Size(dataRoi13HOG[0].Count(), dataRoi13HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi14Mat = new Mat(new Size(dataRoi14HOG[0].Count(), dataRoi14HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi15Mat = new Mat(new Size(dataRoi15HOG[0].Count(), dataRoi15HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi16Mat = new Mat(new Size(dataRoi16HOG[0].Count(), dataRoi16HOG.Count()), DepthType.Cv32F, 1);

                this.dataRoi17Mat = new Mat(new Size(dataRoi17HOG[0].Count(), dataRoi17HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi18Mat = new Mat(new Size(dataRoi18HOG[0].Count(), dataRoi18HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi19Mat = new Mat(new Size(dataRoi19HOG[0].Count(), dataRoi19HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi20Mat = new Mat(new Size(dataRoi20HOG[0].Count(), dataRoi20HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi21Mat = new Mat(new Size(dataRoi21HOG[0].Count(), dataRoi21HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi22Mat = new Mat(new Size(dataRoi22HOG[0].Count(), dataRoi22HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi23Mat = new Mat(new Size(dataRoi23HOG[0].Count(), dataRoi23HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi24Mat = new Mat(new Size(dataRoi24HOG[0].Count(), dataRoi24HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi25Mat = new Mat(new Size(dataRoi25HOG[0].Count(), dataRoi25HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi26Mat = new Mat(new Size(dataRoi26HOG[0].Count(), dataRoi26HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi27Mat = new Mat(new Size(dataRoi27HOG[0].Count(), dataRoi27HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi28Mat = new Mat(new Size(dataRoi28HOG[0].Count(), dataRoi28HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi29Mat = new Mat(new Size(dataRoi29HOG[0].Count(), dataRoi29HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi30Mat = new Mat(new Size(dataRoi30HOG[0].Count(), dataRoi30HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi31Mat = new Mat(new Size(dataRoi31HOG[0].Count(), dataRoi31HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi32Mat = new Mat(new Size(dataRoi32HOG[0].Count(), dataRoi32HOG.Count()), DepthType.Cv32F, 1);

                this.dataRoi33Mat = new Mat(new Size(dataRoi33HOG[0].Count(), dataRoi33HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi34Mat = new Mat(new Size(dataRoi34HOG[0].Count(), dataRoi34HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi35Mat = new Mat(new Size(dataRoi35HOG[0].Count(), dataRoi35HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi36Mat = new Mat(new Size(dataRoi36HOG[0].Count(), dataRoi36HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi37Mat = new Mat(new Size(dataRoi37HOG[0].Count(), dataRoi37HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi38Mat = new Mat(new Size(dataRoi38HOG[0].Count(), dataRoi38HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi39Mat = new Mat(new Size(dataRoi39HOG[0].Count(), dataRoi39HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi40Mat = new Mat(new Size(dataRoi40HOG[0].Count(), dataRoi40HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi41Mat = new Mat(new Size(dataRoi41HOG[0].Count(), dataRoi41HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi42Mat = new Mat(new Size(dataRoi42HOG[0].Count(), dataRoi42HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi43Mat = new Mat(new Size(dataRoi43HOG[0].Count(), dataRoi43HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi44Mat = new Mat(new Size(dataRoi44HOG[0].Count(), dataRoi44HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi45Mat = new Mat(new Size(dataRoi45HOG[0].Count(), dataRoi45HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi46Mat = new Mat(new Size(dataRoi46HOG[0].Count(), dataRoi46HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi47Mat = new Mat(new Size(dataRoi47HOG[0].Count(), dataRoi47HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi48Mat = new Mat(new Size(dataRoi48HOG[0].Count(), dataRoi48HOG.Count()), DepthType.Cv32F, 1);

                this.dataRoi49Mat = new Mat(new Size(dataRoi49HOG[0].Count(), dataRoi49HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi50Mat = new Mat(new Size(dataRoi50HOG[0].Count(), dataRoi50HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi51Mat = new Mat(new Size(dataRoi51HOG[0].Count(), dataRoi51HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi52Mat = new Mat(new Size(dataRoi52HOG[0].Count(), dataRoi52HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi53Mat = new Mat(new Size(dataRoi53HOG[0].Count(), dataRoi53HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi54Mat = new Mat(new Size(dataRoi54HOG[0].Count(), dataRoi54HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi55Mat = new Mat(new Size(dataRoi55HOG[0].Count(), dataRoi55HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi56Mat = new Mat(new Size(dataRoi56HOG[0].Count(), dataRoi56HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi57Mat = new Mat(new Size(dataRoi57HOG[0].Count(), dataRoi57HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi58Mat = new Mat(new Size(dataRoi58HOG[0].Count(), dataRoi58HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi59Mat = new Mat(new Size(dataRoi59HOG[0].Count(), dataRoi59HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi60Mat = new Mat(new Size(dataRoi60HOG[0].Count(), dataRoi60HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi61Mat = new Mat(new Size(dataRoi61HOG[0].Count(), dataRoi61HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi62Mat = new Mat(new Size(dataRoi62HOG[0].Count(), dataRoi62HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi63Mat = new Mat(new Size(dataRoi63HOG[0].Count(), dataRoi63HOG.Count()), DepthType.Cv32F, 1);
                this.dataRoi64Mat = new Mat(new Size(dataRoi64HOG[0].Count(), dataRoi64HOG.Count()), DepthType.Cv32F, 1);
                //convertVectorToMatrix(ref dataTestMat, dataTestHOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi1Mat, dataRoi1HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi2Mat, dataRoi2HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi3Mat, dataRoi3HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi4Mat, dataRoi4HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi5Mat, dataRoi5HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi6Mat, dataRoi6HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi7Mat, dataRoi7HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi8Mat, dataRoi8HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi9Mat, dataRoi9HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi10Mat, dataRoi10HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi11Mat, dataRoi11HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi12Mat, dataRoi12HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi13Mat, dataRoi13HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi14Mat, dataRoi14HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi15Mat, dataRoi15HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi16Mat, dataRoi16HOG);

                this.convertFragmentVectorToMatrixFactor64(ref dataRoi17Mat, dataRoi17HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi18Mat, dataRoi18HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi19Mat, dataRoi19HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi20Mat, dataRoi20HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi21Mat, dataRoi21HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi22Mat, dataRoi22HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi23Mat, dataRoi23HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi24Mat, dataRoi24HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi25Mat, dataRoi25HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi26Mat, dataRoi26HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi27Mat, dataRoi27HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi28Mat, dataRoi28HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi29Mat, dataRoi29HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi30Mat, dataRoi30HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi31Mat, dataRoi31HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi32Mat, dataRoi32HOG);

                this.convertFragmentVectorToMatrixFactor64(ref dataRoi33Mat, dataRoi33HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi34Mat, dataRoi34HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi35Mat, dataRoi35HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi36Mat, dataRoi36HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi37Mat, dataRoi37HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi38Mat, dataRoi38HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi39Mat, dataRoi39HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi40Mat, dataRoi40HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi41Mat, dataRoi41HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi42Mat, dataRoi42HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi43Mat, dataRoi43HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi44Mat, dataRoi44HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi45Mat, dataRoi45HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi46Mat, dataRoi46HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi47Mat, dataRoi47HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi48Mat, dataRoi48HOG);

                this.convertFragmentVectorToMatrixFactor64(ref dataRoi49Mat, dataRoi49HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi50Mat, dataRoi50HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi51Mat, dataRoi51HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi52Mat, dataRoi52HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi53Mat, dataRoi53HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi54Mat, dataRoi54HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi55Mat, dataRoi55HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi56Mat, dataRoi56HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi57Mat, dataRoi57HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi58Mat, dataRoi58HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi59Mat, dataRoi59HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi60Mat, dataRoi60HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi61Mat, dataRoi61HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi62Mat, dataRoi62HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi63Mat, dataRoi63HOG);
                this.convertFragmentVectorToMatrixFactor64(ref dataRoi64Mat, dataRoi64HOG);

                List<float> result = new List<float>();
                for (int numPerson = 0; numPerson < faceDetected.Count(); numPerson++)
                {
                    //Indicar la fila ha predecir
                    this.acumuladorPrediccion( (int) modelRoi1.Predict(dataRoi1Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi2.Predict(dataRoi2Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi4.Predict(dataRoi4Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi5.Predict(dataRoi5Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi6.Predict(dataRoi6Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi7.Predict(dataRoi7Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi8.Predict(dataRoi8Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi9.Predict(dataRoi9Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi3.Predict(dataRoi3Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi10.Predict(dataRoi10Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi11.Predict(dataRoi11Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi12.Predict(dataRoi12Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi13.Predict(dataRoi13Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi14.Predict(dataRoi14Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi15.Predict(dataRoi15Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi16.Predict(dataRoi16Mat.Row(numPerson)) );

                    this.acumuladorPrediccion( (int) modelRoi17.Predict(dataRoi17Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi18.Predict(dataRoi18Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi19.Predict(dataRoi19Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi20.Predict(dataRoi20Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi21.Predict(dataRoi21Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi22.Predict(dataRoi22Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi23.Predict(dataRoi23Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi24.Predict(dataRoi24Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi25.Predict(dataRoi25Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi26.Predict(dataRoi26Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi27.Predict(dataRoi27Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi28.Predict(dataRoi28Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi29.Predict(dataRoi29Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi30.Predict(dataRoi30Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi31.Predict(dataRoi31Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi32.Predict(dataRoi32Mat.Row(numPerson)) );

                    this.acumuladorPrediccion( (int) modelRoi33.Predict(dataRoi33Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi34.Predict(dataRoi34Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi35.Predict(dataRoi35Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi36.Predict(dataRoi36Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi37.Predict(dataRoi37Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi38.Predict(dataRoi38Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi39.Predict(dataRoi39Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi40.Predict(dataRoi40Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi41.Predict(dataRoi41Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi42.Predict(dataRoi42Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi43.Predict(dataRoi43Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi44.Predict(dataRoi44Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi45.Predict(dataRoi45Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi46.Predict(dataRoi46Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi47.Predict(dataRoi47Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi48.Predict(dataRoi48Mat.Row(numPerson)) );

                    this.acumuladorPrediccion( (int) modelRoi49.Predict(dataRoi49Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi50.Predict(dataRoi50Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi51.Predict(dataRoi51Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi52.Predict(dataRoi52Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi53.Predict(dataRoi53Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi54.Predict(dataRoi54Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi55.Predict(dataRoi55Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi56.Predict(dataRoi56Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi57.Predict(dataRoi57Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi58.Predict(dataRoi58Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi59.Predict(dataRoi59Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi60.Predict(dataRoi60Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi61.Predict(dataRoi61Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi62.Predict(dataRoi62Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi63.Predict(dataRoi63Mat.Row(numPerson)) );
                    this.acumuladorPrediccion( (int) modelRoi64.Predict(dataRoi64Mat.Row(numPerson)) );

                    int resultado = this.evaluationPredictionFactor64();
                    if (resultado == 0) resultado = this.evaluationPrediction2Factor64();
                    if(resultado != 0)
                    {
                        Person sujeto = listPersons[resultado];
                        Face face = faceDetected.ElementAt(numPerson);
                        //Pintar y etiquetar
                        string nombre = listSearch[resultado];
                        CvInvoke.Rectangle(frameBgr, face.Roi, new MCvScalar(0, 0, 255));
                        this.sujetoIdentificado = sujeto.Nombre;
                    }
                    else
                    {
                        Console.WriteLine("No fue posible identificar la muesta ingresada");
                        this.sujetoIdentificado = "No Identificado";
                    }
                    this.limpiarAcumuladorPrediccion();
                    pbImagenOriginal.Image = frameBgr.Bitmap;
                }
            }
            else
            {
                pbImagenOriginal.Image = frameBgr.Bitmap;
            }
        }
        public void trainingDataFactor64()
        {
            this.fragmentImageFactor64(ref dataTrain);
            //calculateDescriptorsHOG(dataTrain, ref dataTrainHOG, out sizeDescriptor, out countDescriptors);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi1, ref dataRoi1HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi2, ref dataRoi2HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi3, ref dataRoi3HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi4, ref dataRoi4HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi5, ref dataRoi5HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi6, ref dataRoi6HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi7, ref dataRoi7HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi8, ref dataRoi8HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi9, ref dataRoi9HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi10, ref dataRoi10HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi11, ref dataRoi11HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi12, ref dataRoi12HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi13, ref dataRoi13HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi14, ref dataRoi14HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi15, ref dataRoi15HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi16, ref dataRoi16HOG);

            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi17, ref dataRoi17HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi18, ref dataRoi18HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi19, ref dataRoi19HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi20, ref dataRoi20HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi21, ref dataRoi21HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi22, ref dataRoi22HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi23, ref dataRoi23HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi24, ref dataRoi24HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi25, ref dataRoi25HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi26, ref dataRoi26HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi27, ref dataRoi27HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi28, ref dataRoi28HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi29, ref dataRoi29HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi30, ref dataRoi30HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi31, ref dataRoi31HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi32, ref dataRoi32HOG);

            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi33, ref dataRoi33HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi34, ref dataRoi34HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi35, ref dataRoi35HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi36, ref dataRoi36HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi37, ref dataRoi37HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi38, ref dataRoi38HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi39, ref dataRoi39HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi40, ref dataRoi40HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi41, ref dataRoi41HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi42, ref dataRoi42HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi43, ref dataRoi43HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi44, ref dataRoi44HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi45, ref dataRoi45HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi46, ref dataRoi46HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi47, ref dataRoi47HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi48, ref dataRoi48HOG);

            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi49, ref dataRoi49HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi50, ref dataRoi50HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi51, ref dataRoi51HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi52, ref dataRoi52HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi53, ref dataRoi53HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi54, ref dataRoi54HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi55, ref dataRoi55HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi56, ref dataRoi56HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi57, ref dataRoi57HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi58, ref dataRoi58HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi59, ref dataRoi59HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi60, ref dataRoi60HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi61, ref dataRoi61HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi62, ref dataRoi62HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi63, ref dataRoi63HOG);
            this.calculateFragmentDescriptorsHOGFactor64(ref dataRoi64, ref dataRoi64HOG);
            //dataTrainMat = new Mat(new Size(sizeDescriptor, countDescriptors), DepthType.Cv32F, 1); //	Mat(Size, DepthType, Int32)
            this.dataRoi1Mat = new Mat(new Size(dataRoi1HOG[0].Count(), dataRoi1HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi2Mat = new Mat(new Size(dataRoi2HOG[0].Count(), dataRoi2HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi3Mat = new Mat(new Size(dataRoi3HOG[0].Count(), dataRoi3HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi4Mat = new Mat(new Size(dataRoi4HOG[0].Count(), dataRoi4HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi5Mat = new Mat(new Size(dataRoi5HOG[0].Count(), dataRoi5HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi6Mat = new Mat(new Size(dataRoi6HOG[0].Count(), dataRoi6HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi7Mat = new Mat(new Size(dataRoi7HOG[0].Count(), dataRoi7HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi8Mat = new Mat(new Size(dataRoi8HOG[0].Count(), dataRoi8HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi9Mat = new Mat(new Size(dataRoi9HOG[0].Count(), dataRoi9HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi10Mat = new Mat(new Size(dataRoi10HOG[0].Count(), dataRoi10HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi11Mat = new Mat(new Size(dataRoi11HOG[0].Count(), dataRoi11HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi12Mat = new Mat(new Size(dataRoi12HOG[0].Count(), dataRoi12HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi13Mat = new Mat(new Size(dataRoi13HOG[0].Count(), dataRoi13HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi14Mat = new Mat(new Size(dataRoi14HOG[0].Count(), dataRoi14HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi15Mat = new Mat(new Size(dataRoi15HOG[0].Count(), dataRoi15HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi16Mat = new Mat(new Size(dataRoi16HOG[0].Count(), dataRoi16HOG.Count()), DepthType.Cv32F, 1);

            this.dataRoi17Mat = new Mat(new Size(dataRoi17HOG[0].Count(), dataRoi17HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi18Mat = new Mat(new Size(dataRoi18HOG[0].Count(), dataRoi18HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi19Mat = new Mat(new Size(dataRoi19HOG[0].Count(), dataRoi19HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi20Mat = new Mat(new Size(dataRoi20HOG[0].Count(), dataRoi20HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi21Mat = new Mat(new Size(dataRoi21HOG[0].Count(), dataRoi21HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi22Mat = new Mat(new Size(dataRoi22HOG[0].Count(), dataRoi22HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi23Mat = new Mat(new Size(dataRoi23HOG[0].Count(), dataRoi23HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi24Mat = new Mat(new Size(dataRoi24HOG[0].Count(), dataRoi24HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi25Mat = new Mat(new Size(dataRoi25HOG[0].Count(), dataRoi25HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi26Mat = new Mat(new Size(dataRoi26HOG[0].Count(), dataRoi26HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi27Mat = new Mat(new Size(dataRoi27HOG[0].Count(), dataRoi27HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi28Mat = new Mat(new Size(dataRoi28HOG[0].Count(), dataRoi28HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi29Mat = new Mat(new Size(dataRoi29HOG[0].Count(), dataRoi29HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi30Mat = new Mat(new Size(dataRoi30HOG[0].Count(), dataRoi30HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi31Mat = new Mat(new Size(dataRoi31HOG[0].Count(), dataRoi31HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi32Mat = new Mat(new Size(dataRoi32HOG[0].Count(), dataRoi32HOG.Count()), DepthType.Cv32F, 1);

            this.dataRoi33Mat = new Mat(new Size(dataRoi33HOG[0].Count(), dataRoi33HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi34Mat = new Mat(new Size(dataRoi34HOG[0].Count(), dataRoi34HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi35Mat = new Mat(new Size(dataRoi35HOG[0].Count(), dataRoi35HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi36Mat = new Mat(new Size(dataRoi36HOG[0].Count(), dataRoi36HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi37Mat = new Mat(new Size(dataRoi37HOG[0].Count(), dataRoi37HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi38Mat = new Mat(new Size(dataRoi38HOG[0].Count(), dataRoi38HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi39Mat = new Mat(new Size(dataRoi39HOG[0].Count(), dataRoi39HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi40Mat = new Mat(new Size(dataRoi40HOG[0].Count(), dataRoi40HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi41Mat = new Mat(new Size(dataRoi41HOG[0].Count(), dataRoi41HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi42Mat = new Mat(new Size(dataRoi42HOG[0].Count(), dataRoi42HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi43Mat = new Mat(new Size(dataRoi43HOG[0].Count(), dataRoi43HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi44Mat = new Mat(new Size(dataRoi44HOG[0].Count(), dataRoi44HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi45Mat = new Mat(new Size(dataRoi45HOG[0].Count(), dataRoi45HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi46Mat = new Mat(new Size(dataRoi46HOG[0].Count(), dataRoi46HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi47Mat = new Mat(new Size(dataRoi47HOG[0].Count(), dataRoi47HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi48Mat = new Mat(new Size(dataRoi48HOG[0].Count(), dataRoi48HOG.Count()), DepthType.Cv32F, 1);

            this.dataRoi49Mat = new Mat(new Size(dataRoi49HOG[0].Count(), dataRoi49HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi50Mat = new Mat(new Size(dataRoi50HOG[0].Count(), dataRoi50HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi51Mat = new Mat(new Size(dataRoi51HOG[0].Count(), dataRoi51HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi52Mat = new Mat(new Size(dataRoi52HOG[0].Count(), dataRoi52HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi53Mat = new Mat(new Size(dataRoi53HOG[0].Count(), dataRoi53HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi54Mat = new Mat(new Size(dataRoi54HOG[0].Count(), dataRoi54HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi55Mat = new Mat(new Size(dataRoi55HOG[0].Count(), dataRoi55HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi56Mat = new Mat(new Size(dataRoi56HOG[0].Count(), dataRoi56HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi57Mat = new Mat(new Size(dataRoi57HOG[0].Count(), dataRoi57HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi58Mat = new Mat(new Size(dataRoi58HOG[0].Count(), dataRoi58HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi59Mat = new Mat(new Size(dataRoi59HOG[0].Count(), dataRoi59HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi60Mat = new Mat(new Size(dataRoi60HOG[0].Count(), dataRoi60HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi61Mat = new Mat(new Size(dataRoi61HOG[0].Count(), dataRoi61HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi62Mat = new Mat(new Size(dataRoi62HOG[0].Count(), dataRoi62HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi63Mat = new Mat(new Size(dataRoi63HOG[0].Count(), dataRoi63HOG.Count()), DepthType.Cv32F, 1);
            this.dataRoi64Mat = new Mat(new Size(dataRoi64HOG[0].Count(), dataRoi64HOG.Count()), DepthType.Cv32F, 1);
            //convertVectorToMatrix(ref dataTrainMat, dataTrainHOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi1Mat, dataRoi1HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi2Mat, dataRoi2HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi3Mat, dataRoi3HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi4Mat, dataRoi4HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi5Mat, dataRoi5HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi6Mat, dataRoi6HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi7Mat, dataRoi7HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi8Mat, dataRoi8HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi9Mat, dataRoi9HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi10Mat, dataRoi10HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi11Mat, dataRoi11HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi12Mat, dataRoi12HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi13Mat, dataRoi13HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi14Mat, dataRoi14HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi15Mat, dataRoi15HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi16Mat, dataRoi16HOG);

            this.convertFragmentVectorToMatrixFactor64(ref dataRoi17Mat, dataRoi17HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi18Mat, dataRoi18HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi19Mat, dataRoi19HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi20Mat, dataRoi20HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi21Mat, dataRoi21HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi22Mat, dataRoi22HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi23Mat, dataRoi23HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi24Mat, dataRoi24HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi25Mat, dataRoi25HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi26Mat, dataRoi26HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi27Mat, dataRoi27HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi28Mat, dataRoi28HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi29Mat, dataRoi29HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi30Mat, dataRoi30HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi31Mat, dataRoi31HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi32Mat, dataRoi32HOG);

            this.convertFragmentVectorToMatrixFactor64(ref dataRoi33Mat, dataRoi33HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi34Mat, dataRoi34HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi35Mat, dataRoi35HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi36Mat, dataRoi36HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi37Mat, dataRoi37HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi38Mat, dataRoi38HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi39Mat, dataRoi39HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi40Mat, dataRoi40HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi41Mat, dataRoi41HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi42Mat, dataRoi42HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi43Mat, dataRoi43HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi44Mat, dataRoi44HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi45Mat, dataRoi45HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi46Mat, dataRoi46HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi47Mat, dataRoi47HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi48Mat, dataRoi48HOG);

            this.convertFragmentVectorToMatrixFactor64(ref dataRoi49Mat, dataRoi49HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi50Mat, dataRoi50HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi51Mat, dataRoi51HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi52Mat, dataRoi52HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi53Mat, dataRoi53HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi54Mat, dataRoi54HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi55Mat, dataRoi55HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi56Mat, dataRoi56HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi57Mat, dataRoi57HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi58Mat, dataRoi58HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi59Mat, dataRoi59HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi60Mat, dataRoi60HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi61Mat, dataRoi61HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi62Mat, dataRoi62HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi63Mat, dataRoi63HOG);
            this.convertFragmentVectorToMatrixFactor64(ref dataRoi64Mat, dataRoi64HOG);
            //model = training(dataTrainMat, labelTrain);
            modelRoi1 = this.trainingFragmentFactor64(dataRoi1Mat, labelTrain);
            modelRoi2 = this.trainingFragmentFactor64(dataRoi2Mat, labelTrain);
            modelRoi3 = this.trainingFragmentFactor64(dataRoi3Mat, labelTrain);
            modelRoi4 = this.trainingFragmentFactor64(dataRoi4Mat, labelTrain);
            modelRoi5 = this.trainingFragmentFactor64(dataRoi5Mat, labelTrain);
            modelRoi6 = this.trainingFragmentFactor64(dataRoi6Mat, labelTrain);
            modelRoi7 = this.trainingFragmentFactor64(dataRoi7Mat, labelTrain);
            modelRoi8 = this.trainingFragmentFactor64(dataRoi8Mat, labelTrain);
            modelRoi9 = this.trainingFragmentFactor64(dataRoi9Mat, labelTrain);
            modelRoi10 = this.trainingFragmentFactor64(dataRoi10Mat, labelTrain);
            modelRoi11 = this.trainingFragmentFactor64(dataRoi11Mat, labelTrain);
            modelRoi12 = this.trainingFragmentFactor64(dataRoi12Mat, labelTrain);
            modelRoi13 = this.trainingFragmentFactor64(dataRoi13Mat, labelTrain);
            modelRoi14 = this.trainingFragmentFactor64(dataRoi14Mat, labelTrain);
            modelRoi15 = this.trainingFragmentFactor64(dataRoi15Mat, labelTrain);
            modelRoi16 = this.trainingFragmentFactor64(dataRoi16Mat, labelTrain);

            modelRoi17 = this.trainingFragmentFactor64(dataRoi17Mat, labelTrain);
            modelRoi18 = this.trainingFragmentFactor64(dataRoi18Mat, labelTrain);
            modelRoi19 = this.trainingFragmentFactor64(dataRoi19Mat, labelTrain);
            modelRoi20 = this.trainingFragmentFactor64(dataRoi20Mat, labelTrain);
            modelRoi21 = this.trainingFragmentFactor64(dataRoi21Mat, labelTrain);
            modelRoi22 = this.trainingFragmentFactor64(dataRoi22Mat, labelTrain);
            modelRoi23 = this.trainingFragmentFactor64(dataRoi23Mat, labelTrain);
            modelRoi24 = this.trainingFragmentFactor64(dataRoi24Mat, labelTrain);
            modelRoi25 = this.trainingFragmentFactor64(dataRoi25Mat, labelTrain);
            modelRoi26 = this.trainingFragmentFactor64(dataRoi26Mat, labelTrain);
            modelRoi27 = this.trainingFragmentFactor64(dataRoi27Mat, labelTrain);
            modelRoi28 = this.trainingFragmentFactor64(dataRoi28Mat, labelTrain);
            modelRoi29 = this.trainingFragmentFactor64(dataRoi29Mat, labelTrain);
            modelRoi30 = this.trainingFragmentFactor64(dataRoi30Mat, labelTrain);
            modelRoi31 = this.trainingFragmentFactor64(dataRoi31Mat, labelTrain);
            modelRoi32 = this.trainingFragmentFactor64(dataRoi32Mat, labelTrain);

            modelRoi33 = this.trainingFragmentFactor64(dataRoi33Mat, labelTrain);
            modelRoi34 = this.trainingFragmentFactor64(dataRoi34Mat, labelTrain);
            modelRoi35 = this.trainingFragmentFactor64(dataRoi35Mat, labelTrain);
            modelRoi36 = this.trainingFragmentFactor64(dataRoi36Mat, labelTrain);
            modelRoi37 = this.trainingFragmentFactor64(dataRoi37Mat, labelTrain);
            modelRoi38 = this.trainingFragmentFactor64(dataRoi38Mat, labelTrain);
            modelRoi39 = this.trainingFragmentFactor64(dataRoi39Mat, labelTrain);
            modelRoi40 = this.trainingFragmentFactor64(dataRoi40Mat, labelTrain);
            modelRoi41 = this.trainingFragmentFactor64(dataRoi41Mat, labelTrain);
            modelRoi42 = this.trainingFragmentFactor64(dataRoi42Mat, labelTrain);
            modelRoi43 = this.trainingFragmentFactor64(dataRoi43Mat, labelTrain);
            modelRoi44 = this.trainingFragmentFactor64(dataRoi44Mat, labelTrain);
            modelRoi45 = this.trainingFragmentFactor64(dataRoi45Mat, labelTrain);
            modelRoi46 = this.trainingFragmentFactor64(dataRoi46Mat, labelTrain);
            modelRoi47 = this.trainingFragmentFactor64(dataRoi47Mat, labelTrain);
            modelRoi48 = this.trainingFragmentFactor64(dataRoi48Mat, labelTrain);

            modelRoi49 = this.trainingFragmentFactor64(dataRoi49Mat, labelTrain);
            modelRoi50 = this.trainingFragmentFactor64(dataRoi50Mat, labelTrain);
            modelRoi51 = this.trainingFragmentFactor64(dataRoi51Mat, labelTrain);
            modelRoi52 = this.trainingFragmentFactor64(dataRoi52Mat, labelTrain);
            modelRoi53 = this.trainingFragmentFactor64(dataRoi53Mat, labelTrain);
            modelRoi54 = this.trainingFragmentFactor64(dataRoi54Mat, labelTrain);
            modelRoi55 = this.trainingFragmentFactor64(dataRoi55Mat, labelTrain);
            modelRoi56 = this.trainingFragmentFactor64(dataRoi56Mat, labelTrain);
            modelRoi57 = this.trainingFragmentFactor64(dataRoi57Mat, labelTrain);
            modelRoi58 = this.trainingFragmentFactor64(dataRoi58Mat, labelTrain);
            modelRoi59 = this.trainingFragmentFactor64(dataRoi59Mat, labelTrain);
            modelRoi60 = this.trainingFragmentFactor64(dataRoi60Mat, labelTrain);
            modelRoi61 = this.trainingFragmentFactor64(dataRoi61Mat, labelTrain);
            modelRoi62 = this.trainingFragmentFactor64(dataRoi62Mat, labelTrain);
            modelRoi63 = this.trainingFragmentFactor64(dataRoi63Mat, labelTrain);
            modelRoi64 = this.trainingFragmentFactor64(dataRoi64Mat, labelTrain);
        }

        /********** MÉTODOS EXTRAS *************/
        public Image<Bgr, Byte> evaluationIfDrawFaces(Mat frame)
        {
            CascadeClassifier faceDetector = new CascadeClassifier(pathCascadeFace);
            Image<Bgr, Byte> _frame_aux = frame.ToImage<Bgr, Byte>().Resize(this.WIDTH_WINDOW, this.HEIGHT_WINDOW, Inter.Linear, false);
            if (this.conteoFrames % 3 == 0)
            {
                foreach (Rectangle faceRec in faceDetector.DetectMultiScale(_frame_aux, 1.1, 10, new Size(20, 20), Size.Empty))
                {
                    CvInvoke.Rectangle(_frame_aux, faceRec, new Bgr(Color.Red).MCvScalar, 2);
                }
            }
            return _frame_aux;
        }
        public void cleanSamples()
        {
            // Especificar ruta de origen para datos de entrenamiento
            var path = new DirectoryInfo(@"C:\Users\FGG\Desktop\Resources-Personas-1280x720-copia");
            string[] dirsDataTrain = Directory.GetDirectories(@path.ToString());

            /************ Para quitar aquellas muestras con mas de un rostro ************/
            /************ Y aquellas en la que no es posible hallar un rostro ************/

            foreach (DirectoryInfo classFolder in path.EnumerateDirectories())
            {
                FileInfo[] files = GetFilesByExtensions(classFolder, ".jpg", ".png").ToArray();

                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo file = files[i];
                    List<Face> faceDetected = new List<Face>();
                    UMat imgGray = new UMat();

                    IImage img = new Mat(@file.FullName, ImreadModes.Color);
                    CvInvoke.CvtColor(img, imgGray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                    imgGray = alignEyes(imgGray.ToImage<Gray, Byte>().Resize(1280, 720, Inter.Linear, false)).ToUMat();
                    faceDetected = detectFaces(imgGray.ToImage<Gray, Byte>().Resize(1280, 720, Inter.Linear, false));
                    if (faceDetected.Count == 0 || faceDetected.Count > 1)
                    {
                        myComputer.FileSystem.DeleteFile(file.FullName);
                    }
                }
            }

            ///***************** Para quitar una muestra de la bd y utilizarla como testing *********/
            //foreach (DirectoryInfo classFolder in path.EnumerateDirectories())
            //{
            //    FileInfo[] files = GetFilesByExtensions(classFolder, ".jpg", ".png").ToArray();

            //    for (int i = 0; i < 1; i++)
            //    {
            //        FileInfo file = files[i];
            //        myComputer.FileSystem.MoveFile(file.FullName, @"E://ICCI 2010//2018//Reconocimiento Facial//Dataset-train//lfw-test//MasTreceMuestraPorPersona//" + file.Name);
            //    }
            //}

            foreach (var folder in dirsDataTrain)
            {
                string[] subDir = Directory.GetFiles(folder.ToString(), "*.jpg");

                /****************** Se filtra la carpeta lfw para contener sólo carpetas con mas de cinco muestra, es resto se desecha   ********************/

                //if ((int)subDir.Length >= 6)
                //{
                //    myComputer.FileSystem.CopyDirectory(folder.ToString(), "e://icci 2010//2018//reconocimiento facial//dataset-train//lfw-filtro/" + folder.ToString().Substring(folder.ToString().LastIndexOf(@"\")));
                //}

                /****************** Separación de muestras por carpetas   ********************/
                //if ((int)subDir.Length == 8)
                //{
                //    myComputer.FileSystem.CopyDirectory(folder.ToString(), "E://ICCI 2010//2018//Reconocimiento Facial//Dataset-train//lfw-categorizado//SieteMuestraPorPersona" + folder.ToString().Substring(folder.ToString().LastIndexOf(@"\")));
                //}

                //if ((int)subDir.Length == 11)
                //{
                //    myComputer.FileSystem.CopyDirectory(folder.ToString(), @"E://ICCI 2010//2018//Reconocimiento Facial//Dataset-train//lfw-categorizado//DiezMuestraPorPersona" + folder.ToString().Substring(folder.ToString().LastIndexOf(@"\")));
                //}

                //if ((int)subDir.Length == 14)
                //{
                //    myComputer.FileSystem.CopyDirectory(folder.ToString(), @"E://ICCI 2010//2018//Reconocimiento Facial//Dataset-train//lfw-categorizado//TreceMuestraPorPersona" + folder.ToString().Substring(folder.ToString().LastIndexOf(@"\")));
                //}

                //if ((int)subDir.Length > 14)
                //{
                //    myComputer.FileSystem.CopyDirectory(folder.ToString(), @"E://ICCI 2010//2018//Reconocimiento Facial//Dataset-train//lfw-categorizado//MasTreceMuestraPorPersona" + folder.ToString().Substring(folder.ToString().LastIndexOf(@"\")));
                //}
            }
        }
        public void acumuladorPrediccion(int prediccion)
        {
            Person sujeto = this.listPersons[prediccion];
            sujeto.NroVotos += 1;
        }
        public void limpiarAcumuladorPrediccion()
        {
            foreach (var key in this.listPersons.Keys)
            {
                Person sujeto = this.listPersons[key];
                sujeto.NroVotos = 0;
            }
        }
        public void limpiarConteoFramesPositivos()
        {
            foreach (var key in this.listPersons.Keys)
            {
                Person sujeto = this.listPersons[key];
                sujeto.ConteoFramePositivos = 0;
            }
        }
        public void evaluacionConteoFramesPositivos()
        {
            try
            {
                foreach (var person in listPersons)
                {
                    if ((int)person.Value.ConteoFramePositivos > 2)
                    {
                        //Se añade el sujeto encontrado a grilla con nombre
                        DataRow row = this.dtSujetos.NewRow();
                        this.nroSujetosHallados += 1;
                        row["id"] = this.nroSujetosHallados;
                        row["nombre"] = person.Value.Nombre;
                        row["fecha_registro"] = Convert.ToString(DateTime.Now);
                        this.dtSujetos.Rows.Add(row);
                        //Se añade el sujeto encontrado a grilla con foto
                        Image<Gray, byte> img = person.Value.Foto.FaceOnly;
                        Image<Gray, Byte> gray = img.Clone();
                        Object[] row_foto = new Object[] { gray.Bitmap };
                        this.dgvFotosSujetosEncontradas.Rows.Add(row_foto);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Método .:. evaluacionConteoFramesPositivos");
            }
            
        }
        public int evaluationPredictionFactor4()
        {
            int result = 0;
            foreach (var person in listPersons)
            {
                if ((int)person.Value.NroVotos > this.porcentajeAceptacionMax * 4)
                {
                    result = person.Key;
                }
            }

            return result;
        }
        public int evaluationPredictionFactor16()
        {
            int result = 0;
            foreach (var person in listPersons)
            {
                if ((int)person.Value.NroVotos > this.porcentajeAceptacionMax * 16)
                {
                    result = person.Key;
                }
            }

            return result;
        }
        public int evaluationPredictionFactor64()
        {
            int result = 0;
            foreach (var person in listPersons)
            {
                if ((int)person.Value.NroVotos > this.porcentajeAceptacionMax * 64)
                {
                    result = person.Key;
                }
            }

            return result;
        }
        public int evaluationPrediction2Factor4()
        {
            int result = 0;
            int mayorNroVotos = 0;
            foreach (var person in this.listPersons)
            {
                if ((int)person.Value.NroVotos > mayorNroVotos)
                {
                    mayorNroVotos = person.Value.NroVotos;
                    result = person.Key;
                }
            }
            if (this.listPersons[result].NroVotos >= this.porcentajeAceptacionMin * 4)
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
        public int evaluationPrediction2Factor16()
        {
            int result = 0;
            int mayorNroVotos = 0;
            foreach (var person in this.listPersons)
            {
                if ((int)person.Value.NroVotos > mayorNroVotos)
                {
                    mayorNroVotos = person.Value.NroVotos;
                    result = person.Key;
                }
            }
            if (this.listPersons[result].NroVotos >= this.porcentajeAceptacionMin * 16)
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
        public int evaluationPrediction2Factor64()
        {
            int result = 0;
            int mayorNroVotos = 0;
            foreach (var person in this.listPersons)
            {
                if ((int)person.Value.NroVotos > mayorNroVotos)
                {
                    mayorNroVotos = person.Value.NroVotos;
                    result = person.Key;
                }
            }
            if (this.listPersons[result].NroVotos >= this.porcentajeAceptacionMin * 64)
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        private void btnSeleccionarRutaMuestrasEntrenamiento_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string path = fbd.SelectedPath;
                    this.tbRutaMuestrasEntrenamiento.Text = path;
                }
            }
        }

        private void btnEntrenar_Click(object sender, EventArgs e)
        {
            string pathOrigin = tbRutaMuestrasEntrenamiento.Text;

            loadDatatraining(ref dataTrain, ref labelTrain, @pathOrigin);
            this.C = Convert.ToInt32(this.tbC.Text);
            this.gamma = Convert.ToDouble(this.tbGamma.Text);
            this.coef0 = Convert.ToDouble(this.tbCoef0.Text);
            this.degree = Convert.ToInt32(this.tbDegree.Text);
            this.nu = Convert.ToDouble(this.tbNu.Text);
            this.P = Convert.ToDouble(this.tbP.Text);
            switch (this.cbFactorFragmentacionTrain.Text)
            {
                case "Factor 4":
                {
                        trainingDataFactor4();
                        MessageBox.Show("Aviso: " + "Datos entrenados exitosamente", "Factor 4");
                        break;
                }
                case "Factor 16":
                {
                        trainingDataFactor16();
                        MessageBox.Show("Aviso: " + "Datos entrenados exitosamente", "Factor 16");
                        break;
                }
                case "Factor 64":
                {
                        trainingDataFactor64();
                        MessageBox.Show("Aviso: " + "Datos entrenados exitosamente", "Factor 64");
                        break;
                }
            }
        }

        private void btnTestear_Click(object sender, EventArgs e)
        {
            var pathOrigin = new DirectoryInfo(@tbRutaMuetrasTest.Text);
            this.sujetosEvaluados = new Dictionary<string, string>();
            int nroSujetosTest = 0;
            int nroSujetosIdentificados = 0;
            double porcentajeAciertos = 0;
            this.porcentajeAceptacionMax = Convert.ToDouble(this.tbAceptacionMax.Text);
            this.porcentajeAceptacionMin = Convert.ToDouble(this.tbAceptacionMin.Text);
            FileInfo[] files = GetFilesByExtensions(@pathOrigin, ".jpg", ".png").ToArray();
            for (int i = 0; i < files.Length; i++)
            {
                nroSujetosTest += 1;
                FileInfo file = files[i];
                IImage img = new Mat(file.FullName, ImreadModes.Color);
                this.sujetoDesconocido = file.Name;
                if (cbFactorFragmentacionTest.Text == "Factor 4") this.testItFragmentFactor4(img);
                if (cbFactorFragmentacionTest.Text == "Factor 16") this.testItFragmentFactor16(img);
                if (cbFactorFragmentacionTest.Text == "Factor 64") this.testItFragmentFactor64(img);

                this.sujetosEvaluados.Add(this.sujetoDesconocido, this.sujetoIdentificado);
                Console.WriteLine("{0} - {1}", this.sujetoDesconocido, this.sujetoIdentificado);
            }
            
            foreach (var key in this.sujetosEvaluados.Keys)
            {
                if (key.ToString().Contains(this.sujetosEvaluados[key].ToString()))
                {
                    nroSujetosIdentificados += 1;
                }
            }
            //Mostrar resultados
            this.tbSujetosTest.Text = Convert.ToString(nroSujetosTest);
            this.tbSujetosIdentificados.Text = Convert.ToString(nroSujetosIdentificados);
            this.tbSujetosSinIdentificar.Text = Convert.ToString(nroSujetosTest - nroSujetosIdentificados);
            porcentajeAciertos = (Convert.ToDouble(nroSujetosIdentificados) / Convert.ToDouble(nroSujetosTest)) * 100;
            this.tbPorcetajeAciertos.Text = porcentajeAciertos.ToString("#0.00#"); ;
        }

        private void btnSeleccionarMuestrasTest_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string path = fbd.SelectedPath;
                    this.tbRutaMuetrasTest.Text = path;
                }
            }
        }

        private void cbFactorFragmentacionTrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(this.cbFactorFragmentacionTrain.Text)
            {
                case "Factor 4":
                    {
                        this.tbWinsize.Text = Convert.ToString(32);
                        this.tbBlocksize.Text = Convert.ToString(16);
                        this.tbCellsize.Text = Convert.ToString(8);
                        this.tbNbins.Text = Convert.ToString(9);
                        break;
                    }
                case "Factor 16":
                    {
                        this.tbWinsize.Text = Convert.ToString(16);
                        this.tbBlocksize.Text = Convert.ToString(8);
                        this.tbCellsize.Text = Convert.ToString(4);
                        this.tbNbins.Text = Convert.ToString(9);
                        break;
                    }
                case "Factor 64":
                    {
                        this.tbWinsize.Text = Convert.ToString(8);
                        this.tbBlocksize.Text = Convert.ToString(4);
                        this.tbCellsize.Text = Convert.ToString(2);
                        this.tbNbins.Text = Convert.ToString(9);
                        break;
                    }
            }
        }

        private void btnConectarCamara_Click(object sender, EventArgs e)
        {
            try
            {
                string user = this.tbUser.Text;
                string pass = this.tbPass.Text;
                string ip = this.tbDirIP.Text;
                string port = this.tbPort.Text;
                string strConnection = "rtsp://" + user + ":" + pass + "@" + ip + ":" + port + "/Streaming/Channels/101/";
                //_capture = new VideoCapture("rtsp://admin:1234.abc@192.168.1.64:554/Streaming/Channels/102/");
                this._capture = new VideoCapture(strConnection);
                //this._capture = new VideoCapture(@"C:\Users\FGG\Desktop\Resources-Personas-1280x720\Danilo_Gonzalez.mp4");
                _capture.ImageGrabbed += ProcessFrame;
                _capture.Start();
                _frame = new Mat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror: " + ex.Message);
            }
        }

        private void btnIniciarReconocimiento_Click(object sender, EventArgs e)
        {
            this.isWorking = true;
            this.conteoFrames = 0;
            this.nroSujetosHallados = 0;
            this.dtSujetos.Clear();
            this.dgvSujetos.DataSource = this.dtSujetos;
        }

        private void btnDetenerReconocimiento_Click(object sender, EventArgs e)
        {
            this.isWorking = false;
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            try
            {
                Image<Bgr, Byte> captura = this._frame.ToImage<Bgr, Byte>();
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "JPG(*.JPG)|*.jpg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    captura.Save(dialog.FileName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Evento .:. btnCapturar_Click");
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.VideoW = new VideoWriter(@"C:\Users\FGG\Desktop\Resources-Personas-1280x720\Nicolas_Moya.mp4",
                                   20,
                                   new Size(1280,720),
                                   true);
            this.isRecording = true;
        }

        private void btnDetenerGrabacion_Click(object sender, EventArgs e)
        {
            this.isRecording = false;
        }
    }
}