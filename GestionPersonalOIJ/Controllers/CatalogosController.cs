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
    public class CatalogosController : Controller
    {

		public IActionResult CarteleraCatalogos()
		{
			return View();
		}

        readonly TestOtrosServicio testOtrosServicio = new TestOtrosServicio();
        //readonly static List<TestOtros> primerosIngresos = new List<TestOtros>();

        private readonly int cantidadRegistrosPorPagina = 10;

        private List<TestOtros> _Customers;
        private PaginadorGenerico<TestOtros> _PaginadorCustomers;

        public IActionResult VerTestOtros(int pagina = 1)
        {
            IEnumerable<TestOtros> testOtrosLista;
            testOtrosLista = testOtrosServicio.consultarTestOtros();
            int _TotalRegistros = 0;


            // Número total de registros de la tabla Customers
            _TotalRegistros = testOtrosLista.Count();
            // Obtenemos la 'página de registros' de la tabla Customers
            _Customers = testOtrosLista.OrderBy(x => x.Id)
                                             .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                                             .Take(cantidadRegistrosPorPagina)
                                             .ToList();
            // Número total de páginas de la tabla Customers
            var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / cantidadRegistrosPorPagina);
            // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            _PaginadorCustomers = new PaginadorGenerico<TestOtros>()
            {
                RegistrosPorPagina = cantidadRegistrosPorPagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                Resultado = _Customers
            };
            // Enviamos a la Vista la 'Clase de paginación'
            return View(_PaginadorCustomers);
        }


        [HttpPost]
        public RedirectToActionResult AgregarTestOtros(String nombreTestOtros="")
        {

            if (!string.IsNullOrEmpty(nombreTestOtros)) { 
                testOtrosServicio.insertarTestOtros(nombreTestOtros);
            }

            return RedirectToAction("VerTestOtros");

        }




    }
}