using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SOAPService.Dominio
{
    [DataContract]
    public class DCuota
    {
        [DataMember]
        public int IdCuota { get; set; }
        [DataMember]
        public String Mes { get; set; }
        [DataMember]
        public String Anio { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public DVivienda Vivienda { get; set; }
        [DataMember]
        public String Estado { get; set; }
    }
}