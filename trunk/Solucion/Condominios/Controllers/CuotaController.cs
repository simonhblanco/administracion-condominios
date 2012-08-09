using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Condominios.Negocio;
using Condominios.Dominio;
using Condominios.SRCuota;

namespace Condominios.Controllers
{
    public class CuotaController : Controller
    {
        //Dependencias
        public TransaccionService TransaccionService { get; set; }

        // GET: /Couta/
        public ActionResult Index()
        {
            //// Llamamos al negocio para resolver la funcionalidad y obtenemos el "modelo"
            //ICollection<Cuota> modelo = TransaccionService.ListarTodasLasCuotas();

            SRCuota.CuotaClient res = new SRCuota.CuotaClient();
            ICollection<DCuota> modelo = res.ListarCuotas();

            // Elegimos la vista a generar y le entregamos el modelo
            return View(modelo); // La vista se llama Index.aspx
        }

        // GET: /Couta/Details/5
        public ActionResult Details(int IdCuota)
        {
            //Cuota modelo = TransaccionService.MostrarCuota(IdCuota);

            SRCuota.CuotaClient res = new SRCuota.CuotaClient();
            DCuota modelo = res.ObtenerCuota(IdCuota);

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
                    DCuota cuotaACrear = new DCuota();
                    DVivienda vivienda = new DVivienda();

                    vivienda.NumVivienda = int.Parse(collection["Vivienda"]);

                    cuotaACrear.IdCuota = int.Parse(collection["IdCuota"]);
                    cuotaACrear.Vivienda = vivienda;
                    cuotaACrear.Mes = (String)collection["Mes"];
                    cuotaACrear.Anio = (String)collection["Anio"];
                    cuotaACrear.Importe = Decimal.Parse(collection["Importe"]);
                    cuotaACrear.FechaVencimiento = DateTime.Parse(collection["FechaVencimiento"]);
                    cuotaACrear.Estado = (String)collection["Estado"];

                    //TransaccionService.ColocarCuota(cuotaACrear);
                    SRCuota.CuotaClient res = new SRCuota.CuotaClient();
                    res.CrearCuota(cuotaACrear);

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
            //Cuota modelo = TransaccionService.MostrarCuota(IdCuota);

            SRCuota.CuotaClient res = new SRCuota.CuotaClient();
            DCuota modelo = res.ObtenerCuota(IdCuota);

            return View(modelo); //La vista se llama Details.aspx
        }

        // POST: /Couta/Edit/5
        [HttpPost]
        public ActionResult Edit(int IdCuota, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                //Cuota cuotaAModificar = TransaccionService.MostrarCuota(IdCuota);
                SRCuota.CuotaClient res = new SRCuota.CuotaClient();

                DCuota cuotaAModificar = res.ObtenerCuota(IdCuota);

                DVivienda vivienda = new DVivienda();

                vivienda.NumVivienda = int.Parse(collection["Vivienda.NumVivienda"]);

                cuotaAModificar.Mes = (String)collection["Mes"];
                cuotaAModificar.Anio = (String)collection["Anio"];
                cuotaAModificar.Importe = Decimal.Parse(collection["Importe"]);
                cuotaAModificar.FechaVencimiento = DateTime.Parse(collection["FechaVencimiento"]);
                cuotaAModificar.Estado = (String)collection["Estado"];

                //TransaccionService.ModificarCuota(cuotaAModificar);
                res.ModificarCuota(cuotaAModificar);

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
            //Cuota modelo = TransaccionService.MostrarCuota(IdCuota);

            SRCuota.CuotaClient res = new SRCuota.CuotaClient();
            DCuota modelo = res.ObtenerCuota(IdCuota);

            return View(modelo);
        }

        // POST: /Couta/Delete/5
        [HttpPost]
        public ActionResult Delete(int IdCuota, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //Cuota cuotaAEliminar = TransaccionService.MostrarCuota(IdCuota);
                //TransaccionService.EliminarCuota(cuotaAEliminar);

                SRCuota.CuotaClient res = new SRCuota.CuotaClient();
                DCuota cuotaAEliminar = res.ObtenerCuota(IdCuota);
                res.EliminarCuota(IdCuota);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
