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
    public class ResidenteDAO
    {
        public DResidente Crear(DResidente residenteACrear)
        {
            DResidente residenteCreado = null;

            string sentencia = "INSERT INTO residente (dni, apellidopaterno, apellidomaterno, nombres, edad, correo, clave, tipo) VALUES (@dni,@apellidopaterno, @apellidomaterno, @nombres, @edad, @correo, @clave, @tipo)";

            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", residenteACrear.DNI));
                    comando.Parameters.Add(new SqlParameter("@apellidopaterno", residenteACrear.ApellidoPaterno));
                    comando.Parameters.Add(new SqlParameter("@apellidomaterno", residenteACrear.ApellidoMaterno));
                    comando.Parameters.Add(new SqlParameter("@nombres", residenteACrear.Nombres));
                    comando.Parameters.Add(new SqlParameter("@edad", residenteACrear.Edad));
                    comando.Parameters.Add(new SqlParameter("@correo", residenteACrear.Correo));
                    comando.Parameters.Add(new SqlParameter("@clave", residenteACrear.Clave));
                    comando.Parameters.Add(new SqlParameter("@tipo", residenteACrear.Tipo));
                    comando.ExecuteNonQuery();
                }
            }

            residenteCreado = Obtener(residenteACrear.DNI);

            return Obtener(residenteACrear.DNI);
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
                        residenteExistente.Clave = (string)resultado["clave"];
                        residenteExistente.Tipo = (string)resultado["tipo"];
                    }
                }
            }

            return residenteExistente;
        }

        public DResidente Modificar(DResidente residenteAModificar)
        {
            DResidente residenteModificado = null;

            string sentencia = "update residente set apellidopaterno = @apellidopaterno, apellidomaterno =  @apellidomaterno, clave = @clave, correo = @correo, edad = @edad, nombres = @nombres, tipo = @tipo where dni = @dni";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@apellidopaterno", residenteAModificar.ApellidoPaterno));
                    comando.Parameters.Add(new SqlParameter("@apellidomaterno", residenteAModificar.ApellidoMaterno));
                    comando.Parameters.Add(new SqlParameter("@nombres", residenteAModificar.Nombres));
                    comando.Parameters.Add(new SqlParameter("@clave", residenteAModificar.Clave));
                    comando.Parameters.Add(new SqlParameter("@correo", residenteAModificar.Correo));
                    comando.Parameters.Add(new SqlParameter("@edad", residenteAModificar.Edad));
                    comando.Parameters.Add(new SqlParameter("@tipo", residenteAModificar.Tipo));
                    comando.Parameters.Add(new SqlParameter("@dni", residenteAModificar.DNI));
                    comando.ExecuteNonQuery();
                }
            }

            residenteModificado = Obtener(residenteAModificar.DNI);

            return residenteModificado;
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