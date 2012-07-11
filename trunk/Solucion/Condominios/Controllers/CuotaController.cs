using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Condominios.Negocio;
using Condominios.Dominio;

namespace Condominios.Controllers
{
    public class CuotaController : Controller
    {
        //Dependencias
        public TransaccionService TransaccionService { get; set; }

        // GET: /Couta/
        public ActionResult Index()
        {
            // Llamamos al negocio para resolver la funcionalidad y obtenemos el "modelo"
            ICollection<Cuota> modelo = TransaccionService.ListarTodasLasCuotas();

            // Elegimos la vista a generar y le entregamos el modelo
            return View(modelo); // La vista se llama Index.aspx
        }

        // GET: /Couta/Details/5
        public ActionResult Details(int IdCuota)
        {
            Cuota modelo = TransaccionService.MostrarCuota(IdCuota);

            return View(modelo); //La vista se llama Details.aspx
        }

        // GET: /Couta/Create
        public ActionResult Create()
        {
            return View();
        } 

        // POST: /Couta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Cuota cuotaACrear = new Cuota();
                    Vivienda vivienda = new Vivienda();

                    vivienda.NumVivienda = int.Parse(collection["Vivienda"]);

                    //cuotaACrear.IdCuota = int.Parse(collection["IdCuota"]);
                    cuotaACrear.Vivienda = vivienda;
                    cuotaACrear.Mes = (String)collection["Mes"];
                    cuotaACrear.Anio = (String)collection["Anio"];
                    cuotaACrear.Importe = double.Parse(collection["Importe"]);
                    cuotaACrear.FechaVencimiento = DateTime.Parse(collection["FechaVencimiento"]);
                    cuotaACrear.Estado = (String)collection["Estado"];

                    TransaccionService.ColocarCuota(cuotaACrear);

                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, "Error al colocar cuota: " + e.Message);

                return View();
            }
        }
        
        // GET: /Couta/Edit/5
        public ActionResult Edit(int IdCuota)
        {
            Cuota modelo = TransaccionService.MostrarCuota(IdCuota);

            return View(modelo); //La vista se llama Details.aspx
        }

        // POST: /Couta/Edit/5
        [HttpPost]
        public ActionResult Edit(int IdCuota, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Cuota cuotaAModificar = TransaccionService.MostrarCuota(IdCuota);

                cuotaAModificar.Anio = (String)collection["Anio"];
                cuotaAModificar.Mes = (String)collection["Mes"];
                cuotaAModificar.Importe = int.Parse(collection["Importe"]);
                cuotaAModificar.FechaVencimiento = DateTime.Parse(collection["FechaVencimiento"]);

                TransaccionService.ModificarCuota(cuotaAModificar);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Couta/Delete/5
        public ActionResult Delete(int IdCuota)
        {
            Cuota modelo = TransaccionService.MostrarCuota(IdCuota);

            return View(modelo);
        }

        // POST: /Couta/Delete/5
        [HttpPost]
        public ActionResult Delete(int IdCuota, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Cuota cuotaAEliminar = TransaccionService.MostrarCuota(IdCuota);
                TransaccionService.EliminarCuota(cuotaAEliminar);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
