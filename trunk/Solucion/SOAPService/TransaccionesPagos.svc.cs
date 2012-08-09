using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SOAPService.Dominio;
using SOAPService.Persistencia;

namespace SOAPService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "TransaccionesPagos" en el código, en svc y en el archivo de configuración a la vez.
    public class TransaccionesPagos : ITransaccionesPagos
    {
        private TransaccionPagoDAO transaccionPagoDAO = null;
        private TransaccionPagoDAO TransaccionPagoDAO
        {
            get
            {
                if (transaccionPagoDAO == null)
                    transaccionPagoDAO = new TransaccionPagoDAO();
                return transaccionPagoDAO;
            }
        }

        private CuotaDAO cuotaDAO = null;
        private CuotaDAO CuotaDAO
        {
            get
            {
                if (cuotaDAO == null)
                    cuotaDAO = new CuotaDAO();
                return cuotaDAO;
            }
        }


        public DTransaccionPago CrearTransaccion(DTransaccionPago dTransaccionPago)
        {
            DCuota cuotaExistente = CuotaDAO.Obtener(dTransaccionPago.Cuota.IdCuota);
            DTransaccionPago transaccionACrear = new DTransaccionPago();

            transaccionACrear.IdTransaccionPago = dTransaccionPago.IdTransaccionPago;
            transaccionACrear.TipoPago = dTransaccionPago.TipoPago;
            transaccionACrear.FechaOperacion = dTransaccionPago.FechaOperacion;
            transaccionACrear.Cuota = cuotaExistente;

            return TransaccionPagoDAO.Crear(transaccionACrear);
        }

        public DTransaccionPago ObtenerTransaccion(int idtransaccionpago)
        {
            return TransaccionPagoDAO.Obtener(idtransaccionpago);
        }

        public DTransaccionPago ModificarTransaccion(DTransaccionPago dTransaccionPago)
        {
            DCuota cuotaExistente = CuotaDAO.Obtener(dTransaccionPago.Cuota.IdCuota);
            DTransaccionPago transaccionAModificar = new DTransaccionPago();

            transaccionAModificar.IdTransaccionPago = dTransaccionPago.IdTransaccionPago;
            transaccionAModificar.TipoPago = dTransaccionPago.TipoPago;
            transaccionAModificar.FechaOperacion = dTransaccionPago.FechaOperacion;
            transaccionAModificar.Cuota = cuotaExistente;

            return TransaccionPagoDAO.Modificar(transaccionAModificar);
        }

        public void EliminarTransaccion(int idtransaccionpago)
        {
            DTransaccionPago transaccionExistente = TransaccionPagoDAO.Obtener(idtransaccionpago);
            TransaccionPagoDAO.Eliminar(transaccionExistente.IdTransaccionPago);
        }
    }
}
