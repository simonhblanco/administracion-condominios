﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAPService.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena()
        {
            return "Data Source=.;Initial Catalog=CONDOMINIO;Integrated Security=True";
            //return "Data Source=ANDERCREMA;Initial Catalog=CONDOMINIO;User ID=sa;Password=***********";
        }
    }
}