using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAPService.Dominio;
using System.Data.SqlClient;

namespace SOAPService.Persistencia
{
    public class ResidenteDAO2
    {
        public ResidenteEntidad Crear(ResidenteEntidad residente)
        {
            //int nuevoCodigo = ObtenerNuevoCodigo();
            string sentencia = "INSERT INTO residente (dni) VALUES (@dni)";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", residente.Dni));
                    comando.ExecuteNonQuery();
                }
            }
            return Obtener(residente.Dni);
        }
        public ResidenteEntidad Obtener(string dni)
        {
            ResidenteEntidad residenteExistente = null;
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
                        residenteExistente = new ResidenteEntidad();
                        residenteExistente.Dni = (string)resultado["dni"];
                    }
                }
            }
            return residenteExistente;
        }
        //private int ObtenerNuevoCodigo()
        //{
        //    int nuevoCodigo = 0;
        //    string sentencia = "SELECT max(codigo) FROM t_cliente";
        //    using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
        //    {
        //        conexion.Open();
        //        using (SqlCommand comando = new SqlCommand(sentencia, conexion))
        //        {
        //            object valor = comando.ExecuteScalar();
        //            if (DBNull.Value.Equals(valor))
        //                nuevoCodigo = 1;
        //            else
        //                nuevoCodigo = (int)valor + 1;
        //        }
        //    }
        //    return nuevoCodigo;
        //}
    }
}