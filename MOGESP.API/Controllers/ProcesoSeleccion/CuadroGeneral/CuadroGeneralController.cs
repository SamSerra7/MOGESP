using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MOGESP.API.Controllers.ProcesoSeleccion.CuadroGeneral
{
   
    public class CuadroGeneralController : Controller
    {
        // GET api/values
        //[HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        //?idGroup=2
        [HttpGet("api/cuadrogeneral/numeroFlujos/{idConvocatoria}")]
        public ActionResult<IEnumerable<int>> GetNumeroFlujos(int idConvocatoria)
        {
            return new int[] { 1, 2, idConvocatoria };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
