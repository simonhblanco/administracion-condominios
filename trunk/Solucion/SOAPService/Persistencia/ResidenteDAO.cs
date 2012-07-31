using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAPService.Dominio;
using NHibernate;
using NHibernate.Criterion;
using System.Data.SqlClient;

namespace SOAPService.Persistencia
{
    public class ResidenteDAO : BaseDAO<DResidente, String>
    {
        public DResidente Crear(DResidente residente)
        {
            //int nuevoCodigo = ObtenerNuevoCodigo();
            string sentencia = "INSERT INTO residente (dni, apellidopaterno, apellidomaterno, nombres, edad, correo, clave, tipo) VALUES (@dni,@apellidopaterno, @apellidomaterno, @nombres, @edad, @correo, @clave, @tipo)";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", residente.DNI));
                    comando.Parameters.Add(new SqlParameter("@apellidopaterno", residente.ApellidoPaterno));
                    comando.Parameters.Add(new SqlParameter("@apellidomaterno", residente.ApellidoMaterno));
                    comando.Parameters.Add(new SqlParameter("@nombres", residente.Nombres));
                    comando.Parameters.Add(new SqlParameter("@edad", residente.Edad));
                    comando.Parameters.Add(new SqlParameter("@correo", residente.Correo));
                    comando.Parameters.Add(new SqlParameter("@clave", residente.Clave));
                    comando.Parameters.Add(new SqlParameter("@tipo", residente.Tipo));
                    comando.ExecuteNonQuery();
                }
            }
            return Obtener(residente.DNI);
        }
        public DResidente Obtener(string dni)
        {
            DResidente residenteExistente = null;
            string sentencia = "SELECT * FROM residente WHERE dni=@dni";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", dni));
                    SqlDataReader resultado = comando.ExecuteReader();
                    if (resultado.Read())
                    {
                        residenteExistente = new DResidente();
                        residenteExistente.DNI = (string)resultado["dni"];
                        residenteExistente.Nombres = (string)resultado["nombres"];
                        residenteExistente.ApellidoPaterno = (string)resultado["apellidopaterno"];
                        residenteExistente.ApellidoMaterno = (string)resultado["apellidomaterno"];
                        residenteExistente.Edad = (int)resultado["edad"];
                        residenteExistente.Correo = (string)resultado["correo"];
                        //Se agregó campos para que se visualice en el WCF ya que no salia campos de la tabla RESIDENTE.
                    }
                }
            }
            return residenteExistente;
        }
        public DResidente Modificar(DResidente residente)
        {
            //int nuevoCodigo = ObtenerNuevoCodigo();
            string sentencia = "update residente set apellidopaterno = @apellidopaterno, apellidomaterno =  @apellidomaterno, clave = @clave, correo = @correo, edad = @edad, nombres = @nombres, tipo = @tipo where dni = @dni";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@apellidopaterno", residente.ApellidoPaterno));
                    comando.Parameters.Add(new SqlParameter("@apellidomaterno", residente.ApellidoMaterno));
                    comando.Parameters.Add(new SqlParameter("@nombres", residente.Nombres));
                    comando.Parameters.Add(new SqlParameter("@clave", residente.Clave));
                    comando.Parameters.Add(new SqlParameter("@correo", residente.Correo));
                    comando.Parameters.Add(new SqlParameter("@edad", residente.Edad));
                    comando.Parameters.Add(new SqlParameter("@tipo", residente.Tipo));
                    comando.Parameters.Add(new SqlParameter("@dni", residente.DNI));
                    comando.ExecuteNonQuery();
                }
            }
            return Obtener(residente.DNI);
        }
        public DResidente Eliminar(string codigo)
        {
            //int nuevoCodigo = ObtenerNuevoCodigo();
            string sentencia = "delete from residente where dni = @dni";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", codigo));
                    comando.ExecuteNonQuery();
                }
            }
            return Obtener(codigo);
        }
        public ICollection<DResidente> ListarTodosLosResidentes()
        {
            ICollection<DResidente> listaresidente = new List<DResidente>();

            String sentencia = "SELECT * FROM RESIDENTE";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    SqlDataReader resultado = comando.ExecuteReader();
                    while (resultado.Read())
                    {
                        DResidente residenteExistente = new DResidente();
                        residenteExistente.DNI = (String)resultado["dni"];
                        residenteExistente.ApellidoPaterno = (String)resultado["apellidopaterno"];
                        residenteExistente.ApellidoMaterno = (String)resultado["apellidomaterno"];
                        residenteExistente.Nombres = (String)resultado["nombres"];
                        residenteExistente.Edad = (int)resultado["edad"];
                        residenteExistente.Correo = (String)resultado["correo"];
                        residenteExistente.Clave = (String)resultado["clave"];
                        residenteExistente.Tipo = (String)resultado["tipo"];
                        listaresidente.Add(residenteExistente);
                    }
                }
            }
            return listaresidente;
        }



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