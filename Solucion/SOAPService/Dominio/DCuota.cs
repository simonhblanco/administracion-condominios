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
        public double Importe { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public DVivienda NumVivienda { get; set; }
        [DataMember]
        public String Estado { get; set; }
    }
}