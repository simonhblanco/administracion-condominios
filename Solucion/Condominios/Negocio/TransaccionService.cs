using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Condominios.Persistencia;
using Condominios.Dominio;

namespace Condominios.Negocio
{
    public class TransaccionService
    {
        // Dependencias con la capa de persistencia
        public TransaccionPagoDAO transaccionPagoDAO { get; set; }
        public CuotaDAO CuotaDAO { get; set; }
        public ViviendaDAO ViviendaDAO { get; set; }

        // Lógica de negocio
        public Cuota PagarCuota(int numCuota, String tipoPago)
        {
            Cuota cuota = CuotaDAO.Obtener(numCuota);
            if (cuota == null)
                throw new Exception("La cuota no existe");

            if (cuota.Estado.Equals("C"))
                throw new Exception("La cuota ya se encuentra cancelada");

            TransaccionPago transaccion = new TransaccionPago();
            transaccion.Cuota = cuota;
            transaccion.FechaOperacion = DateTime.Now;
            transaccion.TipoPago = tipoPago;
            transaccionPagoDAO.Crear(transaccion);

            cuota.Estado = "C";
            cuota = CuotaDAO.Modificar(cuota);
            return cuota;
        }

        //public ICollection<Cuota> ConsultarCuotasPendientes(int numVivienda)
        //{
        //    return cuotaDAO.ListarCuotasPendientesPorVivienda(numVivienda);
        //}

        public Cuota MostrarCuota(int numCuota)
        {
            return CuotaDAO.Obtener(numCuota);
        }
               
        public Cuota ColocarCuota(Cuota cuota)
        {
            // Validación de existencia de la vivienda
            Vivienda vivienda = ViviendaDAO.Obtener(cuota.Vivienda.NumVivienda);
            if (vivienda == null)
                throw new Exception("Vivienda inexistente");

            // Validación de existencia de una vivienda
            ICollection<Cuota> cuotaExistente = CuotaDAO.obtenerCuotaPorViviendaPeriodo(cuota.Vivienda.NumVivienda,cuota.Anio,cuota.Mes);
            if (cuotaExistente.Count>0)
                throw new Exception("Ya existe la Cuota");

            Cuota cuotaACrear = new Cuota();

            cuotaACrear.IdCuota = cuota.IdCuota;
            cuotaACrear.Vivienda = cuota.Vivienda;
            cuotaACrear.Mes = cuota.Mes;
            cuotaACrear.Anio = cuota.Anio;
            cuotaACrear.Importe = cuota.Importe;
            cuotaACrear.FechaVencimiento = cuota.FechaVencimiento;
            cuotaACrear.Estado = cuota.Estado;

            return CuotaDAO.Crear(cuotaACrear);
        }

        public Cuota ModificarCuota(Cuota cuota)
        {
            // Aquí deben ir las validaciones, reglas de negocio, algoritmos, etc.
            return CuotaDAO.Modificar(cuota);
        }

        public void EliminarCuota(Cuota cuota)
        {
            // Aquí deben ir las validaciones, reglas de negocio, algoritmos, etc.
            CuotaDAO.Eliminar(cuota);
        }

        public ICollection<Cuota> ListarTodasLasCuotas()
        {
            // Aquí deben ir las validaciones, reglas de negocio, algoritmos, etc.
            return CuotaDAO.ListarTodasLasCuotas();
        }

        public ICollection<Cuota> ConsultarMorosos(String cuotaEstado, DateTime cuotaFecha)
        {
            return CuotaDAO.ListarMorosos(cuotaEstado, cuotaFecha);
        }

        internal ICollection<Cuota> CuotasPendientes(int numVivienda)
        {
            return CuotaDAO.CuotasPendientes(numVivienda);
        }
    }
}