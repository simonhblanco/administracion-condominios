using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTTest
{
     public class Residente
    {

       
             public string ApellidoMaterno { get; set; }
             public string ApellidoPaterno { get; set; }
             public object Clave { get; set; }
             public string Correo { get; set; }
             public string DNI { get; set; }
             public int Edad { get; set; }
             public string Nombres { get; set; }
             public string Tipo { get; set; }
         }
         }

        //private String _DNI;
        //private String _Nombres;
        //private String _ApellidoPaterno;
        //private String _ApellidoMaterno;
        //private int _Edad;
        //private String _Correo;
        //private String _Clave;
        //private String _Tipo;

        ////[Required(ErrorMessage = "El DNI es Obligatorio")]
        //[StringLength(8, ErrorMessage = "Máximo 8 caracteres")]
//        // viene del DAO
//        public String DNI
//        {
//            get { return _DNI; }
//            set { _DNI = value; }
//        }

//        public String Nombres
//        {
//            get { return _Nombres; }
//            set { _Nombres = value; }
//        }

//        public String ApellidoPaterno
//        {
//            get { return _ApellidoPaterno; }
//            set { _ApellidoPaterno = value; }
//        }

//        public String ApellidoMaterno
//        {
//            get { return _ApellidoMaterno; }
//            set { _ApellidoMaterno = value; }
//        }

//        public int Edad
//        {
//            get { return _Edad; }
//            set { _Edad = value; }
//        }

//        public String Correo
//        {
//            get { return _Correo; }
//            set { _Correo = value; }
//        }

//        public String Clave
//        {
//            get { return _Clave; }
//            set { _Clave = value; }
//        }

//        //[Required(ErrorMessage = "El TIPO es Obligatorio")]
//        public String Tipo
//        {
//            get { return _Tipo; }
//            set { _Tipo = value; }
//        }

//        public String TipoDesc
//        {
//            get
//            {
//                if (_Tipo != null)
//                {
//                    if (_Tipo.Equals("R"))
//                        return "Residente";
//                    else if (_Tipo.Equals("P"))
//                        return "Propietario";
//                    else if (_Tipo.Equals("A"))
//                        return "Administrador";
//                    else
//                        return "-";
//                }
//                else
//                {
//                    return "-";
//                }
//            }
//        }
//    }
//}