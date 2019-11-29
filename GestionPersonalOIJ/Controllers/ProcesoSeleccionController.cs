using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestionPersonalOIJ.Models;
using MOGESP.ServiceLayer.Servicio;
using MOGESP.Entities.Dominio;
using Microsoft.AspNetCore.Http;
using MOGESP.Entities.Utilidades;

namespace GestionPersonalOIJ.Controllers
{
    public class ProcesoSeleccionController : Controller
    {

        readonly PrimerIngresoServicio primerIngresoServicio = new PrimerIngresoServicio();
        readonly CuadroGeneralServicio cuadroGeneralServicio = new CuadroGeneralServicio();
        readonly PIDepartamentosServicio pIDepartamentosServicio = new PIDepartamentosServicio();
        readonly static List<PrimerIngreso> primerosIngresos = new List<PrimerIngreso>();
        private readonly int registrosPorPagina = 10;
        private List<PrimerIngreso> primerosIngresosLista;
        private PaginadorGenerico<PrimerIngreso> paginador;

        private static bool clear = false;

        readonly static List<string> todosCorreos = new List<string>();
        readonly static List<string> todosTels = new List<string>();
        private static int numeroFlujo = 1;
        private static string numeroConvocatoria = "OIJ-";
        private static List<int> flujosPorConvocatoria = new List<int>();


        public IActionResult CuadroGeneral()
        {
            IEnumerable<String> numerosConvocatoria;
            numerosConvocatoria = cuadroGeneralServicio.traerNumerosConvocatoria();
            return View(numerosConvocatoria);
        }

        /// <summary>
        /// Jesús Torres
        /// 26/soct/2019
        /// Efecto: Cotroller de primeros ingresos, ajusta la paginación que siempre se vean solo 10 reistros
        /// Requiere: 
        /// Modifica: 
        /// Devuelve: -
        /// </summary>
        public IActionResult VerPrimerosIngresos(int pagina = 1, String buscar = "")
        {
            IEnumerable<PrimerIngreso> primerosIngresos;
            primerosIngresos = primerIngresoServicio.getAllPrimerosIngresos();
            int totalRegistros = 0;

            // FILTRO DE BÚSQUEDA
            // Filtramos el resultado por el 'texto de búqueda'
            if (!string.IsNullOrEmpty(buscar))
            {
                foreach (var item in buscar.Split(new char[] { ' ' },
                         StringSplitOptions.RemoveEmptyEntries))
                {
                    primerosIngresos = primerosIngresos.Where(x => x.Cedula.ToUpper().Contains(item) ||
                                                      x.Nombre.ToUpper().Contains(item.ToUpper()) ||
                                                      x.PrimerApellido.ToUpper().Contains(item.ToUpper()) ||
                                                      x.SegundoApellido.ToUpper().Contains(item.ToUpper()) ||
                                                      x.NumeroConvocatoria.ToUpper().Contains(item.ToUpper()))
                                                      .ToList();
                }
            }

            // Obtenemos la 'página de registros' de la tabla 
            primerosIngresosLista = primerosIngresos.OrderBy(x => x.Nombre)
                                                 .Skip((pagina - 1) * registrosPorPagina)
                                                 .Take(registrosPorPagina)
                                                 .ToList();
            // Número total de registros de la tabla		
            totalRegistros = primerosIngresos.Count();


            // Número total de páginas de la tabla 
            var _TotalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina);
            // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            paginador = new PaginadorGenerico<PrimerIngreso>()
            {
                RegistrosPorPagina = registrosPorPagina,
                TotalRegistros = totalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                Resultado = primerosIngresosLista
            };
            // Enviamos a la Vista la 'Clase de paginación'
            return View(paginador);

        }

