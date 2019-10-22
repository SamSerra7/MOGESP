using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestionPersonalOIJ.Models;
using MOGESP.ServiceLayer.Servicio;
using MOGESP.Entities.Dominio;
using Microsoft.AspNetCore.Http;

namespace GestionPersonalOIJ.Controllers
{
    public class ProcesoSeleccionController : Controller
    {

        readonly PrimerIngresoServicio primerIngresoServicio = new PrimerIngresoServicio();
        readonly static List<PrimerIngreso> primerosIngresos = new List<PrimerIngreso>();

        public IActionResult PrimerosIngresos()
        {
            return View();
        }

        public IActionResult VerPrimerosIngresos()
        {
            IEnumerable<PrimerIngreso> primerosIngresos;
            primerosIngresos = primerIngresoServicio.getAllPrimerosIngresos();
            return View(primerosIngresos);
        }


        public IActionResult InsertarPrimerosIngresos()
        {
            ViewData["primerosIngresos"] = primerosIngresos;

            return View();
        }

        [HttpPost]
        public RedirectToActionResult AgregarPrimerIngreso(IFormCollection formCollection)
        {

            List<string> correos = new List<string>
            {
                formCollection["correos"]
            };
            List<int> tels = new List<int>
            {
                Convert.ToInt32(formCollection["telefonos"])
            };
            

            PrimerIngreso pi = new PrimerIngreso(
                                                    formCollection["cedula"],
                                                    formCollection["nombre"],
                                                    formCollection["primerApellido"],
                                                    formCollection["segundoapellido"],
                                                    Convert.ToChar(formCollection["sexo"]),
                                                    correos,
                                                    tels,
                                                    formCollection["direccion"],
                                                    formCollection["numeroconvocatoria"],
                                                    Convert.ToInt32(formCollection["numeroflujo"])
                                                 );
            pi.NumeroConvocatoria = "a113";
            pi.NumeroFlujo = 3;
            primerosIngresos.Add(pi);

            return RedirectToAction("InsertarPrimerosIngresos");
        }



        public ActionResult EliminarPrimerIngreso(string cedula)
        {

            for (int i = 0; i < primerosIngresos.Count; i++)
            {
                if (primerosIngresos.ElementAt(i).Cedula == cedula)
                {
                    primerosIngresos.RemoveAt(i);
                    return RedirectToAction("InsertarPrimerosIngresos");
                }
            }

            return RedirectToAction("InsertarPrimerosIngresos");
        }


        [HttpPost]
        public RedirectToActionResult InsertarTodosPrimerosIngresos()
        {

            foreach (var pi in primerosIngresos)
            {
                primerIngresoServicio.insertarPrimerIngreso(pi);
            }

            primerosIngresos.RemoveRange(0,primerosIngresos.Count);


            return RedirectToAction("InsertarPrimerosIngresos");
        }


    }
}