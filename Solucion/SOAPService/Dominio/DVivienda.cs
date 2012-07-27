using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SOAPService.Dominio
{
    [DataContract]  //contrato
    public class DVivienda
    {
        private int _NumVivienda;
        private String _Ubicacion;
        private int _Numero;
        private int _Metraje;
        private String _Tipo;
        private DResidente _Residente;

        [DataMember]
        public int NumVivienda
        {
            get { return _NumVivienda; }
            set { _NumVivienda = value; }
        }

        [DataMember]
        public String Ubicacion
        {
            get { return _Ubicacion; }
            set { _Ubicacion = value; }
        }

        [DataMember]
        public int Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        [DataMember]
        public int Metraje
        {
            get { return _Metraje; }
            set { _Metraje = value; }
        }

        [DataMember]
        public String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        [DataMember]
        public DResidente Residente
        {
            get { return _Residente; }
            set { _Residente = value; }
        }
    }
}