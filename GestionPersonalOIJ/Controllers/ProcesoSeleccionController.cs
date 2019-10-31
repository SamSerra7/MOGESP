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
        readonly static List<PrimerIngreso> primerosIngresos = new List<PrimerIngreso>();
		private readonly int registrosPorPagina = 10;
		private List<PrimerIngreso> primerosIngresosLista;
		private PaginadorGenerico<PrimerIngreso> paginador;

        private static bool clear = false ;

        readonly static List<string> todosCorreos = new List<string>();
        readonly static List<string> todosTels = new List<string>();


        private static string[] correos = new string[5];
        private static string[] tels = new string[5];


        public IActionResult CuadroGeneral()
		{
			return View();
		}


		/// <summary>
		/// Jesús Torres
		/// 26/soct/2019
		/// Efecto: Cotroller de primeros ingresos, ajusta la paginación que siempre se vean solo 10 reistros
		/// Requiere: 
		/// Modifica: 
		/// Devuelve: -
		/// </summary>
		public IActionResult VerPrimerosIngresos(int pagina = 1, String  buscar = "")
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
					primerosIngresos = primerosIngresos.Where(x => x.Cedula.Contains(item) ||
													  x.Nombre.Contains(item) ||
													  x.PrimerApellido.Contains(item) ||
													  x.SegundoApellido.Contains(item))
													  .ToList();
					}
				}
			
			// Obtenemos la 'página de registros' de la tabla 
			primerosIngresosLista = primerosIngresos.OrderBy(x => x.Cedula)
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



            return View();
        }
        
        [HttpPost]
        public ActionResult AgregarCorreo(IFormCollection formCollection)
        {

            todosCorreos.Add(formCollection["correo"]);

            return View("InsertarPrimerosIngresos");
        }


        [HttpPost]
        public ActionResult AgregarTel(IFormCollection formCollection)
        {

            todosTels.Add(formCollection["tel"]);

            return View("InsertarPrimerosIngresos");
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
                                                    formCollection["numeroConvocatoria"],
                                                    Convert.ToInt32(formCollection["numeroFlujo"])
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