using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Condominios.Dominio
{
    public class Reserva
    {
        private int _IdReserva;
        private DateTime _Fecha;
        private AreaComun _Area;
        private Vivienda _Vivienda;
        private int _CantidadPersonas;
        private String _NombreResponsable;
        private String _Comentario;

        public int IdReserva
        {
            get { return _IdReserva; }
            set { _IdReserva = value; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public AreaComun Area
        {
            get { return _Area; }
            set { _Area = value; }
        }

        public Vivienda Vivienda
        {
            get { return _Vivienda; }
            set { _Vivienda = value; }
        }

        public int CantidadPersonas
        {
            get { return _CantidadPersonas; }
            set { _CantidadPersonas = value; }
        }

        public String NombreResponsable
        {
            get { return _NombreResponsable; }
            set { _NombreResponsable = value; }
        }

        public String Comentario
        {
            get { return _Comentario; }
            set { _Comentario = value; }
        }
    }
}