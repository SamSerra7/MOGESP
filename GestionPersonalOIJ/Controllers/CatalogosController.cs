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

		//public IActionResult VerPrimerosIngresos()
		//{
		//    IEnumerable<PrimerIngreso> primerosIngresos;
		//    primerosIngresos = primerIngresoServicio.getAllPrimerosIngresos();
		//    return View(primerosIngresos);
		//}

    }
}