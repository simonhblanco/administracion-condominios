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

        #region Miembros de IViviendas

        public DVivienda CrearVivienda(DVivienda dvivienda)
        {
            DVivienda viviendaACrear = new DVivienda()
            {
                NumVivienda = dvivienda.NumVivienda,
                Ubicacion = dvivienda.Ubicacion,
                Numero = dvivienda.Numero,
                Metraje = dvivienda.Metraje,
                Tipo = dvivienda.Tipo,
                Residente = dvivienda.Residente
            };

            return ViviendaDAO.Crear(viviendaACrear);
        }

        public DVivienda ObtenerVivienda(int numvivienda)
        {
            return ViviendaDAO.Obtener(numvivienda);
        }

        public DVivienda ModificarVivienda(DVivienda dvivienda)
        {
            DVivienda viviendaAModificar = new DVivienda()
            {
                NumVivienda = dvivienda.NumVivienda,
                Ubicacion = dvivienda.Ubicacion,
                Numero = dvivienda.Numero,
                Metraje = dvivienda.Metraje,
                Tipo = dvivienda.Tipo,
                Residente = dvivienda.Residente
            };

            return ViviendaDAO.Modificar(viviendaAModificar);
        }

        public DVivienda EliminarVivienda(DVivienda dvivienda)
        {
            DVivienda viviendaAEliminar = new DVivienda()
            {
                NumVivienda = dvivienda.NumVivienda,
                Ubicacion = dvivienda.Ubicacion,
                Numero = dvivienda.Numero,
                Metraje = dvivienda.Metraje,
                Tipo = dvivienda.Tipo,
                Residente = dvivienda.Residente
            };
            return ViviendaDAO.Eliminar(viviendaAEliminar);
        }

        public ICollection<DVivienda> ListarTodosLasViviendas()
        {
            return ViviendaDAO.ListarTodosLasViviendas();
        }

        #endregion
    }
}
