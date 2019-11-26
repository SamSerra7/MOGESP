using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOGESP.ServiceLayer.Servicio;
using MOGESP.Entities.Dominio;
using MOGESP.Entities.Utilidades;
using System.Data;
using System.Data.SqlClient;
using javax.jws;

namespace MOGESP.UserInterface.Controllers
{
    public class ControlFlujosController : Controller
    {

        //variables
        private PrimerIngresoServicio primerIngresoServicio = new PrimerIngresoServicio();
        private TestPersonalidadServicio testPersonalidadServicio = new TestPersonalidadServicio();
        private TestCompetenciasServicio testCompetenciasServicio = new TestCompetenciasServicio();
        private TestOtrosServicio testOtrosServicio = new TestOtrosServicio();
        private TestVisomotorServicio testVisomotorServicio = new TestVisomotorServicio();
        private HojaCitasPiServicio hojaCitasPiServicio = new HojaCitasPiServicio();
        private CuadroGeneralServicio cuadroGeneralServicio = new CuadroGeneralServicio();

        public ActionResult ModificarResultadosPsicologos()
        {

            ViewBag.TestPersonalidad = testPersonalidadServicio.consultarTestPersonalidad();
            ViewBag.TestCompetencias = testCompetenciasServicio.consultarTestCompetencias();
            ViewBag.TestOtros = testOtrosServicio.consultarTestOtros();

            return View(primerIngresoServicio.getAllPrimerosIngresos());
        }



        public ActionResult VerFlujoSeleccion()
        {

            return View();
        }
        
        public ActionResult VerHojaCitas()
        {
            DataSet ds = new DataSet();

            SqlDataAdapter sda = hojaCitasPiServicio.getHojaCitasPI();

            sda.Fill(ds);

            return View(ds);
        }


        public ActionResult GetVerHojaCitas()
        {
            DataSet ds = new DataSet();

            SqlDataAdapter sda = hojaCitasPiServicio.getHojaCitasPI();

            sda.Fill(ds);

            return Json(ds);
        }

        
        public ActionResult CitasPorFlujoPI()
        {
            ViewBag.NumeroConvocatoria = cuadroGeneralServicio.traerNumerosConvocatoria();
            ViewBag.NumFlujo = flujosPorConvocatoria;

            return View();
        }


        [HttpPost]
        public RedirectToActionResult AgregarNumFlujo(IFormCollection formCollection)
        {

            numeroConvocatoria = formCollection["numeroConvocatoria"].ToString();

            flujosPorConvocatoria = cuadroGeneralServicio.traerNumerosDeFlujoPorConvocatoria(numeroConvocatoria);


            return RedirectToActionPermanent("InsertarPrimerosIngresos");
        }




        [HttpPost]
        public RedirectToActionResult ProgramarCitasPorFlujoPI()
        {


            /*
             * 
             * TODO: Terminar el data
             * 
             */



            return RedirectToAction("VerHojaCitas");
        }

    }
}