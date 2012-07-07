using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Condominios.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace Condominios.Persistencia
{
    public class CuotaDAO : BaseDAO<Cuota, Int32>
    {
        public ICollection<Cuota> ListarMorosos(String estado, DateTime fecha)
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion())
            {
                ICollection<Cuota> resultado = sesion
                        .CreateCriteria(typeof(Cuota))
                        .Add(Restrictions.Eq("Estado", estado))
                        .Add(Restrictions.Lt("FechaVencimiento", fecha))
                        .List<Cuota>();
                return resultado;
            }
        }

        public ICollection<Cuota> obtenerCuotaPorViviendaPeriodo(int numVivienda, String anio, String mes)
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion())
            {
                ICollection<Cuota> resultado = sesion
                        .CreateCriteria(typeof(Cuota))
                        .Add(Restrictions.Eq("Anio", anio))
                        .Add(Restrictions.Eq("Mes", mes))
                        .CreateCriteria("Vivienda")
                        .Add(Restrictions.Eq("NumVivienda",numVivienda))
                        .List<Cuota>();
                return resultado;
            }
        }

        public ICollection<Cuota> ListarTodasLasCuotas()
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion())
            {
                ICollection<Cuota> resultado = sesion
                        .CreateCriteria(typeof(Cuota))
                        .List<Cuota>();
                return resultado;
            }
        }

        public ICollection<Cuota> CuotasPendientes(int numVivienda)
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion())
            {
                ICollection<Cuota> resultado = sesion
                        .CreateCriteria(typeof(Cuota))
                        .Add(Restrictions.Eq("Estado", "P"))
                        .AddOrder(Order.Asc("FechaVencimiento"))
                        .CreateCriteria("Vivienda")
                        .Add(Restrictions.Eq("NumVivienda", numVivienda))
                        .List<Cuota>();
                return resultado;
            }
        }
    }
}