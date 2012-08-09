using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SOAPService.Persistencia;
using SOAPService.Dominio;

namespace SOAPService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Viviendas" en el código, en svc y en el archivo de configuración a la vez.
    public class Viviendas : IViviendas
    {
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

        private ResidenteDAO residenteDAO = null;

        private ResidenteDAO ResidenteDAO
        {
            get
            {
                if (residenteDAO == null)
                    residenteDAO = new ResidenteDAO();
                return residenteDAO;
            }
        }

        #region Miembros de IViviendas

        public DVivienda CrearVivienda(DVivienda dvivienda)
        {
            DResidente residenteExistente = ResidenteDAO.Obtener(dvivienda.Residente.DNI);

            DVivienda viviendaACrear = new DVivienda();

            viviendaACrear.NumVivienda = dvivienda.NumVivienda;
            viviendaACrear.Ubicacion = dvivienda.Ubicacion;
            viviendaACrear.Numero = dvivienda.Numero;
            viviendaACrear.Metraje = dvivienda.Metraje;
            viviendaACrear.Tipo = dvivienda.Tipo;
            viviendaACrear.Residente = residenteExistente;

            return ViviendaDAO.Crear(viviendaACrear);
        }

        public DVivienda ObtenerVivienda(Int32 numvivienda)
        {
            return ViviendaDAO.Obtener(numvivienda);
        }

        public DVivienda ModificarVivienda(DVivienda dvivienda)
        {
            DResidente residenteExistente = ResidenteDAO.Obtener(dvivienda.Residente.DNI);

            DVivienda viviendaAModificar = new DVivienda();
            
            viviendaAModificar.NumVivienda = dvivienda.NumVivienda;
            viviendaAModificar.Ubicacion = dvivienda.Ubicacion;
            viviendaAModificar.Numero = dvivienda.Numero;
            viviendaAModificar.Metraje = dvivienda.Metraje;
            viviendaAModificar.Tipo = dvivienda.Tipo;
            viviendaAModificar.Residente = residenteExistente;

            return ViviendaDAO.Modificar(viviendaAModificar);
        }

        public void EliminarVivienda(DVivienda dvivienda)
        {
            DVivienda viviendaExistente = ViviendaDAO.Obtener(dvivienda.NumVivienda);
            ViviendaDAO.Eliminar(viviendaExistente);
        }

        public ICollection<DVivienda> ListarTodosLasViviendas()
        {
            return ViviendaDAO.ListarTodos();
        }

        #endregion
    }
}
