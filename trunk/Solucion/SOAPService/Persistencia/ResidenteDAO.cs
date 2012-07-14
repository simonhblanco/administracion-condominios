using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAPService.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace SOAPService.Persistencia
{
    public class ResidenteDAO : BaseDAO<ResidenteEntidad, String>
    {
        //public ICollection<DResidente> ListarTodosLosResidentes()
        //{
        //    using (ISession sesion = NHibernateHelper.AbrirSesion())
        //    {
        //        ICollection<DResidente> resultado = sesion
        //                .CreateCriteria(typeof(DResidente))
        //                .List<DResidente>();
        //        return resultado;
        //    }
        //}

        //public ICollection<DResidente> BuscarCorreo(String correo)
        //{
        //    using (ISession sesion = NHibernateHelper.AbrirSesion())
        //    {
        //        ICollection<DResidente> resultado = sesion
        //                .CreateCriteria(typeof(DResidente))
        //                .Add(Restrictions.Eq("Correo", correo))
        //                .List<DResidente>();
        //        return resultado;
        //    }
        //}
    }
}