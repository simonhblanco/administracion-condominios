using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SOAPService.Dominio
{
    [DataContract]
    public class DTransaccionPago
    {
	    private int _IdTransaccionPago;
        private DCuota _Cuota;
        private String _TipoPago;
        private DateTime _FechaOperacion;

        [DataMember]
        public int IdTransaccionPago

        {
            get { return _IdTransaccionPago; }
            set { _IdTransaccionPago = value; }
        }

        [DataMember]
        public DCuota Cuota
        {
            get { return _Cuota; }
            set { _Cuota = value; }
        }

        [DataMember]
        public String TipoPago
        {
            get { return _TipoPago; }
            set { _TipoPago = value; }
        }

        [DataMember]
        public DateTime FechaOperacion
        {
            get { return _FechaOperacion; }
            set { _FechaOperacion = value; }
        }




    }
}