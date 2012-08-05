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
    public class ViviendaDAO : BaseDAO<DVivienda, Int32>
    {
        ResidenteDAO residenteDAO = new ResidenteDAO();

        public DVivienda Crear(DVivienda vivienda)
        {
            string sentencia = "INSERT INTO vivienda(numvivienda, ubicacion, numero, metraje, tipo, dni) VALUES (@numvivienda, @ubicacion, @numero, @metraje, @tipo, @dni)";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand commando = new SqlCommand(sentencia, conexion))
                {
                    commando.Parameters.Add(new SqlParameter("@numvivienda", vivienda.NumVivienda));
                    commando.Parameters.Add(new SqlParameter("@ubicacion", vivienda.Ubicacion));
                    commando.Parameters.Add(new SqlParameter("@numero", vivienda.Numero));
                    commando.Parameters.Add(new SqlParameter("@metraje", vivienda.Metraje));
                    commando.Parameters.Add(new SqlParameter("@tipo", vivienda.Tipo));
                    commando.Parameters.Add(new SqlParameter("@dni", vivienda.Residente.DNI));
                    commando.ExecuteNonQuery();
                }
            }
            return Obtener(vivienda.NumVivienda);
        }

        public DVivienda Obtener(int numvivienda)
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
                        viviendaExistente.NumVivienda = (int)resultado["numvivienda"];
                        viviendaExistente.Ubicacion = (string)resultado["ubicacion"];
                        viviendaExistente.Numero = (int)resultado["numero"];
                        viviendaExistente.Metraje = (int)resultado["metraje"];
                        viviendaExistente.Tipo = (string)resultado["tipo"];
                        viviendaExistente.Residente.DNI = (string)resultado["dni"];
                    }
                    // se agregaron los campos para ser visualizados en el WFC
                }
            }

            return viviendaExistente;
        }

        public DVivienda Modificar(DVivienda vivienda)
        {
            string sentencia = "update vivienda set ubicacion = @ubicacion, numero = @numero, metraje = @metraje, tipo =@tipo, dni=@dni";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    
                    comando.Parameters.Add(new SqlParameter("@ubicacion", vivienda.Ubicacion));
                    comando.Parameters.Add(new SqlParameter("numero", vivienda.Numero));
                    comando.Parameters.Add(new SqlParameter("@metraje", vivienda.Metraje));
                    comando.Parameters.Add(new SqlParameter("@tipo", vivienda.Tipo));
                    comando.Parameters.Add(new SqlParameter("@dni", vivienda.Residente.DNI));
                    comando.ExecuteNonQuery();
                }

            }
            return Obtener(vivienda.NumVivienda);
        }

        public DVivienda Eliminar(int codigovivienda)
        {
            string sentencia = "delete from vivienda where numvivienda = @numvivienda";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@numvivienda", codigovivienda));
                    comando.ExecuteNonQuery();
                }
            }
            return Obtener(codigovivienda);

        }


        public ICollection<DVivienda> ListarTodosLasViviendas()
        {
            ICollection<DVivienda> listavivienda = new List<DVivienda>();

            String sentencia = "SELECT * FROM VIVIENDA";
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
                        viviendaExistente.Residente.DNI = (String)resultado["dni"];
                        listavivienda.Add(viviendaExistente);

                    }
                }
            }
            return listavivienda;
        }
    }
}

