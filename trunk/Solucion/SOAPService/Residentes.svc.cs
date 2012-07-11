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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Residentes" en el código, en svc y en el archivo de configuración a la vez.
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

            return residenteDAO.Crear(residenteACrear);
        }
    }
}
