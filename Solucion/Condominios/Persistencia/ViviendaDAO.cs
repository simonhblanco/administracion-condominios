using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Condominios.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace Condominios.Persistencia
{
    public class ViviendaDAO : BaseDAO<Vivienda, Int32>
    {
        public ICollection<Vivienda> ListarTodasLasViviendas()
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion())
            {
                ICollection<Vivienda> resultado = sesion
                        .CreateCriteria(typeof(Vivienda))
                        .List<Vivienda>();
                return resultado;
            }
        }

        public ICollection<Vivienda> obtenerViviendaPorResidente(String dni)
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion())
            {
                ICollection<Vivienda> resultado = sesion
                        .CreateCriteria(typeof(Vivienda))
                        .CreateCriteria("Residente")
                        .Add(Restrictions.Eq("DNI", dni))
                        .List<Vivienda>();
                return resultado;
            }
        }
    }
}