using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace Condominios.Persistencia
{
    public abstract class BaseDAO<Entidad, Id>
    {
        public Entidad Crear(Entidad entidad)
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion())
            {
                using (ITransaction transaccion = sesion.BeginTransaction())
                {
                    sesion.Save(entidad);
                    transaccion.Commit();
                }
            }
            return entidad;
        }

        public Entidad Obtener(Id id)
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion())
            {
                return sesion.Get<Entidad>(id);
            }
        }

        public Entidad Modificar(Entidad entidad)
        {
            using (ISession session = NHibernateHelper.AbrirSesion())
            {
                using (ITransaction transaccion = session.BeginTransaction())
                {
                    session.Update(entidad);
                    transaccion.Commit();
                }
            }
            return entidad;
        }

        public void Eliminar(Entidad entidad)
        {
            using (ISession session = NHibernateHelper.AbrirSesion())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entidad);
                    transaction.Commit();
                }
            }
        }
    }
}