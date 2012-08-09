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
    public class TransaccionPagoDAO
    {
        private CuotaDAO cuotaDAO = new CuotaDAO();

        public DTransaccionPago Crear(DTransaccionPago transaccionACrear)
        {
            DTransaccionPago transaccionCreado = null;

            string sql = "INSERT INTO transaccionpago VALUES (@idtransaccionpago, @tipopago, @fechaoperacion, @idcuota)";

            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idtransaccionpago", transaccionACrear.IdTransaccionPago));
                    com.Parameters.Add(new SqlParameter("@tipopago", transaccionACrear.TipoPago));
                    com.Parameters.Add(new SqlParameter("@fechaoperacion", transaccionACrear.FechaOperacion));
                    com.Parameters.Add(new SqlParameter("@idcuota", transaccionACrear.Cuota.IdCuota));
                    com.ExecuteNonQuery();
                }
            }

            transaccionCreado = Obtener(transaccionACrear.IdTransaccionPago);

            return transaccionCreado;
        }

        public DTransaccionPago Obtener(int IdTransaccionPago)
        {
            DTransaccionPago transaccionEncontrado = null;

            string sql = "SELECT * FROM transaccionpago WHERE idtransaccionpago=@idtransaccionpago";

            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();

                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idtransaccionpago", IdTransaccionPago));

                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            transaccionEncontrado = new DTransaccionPago();

                            transaccionEncontrado.IdTransaccionPago = (int)resultado["idtransaccionpago"];
                            transaccionEncontrado.TipoPago = (string)resultado["tipopago"];
                            transaccionEncontrado.FechaOperacion = (DateTime)resultado["fechaoperacion"];
                            transaccionEncontrado.Cuota = cuotaDAO.Obtener((int)resultado["idcuota"]);
                        }
                    }
                }
            }

            return transaccionEncontrado;
        }

        public DTransaccionPago Modificar(DTransaccionPago transaccionAModificar)
        {
            DTransaccionPago transaccionModificado = null;
            string sql = "UPDATE transaccionpago SET tipopago=@tipopago, fechaoperacion=@fechaoperacion, idcuota=@idcuota WHERE idtransaccionpago=@idtransaccionpago";
            
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idtransaccionpago", transaccionAModificar.IdTransaccionPago));
                    com.Parameters.Add(new SqlParameter("@tipopago", transaccionAModificar.TipoPago));
                    com.Parameters.Add(new SqlParameter("@fechaoperacion", transaccionAModificar.FechaOperacion));
                    com.Parameters.Add(new SqlParameter("@idcuota", transaccionAModificar.Cuota.IdCuota));
                    com.ExecuteNonQuery();
                }
            }

            transaccionModificado = Obtener(transaccionAModificar.IdTransaccionPago);

            return transaccionModificado;
        }

        public void Eliminar(int IdTransaccionPago)
        {
            string sql = "DELETE FROM transaccionpago WHERE idtransaccionpago=@idtransaccionpago";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@idcuota", IdTransaccionPago));
                    com.ExecuteNonQuery();
                }
            }
        }
    }
}