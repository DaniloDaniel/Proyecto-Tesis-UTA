using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Reconocimiento_Facial
{
    public class Face
    {
        private Image<Gray,Byte> _faceOnly;
        private Rectangle _roi;

        

        public Face()
        {
        }

        public Face(Image<Gray, Byte> faceOnly, Rectangle roi)
        {
            _faceOnly = faceOnly;
            _roi = roi;
        }

        public Image<Gray, byte> FaceOnly
        {
            get
            {
                return _faceOnly;
            }

            set
            {
                _faceOnly = value;
            }
        }

        public Rectangle Roi
        {
            get
            {
                return _roi;
            }

            set
            {
                _roi = value;
            }
        }
    }
}
