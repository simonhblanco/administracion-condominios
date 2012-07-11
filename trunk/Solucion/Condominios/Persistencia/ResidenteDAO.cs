using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Condominios.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace Condominios.Persistencia
{
    public class ResidenteDAO : BaseDAO<Residente, String>
    {
        public ICollection<Residente> ListarTodosLosResidentes()
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion())
            {
                ICollection<Residente> resultado = sesion
                        .CreateCriteria(typeof(Residente))
                        .List<Residente>();
                return resultado;
            }
        }

        public ICollection<Residente> BuscarCorreo(String correo)
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion())
            {
                ICollection<Residente> resultado = sesion
                        .CreateCriteria(typeof(Residente))
                        .Add(Restrictions.Eq("Correo", correo))
                        .List<Residente>();
                return resultado;
            }
        }
    }
}