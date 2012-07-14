using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SOAPService.Dominio
{
    [DataContract]
    public class ResidenteEntidad
    {
        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public int Edad { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Clave { get; set; }
        [DataMember]
        public string Tipo { get; set; }

        //private String _DNI;
        //private String _Nombres;
        //private String _ApellidoPaterno;
        //private String _ApellidoMaterno;
        //private int _Edad;
        //private String _Correo;
        //private String _Clave;
        //private String _Tipo;

        ////[Required(ErrorMessage = "El DNI es Obligatorio")]
        ////[StringLength(8, ErrorMessage = "Máximo 8 caracteres")]
        //[DataMember]
        //public String DNI
        //{
        //    get { return _DNI; }
        //    set { _DNI = value; }
        //}

        //[DataMember]
        //public String Nombres
        //{
        //    get { return _Nombres; }
        //    set { _Nombres = value; }
        //}

        //[DataMember]
        //public String ApellidoPaterno
        //{
        //    get { return _ApellidoPaterno; }
        //    set { _ApellidoPaterno = value; }
        //}

        //[DataMember]
        //public String ApellidoMaterno
        //{
        //    get { return _ApellidoMaterno; }
        //    set { _ApellidoMaterno = value; }
        //}

        //[DataMember]
        //public int Edad
        //{
        //    get { return _Edad; }
        //    set { _Edad = value; }
        //}

        //[DataMember]
        //public String Correo
        //{
        //    get { return _Correo; }
        //    set { _Correo = value; }
        //}

        //[DataMember]
        //public String Clave
        //{
        //    get { return _Clave; }
        //    set { _Clave = value; }
        //}

        ////[Required(ErrorMessage = "El TIPO es Obligatorio")]
        //[DataMember]
        //public String Tipo
        //{
        //    get { return _Tipo; }
        //    set { _Tipo = value; }
        //}

        //public String TipoDesc
        //{
        //    get
        //    {
        //        if (_Tipo != null)
        //        {
        //            if (_Tipo.Equals("R"))
        //                return "Residente";
        //            else if (_Tipo.Equals("P"))
        //                return "Propietario";
        //            else if (_Tipo.Equals("A"))
        //                return "Administrador";
        //            else
        //                return "-";
        //        }
        //        else
        //        {
        //            return "-";
        //        }
        //    }
        //}
    }
}