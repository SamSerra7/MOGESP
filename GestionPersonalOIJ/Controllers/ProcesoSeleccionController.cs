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

		public IActionResult CuadroGeneral()
		{
			return View();
		}

		//public IActionResult VerPrimerosIngresos()
		//{
		//    IEnumerable<PrimerIngreso> primerosIngresos;
		//    primerosIngresos = primerIngresoServicio.getAllPrimerosIngresos();
		//    return View(primerosIngresos);
		//}

		private readonly int _RegistrosPorPagina = 10;

		private List<PrimerIngreso> _Customers;
		private PaginadorGenerico<PrimerIngreso> _PaginadorCustomers;

		public IActionResult VerPrimerosIngresos(int pagina = 1)
		{
			IEnumerable<PrimerIngreso> primerosIngresos;
			primerosIngresos = primerIngresoServicio.getAllPrimerosIngresos();
			int _TotalRegistros = 0;
			
				
				// Número total de registros de la tabla Customers
				_TotalRegistros = primerosIngresos.Count();
				// Obtenemos la 'página de registros' de la tabla Customers
				_Customers = primerosIngresos.OrderBy(x => x.Cedula)
												 .Skip((pagina - 1) * _RegistrosPorPagina)
												 .Take(_RegistrosPorPagina)
												 .ToList();
				// Número total de páginas de la tabla Customers
				var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);
				// Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
				_PaginadorCustomers = new PaginadorGenerico<PrimerIngreso>()
				{
					RegistrosPorPagina = _RegistrosPorPagina,
					TotalRegistros = _TotalRegistros,
					TotalPaginas = _TotalPaginas,
					PaginaActual = pagina,
					Resultado = _Customers
				};
				// Enviamos a la Vista la 'Clase de paginación'
				return View(_PaginadorCustomers);
			
		}
	


		public IActionResult InsertarPrimerosIngresos()
        {
            ViewData["primerosIngresos"] = primerosIngresos;

            return View();
        }

        [HttpPost]
        public RedirectToActionResult AgregarPrimerIngreso(IFormCollection formCollection)
        {

            List<string> correos = new List<string>();
            List<String> tels = new List<String>();

            string[] selCorreos = formCollection["selCorreos"].ToArray();
            string[] selTels = formCollection["selTels"].ToArray();

            for (int i = 0; i < selCorreos.Length; i++)
            {
                correos.Add(selCorreos[i]);
            }
            for (int j = 0; j < selTels.Length; j++)
            {
                tels.Add(selTels[j]);
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