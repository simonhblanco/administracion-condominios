using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Condominios.Negocio;
using Condominios.Dominio;

namespace Condominios.Controllers
{
    public class TransaccionPagoController : Controller
    {
        //
        // GET: /TransaccionPago/
        public TransaccionService transaccionService { get; set; }

        public ActionResult Index()
        {
            // Llamamos al negocio para resolver la funcionalidad y obtenemos el "modelo"
            String codVivienda = Request["numVivienda"];
            int numVivienda = 0;
            if (codVivienda != null)
            {
                try
                {
                    numVivienda = Convert.ToInt32(codVivienda);
                }
                catch (Exception e)
                {

                }
            }

            ICollection<Cuota> modelo = transaccionService.CuotasPendientes(numVivienda);

            // Elegimos la vista a generar y le entregamos el modelo
            return View(modelo); // La vista se llama Index.aspx
        }

        public ActionResult Mostrar()
        {
            return Index();
        }
        
        //
        // GET: /TransaccionPago/Edit/5
 
        public ActionResult Edit(int id)
        {
            Cuota modelo = transaccionService.MostrarCuota(id);

            return View(modelo);
        }

        //
        // POST: /TransaccionPago/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                String tipoPago = (String)collection["tipoPago"];
                Cuota cuotaPagada = transaccionService.PagarCuota(id, tipoPago);

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Morosos()
        {
            // Llamamos al negocio para resolver la funcionalidad y obtenemos el "modelo"
            ICollection<Cuota> modelo = transaccionService.ConsultarMorosos("P",DateTime.Now);

            // Elegimos la vista a generar y le entregamos el modelo
            return View(modelo); // La vista se llama Index.aspx
        }
    }
}
