using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace Condominios.Persistencia
{
    public class NHibernateHelper
    {
        private static ISessionFactory _FabricaDeSesiones; //Fábrica de conexiones

        private static ISessionFactory FabricaDeSesiones
        {
            get
            {
                if (_FabricaDeSesiones == null)
                {
                    var configuration = new Configuration();
                    // Primero le indicamos el archivo xml que contendrá la cadena y datos de conexión a BD
                    configuration.Configure(typeof(NHibernateHelper).Assembly, "Condominios.Persistencia.nhibernate.cfg.xml");
                    // Segundo, le indicamos CÓMO va a buscar los *.hbm.xml
                    configuration.AddAssembly(typeof(NHibernateHelper).Assembly);
                    // Construir la fábrica de conexiones
                    _FabricaDeSesiones = configuration.BuildSessionFactory();
                }
                return _FabricaDeSesiones;
            }
        }

        public static ISession AbrirSesion()
        {
            return FabricaDeSesiones.OpenSession();
        }
    }
}