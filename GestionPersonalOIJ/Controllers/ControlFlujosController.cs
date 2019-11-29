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
        private PrimerIngresoElegiblesServicio baseElegiblesServicio = new PrimerIngresoElegiblesServicio();


        private static List<int> flujosPorConvocatoria = new List<int>();



        private static int numeroFlujo = 1;
        private static string numeroConvocatoria = "OIJ-";



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


            ViewData["numeroConvocatoria"] = numeroConvocatoria;

            ViewBag.NConvocatoria = cuadroGeneralServicio.traerNumerosConvocatoria();

            ViewBag.NFlujo = flujosPorConvocatoria;
            

            return View();
        }


        [HttpPost]
        public RedirectToActionResult AgregarNumFlujo(IFormCollection formCollection)
        {


            numeroConvocatoria = formCollection["selNumConv"];

            flujosPorConvocatoria = cuadroGeneralServicio.traerNumerosDeFlujoPorConvocatoria(numeroConvocatoria);


            return RedirectToActionPermanent("CitasPorFlujoPI");
        }



        [HttpPost]
        public RedirectToActionResult ProgramarCitasPorFlujoPI(IFormCollection formCollection)
        {
            string fecha;
            DateTime dateInicio = Convert.ToDateTime(formCollection["fechaInicioCitas"]);
            DateTime dateFinal = Convert.ToDateTime(formCollection["fechaFinalCitas"]);

            IEnumerable<PrimerIngresoElegible> elegibles = baseElegiblesServicio.getAllPrimerosIngresosElegibles(3);//3 pues los puestos son positivos
            int cantElegibles = 0;


            while (dateInicio.Date != dateFinal.Date)
            {

                fecha = dateInicio.DayOfWeek.ToString();

                

                if (!fecha.ToUpper().Equals("SATURDAY") || !fecha.ToUpper().Equals("SUNDAY"))
                {
                    fecha = dateInicio.ToShortDateString();
                    dateInicio = Convert.ToDateTime(fecha);

                    if (elegibles.ElementAt(cantElegibles) != null)
                    {

                        for (int horasAtencion = 1; horasAtencion <= 3; horasAtencion++)
                        {

                            //7:30am
                            if (horasAtencion == 1){

                                dateInicio.AddHours(7).AddMinutes(30);

                                //ANA
                                if (elegibles.ElementAt(cantElegibles) != null)
                                {
                                    hojaCitasPiServicio.InsertarCitaPI(elegibles.ElementAt(cantElegibles).Cedula,"Ana",dateInicio,1,"Delio");
                                    cantElegibles++;
                                }
                                else{ break;}


                                //KAROL
                                if (elegibles.ElementAt(cantElegibles) != null)
                                {
                                    hojaCitasPiServicio.InsertarCitaPI(elegibles.ElementAt(cantElegibles).Cedula, "Karol", dateInicio, 1, "Delio");
                                    cantElegibles++;
                                }
                                else { break; }


                                //MINOR
                                if (elegibles.ElementAt(cantElegibles) != null)
                                {
                                    hojaCitasPiServicio.InsertarCitaPI(elegibles.ElementAt(cantElegibles).Cedula, "Ana", dateInicio, 1, "Delio");
                                    cantElegibles++;
                                }
                                else { break; }
                            }
                            

                            //10:30am
                            if (horasAtencion == 2)
                            {

                                dateInicio.AddHours(10).AddMinutes(30);

                                //ANA
                                if (elegibles.ElementAt(cantElegibles) != null)
                                {
                                    hojaCitasPiServicio.InsertarCitaPI(elegibles.ElementAt(cantElegibles).Cedula, "Ana", dateInicio, 1, "Delio");
                                    cantElegibles++;
                                }
                                else { break; }


                                //KAROL
                                if (elegibles.ElementAt(cantElegibles) != null)
                                {
                                    hojaCitasPiServicio.InsertarCitaPI(elegibles.ElementAt(cantElegibles).Cedula, "Karol", dateInicio, 1, "Delio");
                                    cantElegibles++;
                                }
                                else { break; }


                                //MINOR
                                if (elegibles.ElementAt(cantElegibles) != null)
                                {
                                    hojaCitasPiServicio.InsertarCitaPI(elegibles.ElementAt(cantElegibles).Cedula, "Ana", dateInicio, 1, "Delio");
                                    cantElegibles++;
                                }
                                else { break; }
                            }

                            
                            
                            //1:30pm
                            if (horasAtencion == 3){

                                dateInicio.AddHours(13).AddMinutes(30);

                                //ANA
                                if (elegibles.ElementAt(cantElegibles) != null)
                                {
                                    hojaCitasPiServicio.InsertarCitaPI(elegibles.ElementAt(cantElegibles).Cedula, "Ana", dateInicio, 1, "Delio");
                                    cantElegibles++;
                                }
                                else { break; }


                                //KAROL
                                if (elegibles.ElementAt(cantElegibles) != null)
                                {
                                    hojaCitasPiServicio.InsertarCitaPI(elegibles.ElementAt(cantElegibles).Cedula, "Karol", dateInicio, 1, "Delio");
                                    cantElegibles++;
                                }
                                else { break; }


                                //MINOR
                                if (elegibles.ElementAt(cantElegibles) != null)
                                {
                                    hojaCitasPiServicio.InsertarCitaPI(elegibles.ElementAt(cantElegibles).Cedula, "Ana", dateInicio, 1, "Delio");
                                    cantElegibles++;
                                }
                                else { break; }
                            }

                        }

                        
                    }

                    
                }

                //aumenta la fecha
                dateInicio.AddDays(1);
            } 




            return RedirectToAction("VerHojaCitas");
        }

    }
}