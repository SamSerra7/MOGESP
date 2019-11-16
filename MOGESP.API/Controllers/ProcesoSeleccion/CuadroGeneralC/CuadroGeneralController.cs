using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOGESP.ServiceLayer.Servicio;
using MOGESP.Entities.Dominio;
using MOGESP.Entities.Utilidades;


namespace MOGESP.API.Controllers.ProcesoSeleccion.CuadroGeneralC
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
        public IEnumerable<int> GetNumeroFlujos(string idConvocatoria)
        {
            IEnumerable<int> flujos = cuadroGeneralServicio.traerNumerosDeFlujoPorConvocatoria(idConvocatoria);
            return flujos;
        }
        [HttpPost("api/cuadroGeneral/listaPI/{idConvocatoria}/{idFlujo}")]
        public ContenedorCuadrogeneral GetCuadroGeneral(string idConvocatoria, int idFlujo)
        {

            ContenedorCuadrogeneral cuadroGeneral = cuadroGeneralServicio.traeCuadroGeneral(idConvocatoria, idFlujo);
            return cuadroGeneral;
        }
        [HttpPost("api/cuadroGeneral/listaPIFiltrado/{idConvocatoria}/{idFlujo}/{filtroEstado}/{filtroPuesto}")]
        public ContenedorCuadrogeneral GetCuadroGeneral(string idConvocatoria, int idFlujo, int filtroEstado, int filtroPuesto)
        {

            ContenedorCuadrogeneral cuadroGeneral = cuadroGeneralServicio.traeCuadroGeneralFiltrado(idConvocatoria, idFlujo, filtroEstado, filtroPuesto);
            return cuadroGeneral;
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
