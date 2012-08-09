﻿using System;
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
            DVivienda viviendaACrear = new DVivienda();

            viviendaACrear.NumVivienda = dvivienda.NumVivienda;
            viviendaACrear.Ubicacion = dvivienda.Ubicacion;
            viviendaACrear.Numero = dvivienda.Numero;
            viviendaACrear.Metraje = dvivienda.Metraje;
            viviendaACrear.Tipo = dvivienda.Tipo;
            viviendaACrear.Residente = dvivienda.Residente;

            return ViviendaDAO.Crear(viviendaACrear);
        }

        public DVivienda ObtenerVivienda(Int32 numvivienda)
        {
            return ViviendaDAO.Obtener(numvivienda);
        }

        public DVivienda ModificarVivienda(DVivienda dvivienda)
        {
            DVivienda viviendaAModificar = new DVivienda();
            
            viviendaAModificar.NumVivienda = dvivienda.NumVivienda;
            viviendaAModificar.Ubicacion = dvivienda.Ubicacion;
            viviendaAModificar.Numero = dvivienda.Numero;
            viviendaAModificar.Metraje = dvivienda.Metraje;
            viviendaAModificar.Tipo = dvivienda.Tipo;
            viviendaAModificar.Residente = dvivienda.Residente;

            return ViviendaDAO.Modificar(viviendaAModificar);
        }

        public void EliminarVivienda(DVivienda dvivienda)
        {
            //DVivienda viviendaAEliminar = new DVivienda()
            //{
            //    NumVivienda = dvivienda.NumVivienda,
            //    Ubicacion = dvivienda.Ubicacion,
            //    Numero = dvivienda.Numero,
            //   Metraje = dvivienda.Metraje,
            //    Tipo = dvivienda.Tipo,
            //    Residente = dvivienda.Residente
            //};
            ViviendaDAO.Eliminar(dvivienda);
        }

        public ICollection<DVivienda> ListarTodosLasViviendas()
        {
            return ViviendaDAO.ListarTodos();
        }

        #endregion
    }
}
