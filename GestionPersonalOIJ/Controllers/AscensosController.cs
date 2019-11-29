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
		readonly ConcursoServicio concursoServicio = new ConcursoServicio();
		readonly PuestoServicio puestoServicio = new PuestoServicio();
		private readonly int registrosPorPagina = 10;
		private readonly int registrosPorPaginaConcurso = 5;
		private IEnumerable<Funcionario> funcionarios;
		private IEnumerable<Concurso> concursos;
		private PaginadorGenerico<Funcionario> paginador;
		private PaginadorGenerico<Concurso> paginadorConcurso;
		private List<Funcionario> funcionariosLista;
		private List<Concurso> concursosLista;
		private PaginadorGenerico<Funcionario> paginadorFuncionarioTodos;
		private readonly int registrosPorPaginaFuncionario = 5;

		[HttpGet]
		public IActionResult AgregarConcurso(int pagina = 1, string buscar = "")
		{
			ViewData["puestos"] = puestoServicio.ListarPuestos();
			concursos = concursoServicio.ListarConcursos();
			int totalRegistros = 0;

			// FILTRO DE BÚSQUEDA
			// Filtramos el resultado por el 'texto de búqueda'
			if (!string.IsNullOrEmpty(buscar))
			{
				foreach (var item in buscar.Split(new char[] { ' ' },
						 StringSplitOptions.RemoveEmptyEntries))
				{
					concursos = concursos.Where(x => x.NombreConcurso.ToUpper().Contains(item) ||
													  x.Puesto.Nombre.ToUpper().Contains(item.ToUpper())
													  ).ToList();
				}
			}

			// Obtenemos la 'página de registros' de la tabla 
			concursosLista = concursos.OrderBy(x => x.NombreConcurso)
												 .Skip((pagina - 1) * registrosPorPaginaConcurso)
												 .Take(registrosPorPaginaConcurso)
												 .ToList();
			// Número total de registros de la tabla		
			totalRegistros = concursos.Count();


			// Número total de páginas de la tabla 
			var _TotalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPaginaConcurso);
			// Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
			paginadorConcurso = new PaginadorGenerico<Concurso>()
			{
				RegistrosPorPagina = registrosPorPaginaConcurso,
				TotalRegistros = totalRegistros,
				TotalPaginas = _TotalPaginas,
				PaginaActual = pagina,
				Resultado = concursosLista
			};
			//Enviamos a la Vista la 'Clase de paginación'
			ViewData["paginador"] = paginadorConcurso;
			return View();
			//return View();
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

		[HttpPost]
		public RedirectToActionResult AgregarConcurso(IFormCollection formCollection)
		{
			Concurso concurso = new Concurso();
			concurso.NombreConcurso = formCollection["nombreConcurso"];
			concurso.FechaConcurso = Convert.ToDateTime(formCollection["fechaConcurso"]);
			Puesto puesto = new Puesto();
			puesto.IdPuesto = Convert.ToInt32(formCollection["Puesto.Nombre"]);
			concurso.Puesto = puesto;

			concursoServicio.insertarConcurso(concurso);

			return RedirectToActionPermanent("AgregarConcurso");
		}



		//Controller Funcionario y Participaconen Puestos
		public IActionResult FuncionarioYParticipacionEnPuestos(String cedula = "")
		{
			Funcionario funcionario = funcioniarioServicio.obtenerFuncionarioPorCedula(cedula);
			ViewData["funcionario"] = funcionario;
			IEnumerable<Concurso> concursos = concursoServicio.ListarConcursosPorFuncionario(cedula);
			ViewData["concursos"] = concursos;
			return View();
		}


		IEnumerable<Funcionario> funcionariosTodosLista;
		static int IDConcurso = 0;
		//Controller Concurso y sus funcionarios
		public IActionResult ConcursosySusFuncionarios(int idConcurso = 0, int pagina = 1)
		{
			IDConcurso = idConcurso;
			ViewData["concurso"] = concursoServicio.ObtieneConcursoPorId(IDConcurso);
			List <Funcionario> funcionariosParticipantes = funcioniarioServicio.obtenerFuncionarioPorIdConcursoParticipante(IDConcurso).ToList();
			ViewData["funcionariosElegidos"] = funcionariosParticipantes;

			int totalRegistros = 0;
			IEnumerable<Funcionario> funcionariosTodos = funcioniarioServicio.ListarFuncionarios().ToList();


			if (funcionariosParticipantes.Count() > 0)
			{
				foreach (var funcionarioParticipante in funcionariosParticipantes)
				{
					funcionariosTodos = funcionariosTodos.Where(x => !x.Cedula.Contains(funcionarioParticipante.Cedula))
																	.ToList();
				}
			}


			funcionariosTodosLista = funcionariosTodos
													 .OrderBy(x => x.Nombre)
													 .Skip((pagina - 1) * registrosPorPaginaFuncionario)
													 .Take(registrosPorPaginaFuncionario)
													 .ToList();
			
		// Número total de registros de la tabla		
		totalRegistros = funcionariosTodos.Count();


			// Número total de páginas de la tabla 
			var _TotalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPaginaFuncionario);
			// Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
			paginadorFuncionarioTodos = new PaginadorGenerico<Funcionario>()
			{
				RegistrosPorPagina = registrosPorPaginaConcurso,
				TotalRegistros = totalRegistros,
				TotalPaginas = _TotalPaginas,
				PaginaActual = pagina,
				Resultado = funcionariosTodosLista
			};
			//Enviamos a la Vista la 'Clase de paginación'
			ViewData["funcionariosTodos"] = paginadorFuncionarioTodos;
			return View();
		}

		public ActionResult InsertarRelacionConcursoFuncionario(String cedula = "")
		{
			//insertar Relacion
			concursoServicio.InsertarFuncionarioAConcursar(cedula, IDConcurso);
			return RedirectToAction("ConcursosySusFuncionarios", routeValues: new { idConcurso = IDConcurso });
		}


		}
}