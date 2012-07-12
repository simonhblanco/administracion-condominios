﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Condominios.Negocio;
using Condominios.Dominio;

namespace Condominios.Controllers
{
    public class ResidenteController : Controller
    {
        //Dependencias
        public RegistrarService RegistrarService { get; set; }

        // GET: /Residente/
        public ActionResult Index()
        {
            // Llamamos al negocio para resolver la funcionalidad y obtenemos el "modelo"
            ICollection<Residente> modelo = RegistrarService.ListarTodosLosAlumnos();

            // Elegimos la vista a generar y le entregamos el modelo
            return View(modelo); // La vista se llama Index.aspx
        }

        // GET: /Residente/Details/5
        public ActionResult Details(String DNI)
        {
            Residente modelo = RegistrarService.ObtenerResidente(DNI);

            return View(modelo); //La vista se llama Details.aspx
        }

        // GET: /Residente/Create
        public ActionResult Create()
        {
            return View();
        } 

        // POST: /Residente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Residente residenteACrear = new Residente();
                    residenteACrear.DNI = (String)collection["DNI"];
                    residenteACrear.Nombres = (String)collection["Nombres"];
                    residenteACrear.ApellidoPaterno = (String)collection["ApellidoPaterno"];
                    residenteACrear.ApellidoMaterno = (String)collection["ApellidoMaterno"];
                    residenteACrear.Edad = int.Parse(collection["Edad"]);
                    residenteACrear.Correo = (String)collection["Correo"];
                    residenteACrear.Clave = (String)collection["Clave"];
                    residenteACrear.Tipo = (String)collection["Tipo"];

                    RegistrarService.RegistrarResidente(residenteACrear);

                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, "Error al crear residente: " + e.Message);

                return View();
            }
        }
        
        // GET: /Residente/Edit/5
        public ActionResult Edit(String DNI)
        {
            Residente modelo = RegistrarService.ObtenerResidente(DNI);
            return View(modelo);
        }

        // POST: /Residente/Edit/5
        [HttpPost]
        public ActionResult Edit(String DNI, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Residente residenteAModificar = RegistrarService.ObtenerResidente(DNI);

                residenteAModificar.Nombres = (String)collection["Nombres"];
                residenteAModificar.ApellidoPaterno = (String)collection["ApellidoPaterno"];
                residenteAModificar.ApellidoMaterno = (String)collection["ApellidoMaterno"];

                RegistrarService.ModificarResidente(residenteAModificar);
                
                return RedirectToAction("Index");
            }
            catch   
            {
                return View();
            }
        }

        // GET: /Residente/Delete/5
        public ActionResult Delete(String DNI)
        {
            Residente modelo = RegistrarService.ObtenerResidente(DNI);
            return View(modelo);
        }

        // POST: /Residente/Delete/5
        [HttpPost]
        public ActionResult Delete(String DNI, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Residente residenteAEliminar = RegistrarService.ObtenerResidente(DNI);
                RegistrarService.EliminarResidente(residenteAEliminar);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}