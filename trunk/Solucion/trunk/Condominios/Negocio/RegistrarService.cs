using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Condominios.Persistencia;
using Condominios.Dominio;

namespace Condominios.Negocio
{
    public class RegistrarService
    {
        // Dependencias con la capa de persistencia
        public ResidenteDAO ResidenteDAO { get; set; }
        public ViviendaDAO ViviendaDAO { get; set; }

        // Lógica de negocio
        #region "Residente"
        public Residente RegistrarResidente(Residente residente)
        {
            // Validación de DNI obligatorio
            if (null == residente.DNI || String.Empty.Equals(residente.DNI))
                throw new Exception("No se puede registrar un Residente sin DNI");

            // Validación de longitud de DNI = 8
            if (residente.DNI.Length != 8)
                throw new Exception("El DNI debe tener 8 posiciones");

            // Validación de existencia de un residente con el mismo DNI
            if (ResidenteDAO.Obtener(residente.DNI) != null)
                throw new Exception("Ya existe un Residente con el DNI indicado");

            // Validación de existencia de un residente con el mismo Correo
            if (ResidenteDAO.BuscarCorreo(residente.Correo).Count > 0)
                throw new Exception("Ya existe un Residente con el Correo indicado");            
            
            if (null == residente.Tipo || String.Empty.Equals(residente.Tipo))
                throw new Exception("No se puede registrar un residente sin el Tipo");
            
            // Validación de edad aceptable
            if (residente.Edad < 18)
                throw new Exception("Para poder registrarse debe ser mayor de edad");
            
            Residente residenteACrear = new Residente();

            residenteACrear.DNI = residente.DNI;
            residenteACrear.Nombres = residente.Nombres;
            residenteACrear.ApellidoPaterno = residente.ApellidoPaterno;
            residenteACrear.ApellidoMaterno = residente.ApellidoMaterno;
            residenteACrear.Edad = residente.Edad;
            residenteACrear.Correo = residente.Correo;
            residenteACrear.Clave = residente.Clave;
            residenteACrear.Tipo = residente.Tipo;

            return ResidenteDAO.Crear(residenteACrear);
        }

        public Residente ObtenerResidente(String codigo)
        {
            // Aquí deben ir las validaciones, reglas de negocio, algoritmos, etc.
            return ResidenteDAO.Obtener(codigo);
        }

        public Residente ModificarResidente(Residente residente)
        {
            // Aquí deben ir las validaciones, reglas de negocio, algoritmos, etc.
            return ResidenteDAO.Modificar(residente);
        }

        public void EliminarResidente(Residente residente)
        {
            // Aquí deben ir las validaciones, reglas de negocio, algoritmos, etc.
            ResidenteDAO.Eliminar(residente);
        }

        public ICollection<Residente> ListarTodosLosAlumnos()
        {
            // Aquí deben ir las validaciones, reglas de negocio, algoritmos, etc.
            return ResidenteDAO.ListarTodosLosResidentes();
        }
        #endregion

        #region "Vivienda"
        public Vivienda RegistrarVivienda(Vivienda vivienda)
        {
            // Validación de existencia de una vivienda
            if (ViviendaDAO.Obtener(vivienda.NumVivienda) != null)
                throw new Exception("Ya existe la Vivienda");

            // Validación de existencia del residente
            Residente residente = ResidenteDAO.Obtener(vivienda.Residente.DNI);
            if (residente == null)
                throw new Exception("Residente inexistente");

            if (null == vivienda.Tipo || String.Empty.Equals(vivienda.Tipo))
                throw new Exception("No se puede registrar un residente sin el Tipo");

            if (ViviendaDAO.obtenerViviendaPorResidente(residente.DNI).Count>0)
                throw new Exception("El residente ingresado ya tiene vivienda registrada");

            Vivienda viviendaACrear = new Vivienda();

            viviendaACrear.NumVivienda = vivienda.NumVivienda;
            viviendaACrear.Ubicacion = vivienda.Ubicacion;
            viviendaACrear.Numero = vivienda.Numero;
            viviendaACrear.Metraje = vivienda.Metraje;
            viviendaACrear.Tipo = vivienda.Tipo;
            viviendaACrear.Residente = vivienda.Residente;

            return ViviendaDAO.Crear(viviendaACrear);
        }

        public Vivienda ObtenerVivienda(Int32 NumVivienda)
        {
            // Aquí deben ir las validaciones, reglas de negocio, algoritmos, etc.
            return ViviendaDAO.Obtener(NumVivienda);
        }

        public Vivienda ModificarVivienda(Vivienda vivienda)
        {
            // Aquí deben ir las validaciones, reglas de negocio, algoritmos, etc.
            return ViviendaDAO.Modificar(vivienda);
        }

        public void EliminarVivienda(Vivienda vivienda)
        {
            // Aquí deben ir las validaciones, reglas de negocio, algoritmos, etc.
            ViviendaDAO.Eliminar(vivienda);
        }

        public ICollection<Vivienda> ListarTodasLasViviendas()
        {
            // Aquí deben ir las validaciones, reglas de negocio, algoritmos, etc.
            return ViviendaDAO.ListarTodasLasViviendas();
        }
        #endregion
    }
}