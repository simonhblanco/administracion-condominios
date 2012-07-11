using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Condominios.Dominio
{
    public class TransaccionPago
    {
        private int _IdTransaccionPago;
        private Cuota _Cuota;
        private String _TipoPago;
        private DateTime _FechaOperacion;

        public int IdTransaccionPago
        {
            get { return _IdTransaccionPago; }
            set { _IdTransaccionPago = value; }
        }

        public Cuota Cuota
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