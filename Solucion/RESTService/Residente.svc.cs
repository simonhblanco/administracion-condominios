using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RESTService.Dominio;
using RESTService.Persistencia;

namespace RESTService
{
    public class Residente : IResidente
    {
        ResidenteDAO objResidenteDAO = new ResidenteDAO();

        public DResidente CrearResidente(DResidente residenteACrear)
        {
            return objResidenteDAO.Crear(residenteACrear);
        }

        public DResidente ObtenerResidente(string codigo)
        {
            return objResidenteDAO.Obtener(codigo);
        }

        public DResidente ModificarResidente(DResidente residenteAModificar)
        {
            return objResidenteDAO.Modificar(residenteAModificar );
        }

        public DResidente EliminarResidente(string codigo)
        {
            return objResidenteDAO.Eliminar(codigo);
        }

        public ICollection<DResidente> ListarTodosLosResidentes()
        {
            return objResidenteDAO.ListarTodosLosResidentes();
        }
    }
}