        public IActionResult InsertarPrimerosIngresos()
        {

            if (clear)
            {
                eliminaBuffer();
                clear = false;
            }

            ViewData["primerosIngresos"] = primerosIngresos;

            ViewData["correos"] = todosCorreos;
            ViewData["tels"] = todosTels;
            ViewData["numeroConvocatoria"] = numeroConvocatoria;
            ViewData["numFlujo"] = numeroFlujo;


            ViewBag.NConvocatoria = cuadroGeneralServicio.traerNumerosConvocatoria();
            ViewBag.NFlujo = flujosPorConvocatoria;

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
        public RedirectToActionResult AgregarCorreo(IFormCollection formCollection)
        {

            todosCorreos.Add(formCollection["correo"]);

            numeroConvocatoria = formCollection["numeroConvocatoria1"].ToString();
            numeroFlujo = Convert.ToInt32(formCollection["numeroFlujo"]);

            return RedirectToActionPermanent("InsertarPrimerosIngresos");
        }


        [HttpPost]
        public RedirectToActionResult AgregarTel(IFormCollection formCollection)
        {

            todosTels.Add(formCollection["tel"]);

            return RedirectToActionPermanent("InsertarPrimerosIngresos");
        }


        [HttpPost]
        public RedirectToActionResult AgregarPrimerIngreso(IFormCollection formCollection)
        {

            ViewData["correos"] = todosCorreos;
            ViewData["tels"] = todosTels;

            List<string> correos = new List<string>();
            List<string> tels = new List<string>();


            foreach (var c in todosCorreos)
            {
                correos.Add(c);
            }

            foreach (var t in todosTels)
            {
                tels.Add(t);
            }

            PrimerIngreso pi = new PrimerIngreso(
                                                    formCollection["cedula"],
                                                    formCollection["nombre"],
                                                    formCollection["primerApellido"],
                                                    formCollection["segundoapellido"],
                                                    Convert.ToChar(formCollection["sexo"]),
                                                    correos,
                                                    tels,
                                                    formCollection["direccion"],
                                                    numeroConvocatoria,
                                                    numeroFlujo
                                                 );

            primerosIngresos.Add(pi);

            clear = true;

            return RedirectToAction("InsertarPrimerosIngresos");
        }

        private void eliminaBuffer()
        {
            todosCorreos.Clear();
            todosTels.Clear();

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

        public ActionResult verPrimerIngresoEspecifico(string cedulaPrimerIngreso)
        {
            PrimerIngresoDepartamentos primerIngresoDepartamentos = new PrimerIngresoDepartamentos();
            primerIngresoDepartamentos = pIDepartamentosServicio.getPrimerIngresoDepartamentos(cedulaPrimerIngreso);
            return View(primerIngresoDepartamentos);

        }

        public ActionResult editarPrimerIngreso(string cedula)
        {
            PrimerIngreso primerIngreso = new PrimerIngreso();
            primerIngreso = primerIngresoServicio.getPrimerIngreso(cedula);
            return View(primerIngreso);
        }

        [HttpPost]
        public RedirectToActionResult actualizarPrimerIngreso(IFormCollection formCollection)
        {
            PrimerIngreso primerIngreso = new PrimerIngreso();

            /*@TC_NumeroConvocatoria,
                                                            @TN_NumeroFlujo,
                                                            @TC_NumeroCedula,
                                                            @TC_Nombre,
                                                            @TC_PrimerApellido,
                                                            @TC_SegundoApellido,
                                                            @TC_Direccion,
                                                            @nombreCondicion"*/
                                                            
            primerIngreso.NumeroFlujo = Convert.ToInt32(formCollection["numFlujo"]);
            primerIngreso.Cedula = formCollection["cedulaInfo"].ToString();
            primerIngreso.Nombre = formCollection["nombreInfo"].ToString();
            primerIngreso.PrimerApellido = formCollection["primerApellido"].ToString();
            primerIngreso.SegundoApellido = formCollection["segundoApellido"].ToString();
            primerIngreso.Direccion = formCollection["direccion"].ToString();
            primerIngreso.IdCondicion = formCollection["condicion"].ToString();

            primerIngresoServicio.updatePrimerIngreso(primerIngreso);

            return RedirectToAction("verPrimerosIngresos", new { cedula = primerIngreso.Cedula });

        }

        [HttpPost]
        public RedirectToActionResult actualizarPruebasGH(IFormCollection formCollection)
        {
            DepartamentoPruebasGH departamentoPruebasGH = new DepartamentoPruebasGH();

            

            string cedula = (formCollection["cedula"]).ToString();
            departamentoPruebasGH.FechaIngresoAdministracion = Convert.ToDateTime(formCollection["fechaIngresoAdmi"]);
            departamentoPruebasGH.CantidadDiasAdministracion = Convert.ToInt32(formCollection["cantidadDiasAdmi"]);
            departamentoPruebasGH.NumConcurso = formCollection["numConcurso"].ToString();
            departamentoPruebasGH.Ubicacion = formCollection["ubicacion"].ToString();
            departamentoPruebasGH.FechaIngreso = Convert.ToDateTime(formCollection["fechaIngreso"]);
            departamentoPruebasGH.OficioIngreso = formCollection["oficioIngreso"].ToString();
            departamentoPruebasGH.DiasAlaFecha = Convert.ToInt32(formCollection["diasAFecha"]);
            departamentoPruebasGH.FechaTrasladoPsicologosAdmin = Convert.ToDateTime(formCollection["fechaTrasladoPsicologia"]);
            departamentoPruebasGH.Oficio = formCollection["oficio"].ToString();
            departamentoPruebasGH.FechaLimiteSegunPlazo = Convert.ToDateTime(formCollection["fechaLimite"]);
            departamentoPruebasGH.CantidadDiasPsicologiaAdmin = Convert.ToInt32(formCollection["diasPsicologiaAdmi"]);
            departamentoPruebasGH.DiasALaFechaDeFechaLimiteSegunPlazo = Convert.ToInt32(formCollection["diasAFechaSegundoPlazo"]);
            departamentoPruebasGH.FechaDevolucionGHDeAdmin = Convert.ToDateTime(formCollection["fechaDevulucionAdmi"]);
            departamentoPruebasGH.DiasTramiteGHDespuesDevuelto = Convert.ToInt32(formCollection["diasTramiteGHDespuesDevuelto"]);
            departamentoPruebasGH.FechaSalida = Convert.ToDateTime(formCollection["fechaSalida"]);
            departamentoPruebasGH.CantidadDiasTotalesTramite = Convert.ToInt32(formCollection["diasTotalesTramite"]);
            departamentoPruebasGH.OficioRespuesta = formCollection["oficioRespuesta"].ToString();
            departamentoPruebasGH.EstadoResultHojaEnvioGH = formCollection["selectEstado"].ToString();

            pIDepartamentosServicio.actualizarPruebasGH(departamentoPruebasGH, cedula);

            return RedirectToAction("verPrimerIngresoEspecifico", new { cedulaPrimerIngreso = cedula });

        }


        [HttpPost]
        public RedirectToActionResult actualizarAntecedentes (IFormCollection formCollection)
        {
            DepartamentoAntecedentes departamentoAntecedentes = new DepartamentoAntecedentes();



            string cedula = (formCollection["cedula"]).ToString();
            departamentoAntecedentes.FechaIngresoAdministracion = Convert.ToDateTime(formCollection["fechaIngresoAdmi"]);
            departamentoAntecedentes.CantidadDiasAdministracion = Convert.ToInt32(formCollection["cantidadDiasAdmi"]);
            departamentoAntecedentes.FechaIngreso = Convert.ToDateTime(formCollection["fechaIngreso"]);
            departamentoAntecedentes.OficioIngreso = formCollection["oficioIngreso"].ToString();
            departamentoAntecedentes.FechaResultado = Convert.ToDateTime(formCollection["fechaResultado"]);
            departamentoAntecedentes.ZonaTrabajo = Convert.ToInt32(formCollection["zonaTrabajo"]);
            departamentoAntecedentes.DiasAlaFecha = Convert.ToInt32(formCollection["diasAFecha"]);            
            departamentoAntecedentes.FechaSalida = Convert.ToDateTime(formCollection["fechaSalida"]);
            departamentoAntecedentes.CantidadDiasTotalesTramite = Convert.ToInt32(formCollection["diasTotalesTramite"]);
            departamentoAntecedentes.OficioRespuesta = formCollection["oficioRespuesta"].ToString();
            departamentoAntecedentes.EstadoResultHojaEnvioGH = formCollection["selectEstado"].ToString();

            pIDepartamentosServicio.actualizarAntecedentes(departamentoAntecedentes, cedula);

            return RedirectToAction("verPrimerIngresoEspecifico", new { cedulaPrimerIngreso = cedula });

        }


        [HttpPost]
        public RedirectToActionResult actualizarVialidad(IFormCollection formCollection)
        {
            DepartamentoVialidad departamentoVialidad = new DepartamentoVialidad();



            string cedula = (formCollection["cedula"]).ToString();
            departamentoVialidad.FechaIngresoAdministracion = Convert.ToDateTime(formCollection["fechaIngresoAdmi"]);
            departamentoVialidad.CantidadDiasAdministracion = Convert.ToInt32(formCollection["cantidadDiasAdmi"]);
            departamentoVialidad.FechaIngreso = Convert.ToDateTime(formCollection["fechaIngresoTrans"]);
            departamentoVialidad.OficioIngreso = formCollection["oficioIngreso"].ToString();
            departamentoVialidad.FechaCita = Convert.ToDateTime(formCollection["fechaCita"]);
            departamentoVialidad.DiasParaCita = Convert.ToInt32(formCollection["diasCita"]);
            departamentoVialidad.FechaSalida = Convert.ToDateTime(formCollection["fechaSalida"]);
            departamentoVialidad.CantidadDiasTotalesTramite = Convert.ToInt32(formCollection["diasTotalesTramite"]);
            departamentoVialidad.OficioRespuesta = formCollection["oficioRespuesta"].ToString();
            departamentoVialidad.EstadoResultHojaEnvioGH = formCollection["selectEstado"].ToString();

            pIDepartamentosServicio.actualizarVialidad(departamentoVialidad, cedula);

            return RedirectToAction("verPrimerIngresoEspecifico", new { cedulaPrimerIngreso = cedula });

        }


        [HttpPost]
        public RedirectToActionResult actualizarPruebasMedicas(IFormCollection formCollection)
        {
            DepartamentoPruebasMedicas departamentoPruebasMedicas = new DepartamentoPruebasMedicas();



            string cedula = (formCollection["cedula"]).ToString();
            departamentoPruebasMedicas.FechaIngresoAdministracion = Convert.ToDateTime(formCollection["fechaIngresoAdmi"]);
            departamentoPruebasMedicas.CantidadDiasAdministracion = Convert.ToInt32(formCollection["cantidadDiasAdmi"]);
            departamentoPruebasMedicas.FechaIngreso = Convert.ToDateTime(formCollection["fechaIngreso"]);
            departamentoPruebasMedicas.FechaEnvioAPMdeGH = Convert.ToDateTime(formCollection["fechaEnvioPM"]);
            departamentoPruebasMedicas.OficioIngreso = formCollection["oficioIngreso"].ToString();
            departamentoPruebasMedicas.FechaResultadoOCitaPM = Convert.ToDateTime(formCollection["fechaCitaPM"]);
            departamentoPruebasMedicas.DiasAlaFecha = Convert.ToInt32(formCollection["diasAFecha"]);
            departamentoPruebasMedicas.FechaSalida = Convert.ToDateTime(formCollection["fechaSalida"]);
            departamentoPruebasMedicas.CantidadDiasTotalesTramite = Convert.ToInt32(formCollection["diasTotalesTramite"]);
            departamentoPruebasMedicas.OficioRespuesta = formCollection["oficioRespuesta"].ToString();

            pIDepartamentosServicio.actualizarPruebasMedicas(departamentoPruebasMedicas, cedula);

            return RedirectToAction("verPrimerIngresoEspecifico", new { cedulaPrimerIngreso = cedula });

        }


        [HttpPost]
        public RedirectToActionResult actualizarToxicologia(IFormCollection formCollection)
        {
            DepartamentoToxicologia departamentoToxicologia = new DepartamentoToxicologia();



            string cedula = (formCollection["cedula"]).ToString();
            departamentoToxicologia.FechaIngresoAdministracion = Convert.ToDateTime(formCollection["fechaIngresoAdmi"]);
            departamentoToxicologia.CantidadDiasAdministracion = Convert.ToInt32(formCollection["cantidadDiasAdmi"]);
            departamentoToxicologia.FechaIngreso = Convert.ToDateTime(formCollection["fechaIngreso"]);
            departamentoToxicologia.OficioIngreso = formCollection["oficioIngreso"].ToString();
            departamentoToxicologia.FechaCita = Convert.ToDateTime(formCollection["fechaCita"]);
            departamentoToxicologia.DiasParaCita = Convert.ToInt32(formCollection["diasCita"]);
            departamentoToxicologia.DiasAlaFecha = Convert.ToInt32(formCollection["diasAFecha"]);
            departamentoToxicologia.FechaSalida = Convert.ToDateTime(formCollection["fechaSalida"]);
            departamentoToxicologia.CantidadDiasTotalesTramite = Convert.ToInt32(formCollection["diasTotalesTramite"]);
            departamentoToxicologia.OficioRespuesta = formCollection["oficioRespuesta"].ToString();
            departamentoToxicologia.FechaEstado = Convert.ToDateTime(formCollection["fechaEstado"]);
            departamentoToxicologia.FechaEstadoCantDias = Convert.ToInt32(formCollection["fechaEstadoCantDias"]);

            pIDepartamentosServicio.actualizarToxicologia(departamentoToxicologia, cedula);

            return RedirectToAction("verPrimerIngresoEspecifico", new { cedulaPrimerIngreso = cedula });

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