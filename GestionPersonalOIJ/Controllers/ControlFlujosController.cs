using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOGESP.ServiceLayer.Servicio;
using MOGESP.Entities.Dominio;
using MOGESP.Entities.Utilidades;

namespace MOGESP.UserInterface.Controllers
{
    public class ControlFlujosController : Controller
    {

        //variables
        private PrimerIngresoServicio primerIngresoServicio = new PrimerIngresoServicio();



        public ActionResult ModificarResultadosPsicologos()
        {
            

            return View(primerIngresoServicio.getAllPrimerosIngresos());
        }



        public ActionResult VerFlujoSeleccion()
        {
            




            return View();
        }
        
    }
}