using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAPService.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena()
        {
            //return "Data Source=447587A2423/SQLEXPRESS;AttachDbFilename='D:/User/DValenzuela/UPC/04Ciclo/ DESARROLLO PARA ENTORNO WEB/CONDOMINIO.mdf';Integrated Security=True";
            //return "Data Source=ANDERCREMA;Initial Catalog=CONDOMINIO;User ID=sa;Password=***********";
            //return "Data Source=localhost;Initial Catalog=Condominio;User Id=condominio;Password=condominio; Integrated Security=True";
            return "Data Source=(local);Initial Catalog=CONDOMINIO;Integrated Security=True";
        }
    }
}