using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MOGESP.UserInterface.Controllers
{
    public class AscensosController : Controller
    {
        public IActionResult AgregarConcurso()
        {
            return View();
        }

		public IActionResult FuncionarioYParticipacionEnPuestos()
		{
			return View();
		}
    }
}