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
        readonly List<PrimerIngreso> primerosIngresos = new List<PrimerIngreso>();

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
        public ActionResult AgregarPrimerIngreso(IFormCollection formCollection)
        {

            List<string> correos = new List<string> { "dasdw2@gmail.com"};
            List<int> tels = new List<int> { 84695712,84692531};


            PrimerIngreso pi = new PrimerIngreso(   
                                                    formCollection["cedula"],
                                                    formCollection["nombre"],
                                                    formCollection["primerApellido"],
                                                    formCollection["segundoapellido"],
                                                    Convert.ToChar(formCollection["sexo"]),
                                                    correos,
                                                    tels,
                                                    formCollection["direccion"],
                                                    formCollection["numeroConvocatoria"],
                                                    Convert.ToInt32(formCollection["numeroFlujo"]) 
                                                 );
            primerosIngresos.Add(pi);

            return View("InsertarPrimerosIngresos");
        }


    }
}