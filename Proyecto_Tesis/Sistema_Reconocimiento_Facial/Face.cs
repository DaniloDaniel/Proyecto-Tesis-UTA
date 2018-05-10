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
        private string _name;
        private int _classId;
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

        public Face(string name, int classId)
        {
            _name = name;
            _classId = classId;
            _faceOnly = FaceOnly;
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

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int ClassId
        {
            get
            {
                return _classId;
            }

            set
            {
                _classId = value;
            }
        }
    }
}
