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
            ViewData["primerosIngresos"] = primerosIngresos;

            return View();
        }

        [HttpPost]
        public RedirectToActionResult AgregarPrimerIngreso(IFormCollection formCollection)
        {

            List<string> todosCorreos = new List<string>();
            List<string> todosTels = new List<string>();



            foreach (var item in formCollection["correos"])
            {
                todosCorreos.Add(item);
            }

            foreach (var item in formCollection["telefonos"])
            {
                todosTels.Add(item);
            }

            PrimerIngreso pi = new PrimerIngreso(
                                                    formCollection["cedula"],
                                                    formCollection["nombre"],
                                                    formCollection["primerApellido"],
                                                    formCollection["segundoapellido"],
                                                    Convert.ToChar(formCollection["sexo"]),
                                                    todosCorreos,
                                                    todosTels,
                                                    formCollection["direccion"],
                                                    formCollection["numeroconvocatoria"],
                                                    Convert.ToInt32(formCollection["numeroflujo"])
                                                 );
            
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