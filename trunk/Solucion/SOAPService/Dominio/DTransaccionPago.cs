using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAPService.Dominio
{
    public class DTransaccionPago
    {
	// Transaccion Pago

	    private int _IdTransaccionPago;
        private DCuota _Cuota;
        private String _TipoPago;
        private DateTime _FechaOperacion;

        public int IdTransaccionPago

        {
            get { return _IdTransaccionPago; }
            set { _IdTransaccionPago = value; }
        }

        public DCuota Cuota
        {
            get { return _Cuota; }
            set { _Cuota = value; }
        }

        public String TipoPago
        {
            get { return _TipoPago; }
            set { _TipoPago = value; }
        }

        public DateTime FechaOperacion
        {
            get { return _FechaOperacion; }
            set { _FechaOperacion = value; }
        }




    }
}