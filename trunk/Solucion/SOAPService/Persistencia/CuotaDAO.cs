using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAPService.Dominio;
using System.Data.SqlClient;
using System.Collections;
using System.ServiceModel.Channels;
using NHibernate;
using NHibernate.Criterion;


namespace SOAPService.Persistencia
{
    public class CuotaDAO : BaseDAO<DCuota, String>
    {
        public ICollection<DCuota> ListarMorosos(String estado, DateTime fecha) 
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion()) 
            {
                ICollection<DCuota> resultado = sesion
                        .CreateCriteria(typeof(DCuota))
                        .Add(Restrictions.Eq("Estado", estado))
                        .Add(Restrictions.Lt("FechaVencimiento", fecha))
                        .List<DCuota>();
                return resultado;
            }

        }
        public ICollection<DCuota> obtenerCuotaPorViviendaPeriodo(int numVivienda, String anio, String mes) 
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion()) 
            {
                ICollection<DCuota> resultado = sesion
                    .CreateCriteria(typeof(DCuota))
                    .Add(Restrictions.Eq("Anio", anio))
                    .Add(Restrictions.Eq("mes", mes))
                    .CreateCriteria("Vivienda")
                    .Add(Restrictions.Eq("NumVivienda", numVivienda))
                    .List<DCuota>();
                return resultado;
            }
        }
    }
}