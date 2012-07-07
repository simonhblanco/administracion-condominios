using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Condominios.Dominio
{
    public class AreaComun
    {
        private long _CodArea;
        private String _Tipo;
        private String _Ubicacion;
        private int _Capacidad;

        public long CodArea
        {
            get { return _CodArea; }
            set { _CodArea = value; }
        }

        public String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public String Ubicacion
        {
            get { return _Ubicacion; }
            set { _Ubicacion = value; }
        }

        public int Capacidad
        {
            get { return _Capacidad; }
            set { _Capacidad = value; }
        }
    }
}