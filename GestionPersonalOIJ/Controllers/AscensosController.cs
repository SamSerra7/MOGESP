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
    public class AscensosController : Controller
    {
        readonly FuncionarioServicio funcioniarioServicio = new FuncionarioServicio();
        private readonly int registrosPorPagina = 10;
        private IEnumerable<Funcionario> funcionarios;
        private PaginadorGenerico<Funcionario> paginador;
		private List<Funcionario> funcionariosLista;


		public IActionResult AgregarConcurso()
		{
			return View();
		}

		[HttpGet]
        public ActionResult VerFuncionarios(int pagina = 1, String buscar = "")
        {

			funcionarios = funcioniarioServicio.ListarFuncionarios();
			int totalRegistros = 0;

			// FILTRO DE BÚSQUEDA
			// Filtramos el resultado por el 'texto de búqueda'
			if (!string.IsNullOrEmpty(buscar))
			{
				foreach (var item in buscar.Split(new char[] { ' ' },
						 StringSplitOptions.RemoveEmptyEntries))
				{
					funcionarios = funcionarios.Where(x => x.Cedula.ToUpper().Contains(item) ||
													  x.Nombre.ToUpper().Contains(item.ToUpper()) ||
													  x.PrimerApellido.ToUpper().Contains(item.ToUpper()) ||
													  x.SegundoApellido.ToUpper().Contains(item.ToUpper())
													  ).ToList();
				}
			}

			// Obtenemos la 'página de registros' de la tabla 
			funcionariosLista = funcionarios.OrderBy(x => x.Nombre)
												 .Skip((pagina - 1) * registrosPorPagina)
												 .Take(registrosPorPagina)
												 .ToList();
			// Número total de registros de la tabla		
			totalRegistros = funcionarios.Count();


			// Número total de páginas de la tabla 
			var _TotalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina);
			// Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
			paginador = new PaginadorGenerico<Funcionario>()
			{
				RegistrosPorPagina = registrosPorPagina,
				TotalRegistros = totalRegistros,
				TotalPaginas = _TotalPaginas,
				PaginaActual = pagina,
				Resultado = funcionariosLista
			};
			//Enviamos a la Vista la 'Clase de paginación'
			return View(paginador);

		}

		//Controller Funcionario y Participaconen Puestos
		public IActionResult FuncionarioYParticipacionEnPuestos()
		{
			return View();
		}

	}
}