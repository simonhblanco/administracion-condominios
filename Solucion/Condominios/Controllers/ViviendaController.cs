﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Condominios.Negocio;
using Condominios.Dominio;
using Condominios.SRVivienda;

namespace Condominios.Controllers
{
    public class ViviendaController : Controller
    {
        
        //Dependencias
        public RegistrarService RegistrarService { get; set; }

        // GET: /Vivienda/
        public ActionResult Index()
        {
            // Llamamos al negocio para resolver la funcionalidad y obtenemos el "modelo"
            //ICollection<Vivienda> modelo = RegistrarService.ListarTodasLasViviendas();
            SRVivienda.ViviendasClient res = new SRVivienda.ViviendasClient();
            ICollection<DVivienda> modelo = res.ListarTodosLasViviendas();

            // Elegimos la vista a generar y le entregamos el modelo
            return View(modelo); // La vista se llama Index.aspx
        }

        // GET: /Vivienda/Details/5
        public ActionResult Details(int NumVivienda)
        {
            //Vivienda modelo = RegistrarService.ObtenerVivienda(NumVivienda);
            SRVivienda.ViviendasClient res = new SRVivienda.ViviendasClient();
            DVivienda modelo = res.ObtenerVivienda(NumVivienda);

            return View(modelo); //La vista se llama Details.aspx
        }

        // GET: /Vivienda/Create
        public ActionResult Create()
        {
            return View();
        } 

        // POST: /Vivienda/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    DVivienda viviendaACrear = new DVivienda();
                    DResidente residente = new DResidente();

                    residente.DNI = (String)collection["Residente"];

                    viviendaACrear.NumVivienda = int.Parse(collection["NumVivienda"]);
                    viviendaACrear.Ubicacion = (String)collection["Ubicacion"];
                    viviendaACrear.Numero = int.Parse(collection["Numero"]);
                    viviendaACrear.Metraje = int.Parse(collection["Metraje"]);
                    viviendaACrear.Tipo = (String)collection["Tipo"];
                    viviendaACrear.Residente = residente;

                    //RegistrarService.RegistrarVivienda(viviendaACrear);
                    SRVivienda.ViviendasClient res = new SRVivienda.ViviendasClient();
                    res.CrearVivienda(viviendaACrear);

                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, "Error al crear vivienda: " + e.Message);

                return View();
            }
        }
        
        // GET: /Vivienda/Edit/5
        public ActionResult Edit(int NumVivienda)
        {
            //Vivienda modelo = RegistrarService.ObtenerVivienda(NumVivienda);
            SRVivienda.ViviendasClient res = new SRVivienda.ViviendasClient();
            DVivienda modelo = res.ObtenerVivienda(NumVivienda);

            return View(modelo); //La vista se llama Details.aspx
        }

        // POST: /Vivienda/Edit/5
        [HttpPost]
        public ActionResult Edit(int NumVivienda, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                //Vivienda viviendaAModificar = RegistrarService.ObtenerVivienda(NumVivienda);
                SRVivienda.ViviendasClient res = new SRVivienda.ViviendasClient();
                DVivienda viviendaAModificar = res.ObtenerVivienda(NumVivienda);
                DResidente residente = new DResidente();

                residente.DNI = (String)collection["Residente.DNI"];

                viviendaAModificar.Ubicacion = (String)collection["Ubicacion"];
                viviendaAModificar.Numero = int.Parse(collection["Numero"]);
                viviendaAModificar.Metraje = int.Parse(collection["Numero"]);
                viviendaAModificar.Tipo = (String)collection["Tipo"];
                viviendaAModificar.Residente = residente;

                //RegistrarService.ModificarVivienda(viviendaAModificar);
                res.ModificarVivienda(viviendaAModificar);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Vivienda/Delete/5
        public ActionResult Delete(int NumVivienda)
        {
            //Vivienda modelo = RegistrarService.ObtenerVivienda(NumVivienda);
            SRVivienda.ViviendasClient res = new SRVivienda.ViviendasClient();
            DVivienda modelo = res.ObtenerVivienda(NumVivienda);

            return View(modelo);
        }

        // POST: /Vivienda/Delete/5
        [HttpPost]
        public ActionResult Delete(int NumVivienda, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //Vivienda viviendaAEliminar = RegistrarService.ObtenerVivienda(NumVivienda);
                //RegistrarService.EliminarVivienda(viviendaAEliminar);
                SRVivienda.ViviendasClient res = new SRVivienda.ViviendasClient();
                DVivienda viviendaAEliminar = res.ObtenerVivienda(NumVivienda);
                res.EliminarVivienda(viviendaAEliminar);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
