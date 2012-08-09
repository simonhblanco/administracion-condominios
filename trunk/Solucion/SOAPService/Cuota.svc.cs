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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Cuota" in code, svc and config file together.
    public class Cuota : ICuota
    {

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

        private ViviendaDAO viviendaDAO = null;
        private ViviendaDAO ViviendaDAO
        {
            get
            {
                if (viviendaDAO == null)
                    viviendaDAO = new ViviendaDAO();
                return viviendaDAO;
            }
        }

        public DCuota CrearCuota(DCuota dcuota)
        {
            DVivienda viviendaExistente = ViviendaDAO.Obtener(dcuota.Vivienda.NumVivienda);
            DCuota cuotaACrear = new DCuota()
            {
                IdCuota = dcuota.IdCuota,
                Mes = dcuota.Mes,
                Anio = dcuota.Anio,
                Importe = dcuota.Importe,
                FechaVencimiento = dcuota.FechaVencimiento,
                Vivienda = viviendaExistente,
                Estado = dcuota.Estado
            };
            return CuotaDAO.Crear(cuotaACrear);
        }

        public DCuota ObtenerCuota(int idcuota)
        {
            return CuotaDAO.Obtener(idcuota);
        }

        public DCuota ModificarCuota(DCuota dcuota)
        {
            DVivienda viviendaExistente = ViviendaDAO.Obtener(dcuota.Vivienda.NumVivienda);
            DCuota cuotaAModificar = new DCuota()
            {
                IdCuota = dcuota.IdCuota,
                Mes = dcuota.Mes,
                Anio = dcuota.Anio,
                Importe = dcuota.Importe,
                FechaVencimiento = dcuota.FechaVencimiento,
                Vivienda = viviendaExistente,
                Estado = dcuota.Estado
            };
            return CuotaDAO.Modificar(cuotaAModificar);
        }

        public void EliminarCuota(int idcuota)
        {
            DCuota cuotaExistente = CuotaDAO.Obtener(idcuota);
            CuotaDAO.Eliminar(cuotaExistente);
        }

        public ICollection<DCuota> ListarCuotas()
        {
            return CuotaDAO.ListarTodos();
        }
    }
}
