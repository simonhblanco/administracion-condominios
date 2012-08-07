using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAPService.Dominio;
using System.Data.SqlClient;

namespace SOAPService.Persistencia
{
    public class ViviendaDAO
    {
        private ResidenteDAO residenteDAO = new ResidenteDAO();

        public DVivienda Crear(DVivienda viviendaACrear)
        {
            DVivienda viviendaCreada = null;

            string sentencia = "INSERT INTO vivienda(numvivienda, ubicacion, numero, metraje, tipo, dni) VALUES (@numvivienda, @ubicacion, @numero, @metraje, @tipo, @dni)";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand commando = new SqlCommand(sentencia, conexion))
                {
                    commando.Parameters.Add(new SqlParameter("@numvivienda", viviendaACrear.NumVivienda));
                    commando.Parameters.Add(new SqlParameter("@ubicacion", viviendaACrear.Ubicacion));
                    commando.Parameters.Add(new SqlParameter("@numero", viviendaACrear.Numero));
                    commando.Parameters.Add(new SqlParameter("@metraje", viviendaACrear.Metraje));
                    commando.Parameters.Add(new SqlParameter("@tipo", viviendaACrear.Tipo));
                    commando.Parameters.Add(new SqlParameter("@dni", viviendaACrear.Residente.DNI));
                    commando.ExecuteNonQuery();
                }
            }

            viviendaCreada = Obtener(viviendaACrear.NumVivienda);

            return viviendaCreada;
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
                        viviendaExistente.Residente = residenteDAO.Obtener((string)resultado["dni"]);
                        
                        //viviendaExistente.Residente = new DResidente()
                        //{
                        //    DNI = (string)resultado["dni"]
                        //};
                    }
                }
            }

            return viviendaExistente;
        }

        public DVivienda Modificar(DVivienda viviendaAModificar)
        {
            DVivienda viviendaModificada = null;

            string sentencia = "update vivienda set ubicacion = @ubicacion, numero = @numero, metraje = @metraje, tipo =@tipo, dni=@dni";
            
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@ubicacion", viviendaAModificar.Ubicacion));
                    comando.Parameters.Add(new SqlParameter("numero", viviendaAModificar.Numero));
                    comando.Parameters.Add(new SqlParameter("@metraje", viviendaAModificar.Metraje));
                    comando.Parameters.Add(new SqlParameter("@tipo", viviendaAModificar.Tipo));
                    comando.Parameters.Add(new SqlParameter("@dni", viviendaAModificar.Residente));
                    comando.ExecuteNonQuery();
                }
            }

            viviendaModificada = Obtener(viviendaAModificar.NumVivienda);

            return viviendaModificada;
        }

        public void Eliminar(DVivienda viviendaAEliminar)
        {
            string sentencia = "delete from vivienda where numvivienda = @numvivienda";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@numvivienda", viviendaAEliminar.NumVivienda));
                    comando.ExecuteNonQuery();
                }
            }
        }


        public ICollection<DVivienda> ListarTodos()
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

