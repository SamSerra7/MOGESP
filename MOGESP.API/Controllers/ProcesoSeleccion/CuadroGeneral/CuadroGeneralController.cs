using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOGESP.ServiceLayer.Servicio;


namespace MOGESP.API.Controllers.ProcesoSeleccion.CuadroGeneral
{
   
    public class CuadroGeneralController : Controller
    {
        readonly CuadroGeneralServicio cuadroGeneralServicio = new CuadroGeneralServicio();
        // GET api/values
        //[HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        //?idGroup=2
        [HttpPost("api/cuadroGeneral/{idConvocatoria}")]
        public IEnumerable<int> GetNumeroFlujos(int idConvocatoria)
        {

            string path = Request.Path.Value;
            int startIndex = path.Length - "/api/cuadroGeneral/".Length;
            string idString = path.Substring("/api/cuadroGeneral/".Length, startIndex);
            //int id = System.Convert.ToInt32(idString);

            IEnumerable<int> flujos = cuadroGeneralServicio.traerNumerosDeFlujoPorConvocatoria(idString);
            return flujos;
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
