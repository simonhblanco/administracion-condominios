﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTServices.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena()
        {
            //return "Data Source=VANESSA-HP\\SQLEXPRESS;Initial Catalog=CONDOMINIO;Integrated Security=True";
            //return "Data Source=447587A2423\\SQLEXPRESS;Initial Catalog=CONDOMINIO;Integrated Security=True";
            //return "Data Source=MAGCORTEZJ;Initial Catalog=CONDOMINIO;User ID=sa;Password=jackforever";
            return "Data Source=JOSE-A7CA3C2C3A\\SQLEXPRESS;Initial Catalog=CONDOMINIO;Integrated Security=True";
            //base de datos
        }
    }
}
