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
    public class Residentes : IResidentes
    {
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

        public DResidente CrearResidente(DResidente dresidente)
        {
            DResidente residenteACrear = new DResidente()
            {
                DNI = dresidente.DNI,
                Nombres = dresidente.Nombres,
                ApellidoPaterno = dresidente.ApellidoMaterno,
                ApellidoMaterno = dresidente.ApellidoMaterno,
                Edad = dresidente.Edad,
                Correo = dresidente.Correo,
                Clave = dresidente.Clave,
                Tipo = dresidente.Tipo
            };

            return ResidenteDAO.Crear(residenteACrear);
        }
    }
}
