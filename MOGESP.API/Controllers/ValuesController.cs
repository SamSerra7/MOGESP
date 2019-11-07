﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MOGESP.API.Controllers
{
    
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet("api/values")]
        public ActionResult<IEnumerable<String>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("api/values/numerosflujos/{idConvocatoria}")]
        public ActionResult<IEnumerable<int>> GetNumFlujos(int idConvocatoria)
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
