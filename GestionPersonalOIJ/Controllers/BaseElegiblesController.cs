using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOGESP.Entities.Dominio;
using MOGESP.Entities.Utilidades;
using MOGESP.ServiceLayer.Servicio;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MOGESP.UserInterface.Controllers
{
    public class BaseElegiblesController : Controller
    {

		readonly PrimerIngresoElegiblesServicio primerIngresoElegiblesServicio = new PrimerIngresoElegiblesServicio();
		private List<PrimerIngresoElegible> primerosIngresosElegiblesLista;
		private readonly int registrosPorPagina = 10;
		private PaginadorGenerico<PrimerIngresoElegible> paginador;


		public IActionResult verBaseElegibles(int pagina = 1, String buscar = "")
        {
			int condicionPuestosPositivos = 3; //El numero 3 indica que consulte solo los puestos que son positivos
			IEnumerable<PrimerIngresoElegible> primerosIngresosElegibles;
			primerosIngresosElegibles = primerIngresoElegiblesServicio.getAllPrimerosIngresosElegibles(condicionPuestosPositivos);
			int totalRegistros = 0;

			// FILTRO DE BÚSQUEDA
			// Filtramos el resultado por el 'texto de búqueda'

			if (!string.IsNullOrEmpty(buscar))
			{
				foreach (var item in buscar.Split(new char[] { ' ' },
						 StringSplitOptions.RemoveEmptyEntries))
				{
					primerosIngresosElegibles = primerosIngresosElegibles.Where(x => x.Cedula.ToUpper().Contains(item) ||
													  x.Nombre.ToUpper().Contains(item.ToUpper()) ||
													  x.PrimerApellido.ToUpper().Contains(item.ToUpper()) ||
													  x.SegundoApellido.ToUpper().Contains(item.ToUpper()) ||
													  x.PuestosElegibles.Any(y => y.Nombre.ToUpper().Contains(item.ToUpper())
													  ))
													  .ToList();
				}
			}

			// Obtenemos la 'página de registros' de la tabla 
			primerosIngresosElegiblesLista = primerosIngresosElegibles.OrderBy(x => x.Cedula)
												 .Skip((pagina - 1) * registrosPorPagina)
												 .Take(registrosPorPagina)
												 .ToList();
			// Número total de registros de la tabla		
			totalRegistros = primerosIngresosElegibles.Count();


			// Número total de páginas de la tabla 
			var _TotalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina);
			// Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
			paginador = new PaginadorGenerico<PrimerIngresoElegible>()
			{
				RegistrosPorPagina = registrosPorPagina,
				TotalRegistros = totalRegistros,
				TotalPaginas = _TotalPaginas,
				PaginaActual = pagina,
				Resultado = primerosIngresosElegiblesLista
			};
			// Enviamos a la Vista la 'Clase de paginación'
			return View(paginador);
		}
    }
}
