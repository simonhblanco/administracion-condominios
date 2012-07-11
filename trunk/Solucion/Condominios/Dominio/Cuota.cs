using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Condominios.Dominio
{
    public class Cuota
    {
        private int _IdCuota;
        private Vivienda _Vivienda;
        private String _Mes;
        private String _Anio;
        private double _Importe;
        private DateTime _FechaVencimiento;
        private String _Estado;

        public int IdCuota
        {
            get { return _IdCuota; }
            set { _IdCuota = value; }
        }

        public Vivienda Vivienda
        {
            get { return _Vivienda; }
            set { _Vivienda = value; }
        }

        public String Mes
        {
            get { return _Mes; }
            set { _Mes = value; }
        }

        public String Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }

        public double Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return _FechaVencimiento; }
            set { _FechaVencimiento = value; }
        }

        public String Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
    }
}