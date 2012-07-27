using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAPService.Dominio;
using System.Data.SqlClient;

namespace SOAPService.Persistencia
{
    public class ViviendaDAO : BaseDAO<DVivienda, Int32>
    {
        public DVivienda Crear(DVivienda vivienda)
        {
            string sentencia = "INSERT INTO vivienda (numvivienda, ubicacion, numero, metraje, tipo, dni) VALUES (@numvivienda,@ubicacion, @numero, @metraje, @tipo, @dni)";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@numvivienda", vivienda.NumVivienda));
                    comando.Parameters.Add(new SqlParameter("@ubicacion", vivienda.Ubicacion));
                    comando.Parameters.Add(new SqlParameter("@numero", vivienda.Numero));
                    comando.Parameters.Add(new SqlParameter("@metraje", vivienda.Metraje));
                    comando.Parameters.Add(new SqlParameter("@tipo", vivienda.Tipo));
                    comando.Parameters.Add(new SqlParameter("@dni", vivienda.Residente.DNI));
                    comando.ExecuteNonQuery();
                }
            }
            return Obtener(vivienda.NumVivienda);
        }

        public DVivienda Obtener(Int32 numvivienda)
        {
            DVivienda viviendaExistente = null;
            string sentencia = "SELECT * FROM vivienda WHERE numvivienda=@numvivienda";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@numvivienda", numvivienda));
                    SqlDataReader resultado = comando.ExecuteReader();
                    if (resultado.Read())
                    {
                        viviendaExistente = new DVivienda();
                        viviendaExistente.NumVivienda = (Int32)resultado["numvivienda"];
                    }
                }
            }
            return viviendaExistente;
        }

        //public DVivienda Modificar(DVivienda vivienda)
        //{
        //    string sentencia = "update vivienda set ubicacion = @ubicacion, numero =  @numero, metraje = @metraje, tipo = @tipo where numvivienda = @numvivienda";
        //    using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
        //    {
        //        conexion.Open();
        //        using (SqlCommand comando = new SqlCommand(sentencia, conexion))
        //        {
        //            comando.Parameters.Add(new SqlParameter("@ubicacion", vivienda.Ubicacion));
        //            comando.Parameters.Add(new SqlParameter("@numero", vivienda.Numero));
        //            comando.Parameters.Add(new SqlParameter("@metraje", vivienda.Metraje));
        //            comando.Parameters.Add(new SqlParameter("@tipo", vivienda.Tipo));
        //            comando.Parameters.Add(new SqlParameter("@numvivienda", vivienda.NumVivienda));
        //            comando.ExecuteNonQuery();
        //        }
        //    }
        //    return Obtener(vivienda.NumVivienda);
        //}

        public DVivienda Eliminar(DVivienda vivienda)
        {
            string sentencia = "delete from vivienda where numvivienda = @numvivienda";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@numvivienda", vivienda.NumVivienda));
                    comando.ExecuteNonQuery();
                }
            }
            return Obtener(vivienda.NumVivienda);
        }

        public ICollection<DVivienda> ListarTodasLasViviendas()
        {
            ICollection<DVivienda> listavivienda = new List<DVivienda>();
            ResidenteDAO residenteDao = new ResidenteDAO();
            DResidente residente = new DResidente();

            String sentencia = "SELECT * FROM VIVENDA";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    SqlDataReader resultado = comando.ExecuteReader();
                    while (resultado.Read())
                    {
                        DVivienda viviendaExistente = new DVivienda();
                        viviendaExistente.NumVivienda = (int)resultado["numvivienda"];
                        viviendaExistente.Ubicacion = (String)resultado["ubicacion"];
                        viviendaExistente.Numero = (int)resultado["numero"];
                        viviendaExistente.Metraje = (int)resultado["metraje"];
                        viviendaExistente.Tipo = (String)resultado["tipo"];

                        residente = residenteDao.Obtener((String)resultado["dni"]);

                        viviendaExistente.Residente = residente;
                        listavivienda.Add(viviendaExistente);
                    }
                }
            }
            return listavivienda;
        }
    }
}