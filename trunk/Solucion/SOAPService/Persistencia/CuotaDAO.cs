using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAPService.Dominio;
using System.Data.SqlClient;

namespace SOAPService.Persistencia
{
    public class CuotaDAO
    {
        private ViviendaDAO viviendaDAO = new ViviendaDAO();

        public DCuota Crear(DCuota cuotaACrear)
        {
            DCuota cuotaCreado = null;

            string sql = "INSERT INTO cuota VALUES (@idcuota, @mes, @anio, @importe, @fechavencimiento, @numvivienda, @estado)";
            
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idcuota", cuotaACrear.IdCuota));
                    com.Parameters.Add(new SqlParameter("@mes", cuotaACrear.Mes));
                    com.Parameters.Add(new SqlParameter("@anio", cuotaACrear.Anio));
                    com.Parameters.Add(new SqlParameter("@importe", cuotaACrear.Importe));
                    com.Parameters.Add(new SqlParameter("@fechavencimiento", cuotaACrear.FechaVencimiento));
                    com.Parameters.Add(new SqlParameter("@numvivienda", cuotaACrear.NumVivienda.NumVivienda));
                    com.Parameters.Add(new SqlParameter("@estado", cuotaACrear.Estado));
                    com.ExecuteNonQuery();
                }
            }

            cuotaCreado = Obtener(cuotaACrear.IdCuota);

            return cuotaCreado;
        }

        public DCuota Obtener(int idCuota)
        {
            DCuota cuotaEncontrado = null;

            string sql = "SELECT * FROM cuota WHERE idcuota=@idcuota";

            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();

                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idcuota", idCuota));

                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            cuotaEncontrado = new DCuota();
                            cuotaEncontrado.IdCuota = (int)resultado["idcuota"];
                            cuotaEncontrado.Mes = (string)resultado["mes"];
                            cuotaEncontrado.Anio = (string)resultado["anio"];
                            //cuotaEncontrado.Importe = (double)resultado["importe"];
                            cuotaEncontrado.FechaVencimiento = (DateTime)resultado["fechavencimiento"];
                            cuotaEncontrado.NumVivienda = viviendaDAO.Obtener((int)resultado["numvivienda"]);
                            cuotaEncontrado.Estado = (string)resultado["mes"];
                        }
                    }
                }
            }

            return cuotaEncontrado;
        }

        public DCuota Modificar(DCuota cuotaAModificar)
        {
            DCuota cuotaModificado = null;
            string sql = "UPDATE cuota SET mes=@mes, anio=@anio, importe=@importe, fechavencimiento=@fechavencimiento, numvivienda=@numvivienda, estado=@estado WHERE idcuota=@idcuota";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idcuota", cuotaAModificar.IdCuota));
                    com.Parameters.Add(new SqlParameter("@mes", cuotaAModificar.Mes));
                    com.Parameters.Add(new SqlParameter("@anio", cuotaAModificar.Anio));
                    com.Parameters.Add(new SqlParameter("@importe", cuotaAModificar.Importe));
                    com.Parameters.Add(new SqlParameter("@fechavencimiento", cuotaAModificar.FechaVencimiento));
                    com.Parameters.Add(new SqlParameter("@numvivienda", cuotaAModificar.NumVivienda));
                    com.Parameters.Add(new SqlParameter("@estado", cuotaAModificar.Estado));
                }
            }
            cuotaModificado = Obtener(cuotaAModificar.IdCuota);
            return cuotaModificado;
        }

        public void Eliminar(DCuota cuotaAEliminar)
        {
            string sql = "DELETE FROM cuota WHERE idcuota=@idcuota";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idcuota", cuotaAEliminar.IdCuota));
                    com.ExecuteNonQuery();
                }
            }
        }

        public List<DCuota> ListarTodos()
        {
            List<DCuota> cuotasEncontradas = new List<DCuota>();
            DCuota cuotaEncontrada = null;

            string sql = "SELECT * FROM cuota";

            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();

                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            cuotaEncontrada = new DCuota();

                            cuotaEncontrada.IdCuota = (int)resultado["idcuota"];
                            cuotaEncontrada.Mes = (string)resultado["mes"];
                            cuotaEncontrada.Anio = (string)resultado["anio"];
                            //cuotaEncontrada.Importe = (double)resultado["importe"];
                            cuotaEncontrada.FechaVencimiento = (DateTime)resultado["fechavencimiento"];
                            cuotaEncontrada.NumVivienda = viviendaDAO.Obtener((int)resultado["numvivienda"]);
                            cuotaEncontrada.Estado = (string)resultado["mes"];

                            cuotasEncontradas.Add(cuotaEncontrada);
                        }
                    }
                }
            }
            return cuotasEncontradas;
        }

        //public ICollection<DCuota> ListarMorosos(String estado, DateTime fecha) 
        //{
        //    using (ISession sesion = NHibernateHelper.AbrirSesion()) 
        //    {
        //        ICollection<DCuota> resultado = sesion
        //                .CreateCriteria(typeof(DCuota))
        //                .Add(Restrictions.Eq("Estado", estado))
        //                .Add(Restrictions.Lt("FechaVencimiento", fecha))
        //                .List<DCuota>();
        //        return resultado;
        //    }

        //}
        //public ICollection<DCuota> obtenerCuotaPorViviendaPeriodo(int numVivienda, String anio, String mes) 
        //{
        //    using (ISession sesion = NHibernateHelper.AbrirSesion()) 
        //    {
        //        ICollection<DCuota> resultado = sesion
        //            .CreateCriteria(typeof(DCuota))
        //            .Add(Restrictions.Eq("Anio", anio))
        //            .Add(Restrictions.Eq("mes", mes))
        //            .CreateCriteria("Vivienda")
        //            .Add(Restrictions.Eq("NumVivienda", numVivienda))
        //            .List<DCuota>();
        //        return resultado;
        //    }
        //}
    }
}