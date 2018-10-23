using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Reconocimiento_Facial
{
    public class Person
    {
        private int _idClase;
        private string _nombre;
        private int _nroVotos;
        private int _conteoFramePositivos;

        public Person()
        { }

        public int IdClase
        {
            get { return _idClase; }
            set { _idClase = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int NroVotos
        {
            get { return _nroVotos; }
            set { _nroVotos = value; }
        }

        public int ConteoFramePositivos
        {
            get { return _conteoFramePositivos; }
            set { _conteoFramePositivos = value; }
        }
    }
}
