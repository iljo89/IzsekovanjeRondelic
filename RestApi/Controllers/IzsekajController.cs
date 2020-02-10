using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IzsekovanjeRondelicLib;
using System.Collections;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IzsekajController : ControllerBase
    {
        // GET: api/Izsekaj
        [HttpGet]
        public string Get()
        {
            return "Uporaba: api/izsekaj/<dolzina traku>,<sirina traku>,<polmer rondelice>,<razdalja med rondelicami>,<razdalja od roba>";
        }

        /*// GET: api/Izsekaj/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }*/

        [HttpGet("{dolzina},{sirina},{radius},{distRond},{distBord}", Name = "Get")]
        public IEnumerable <OkroglaRondelica> Get(int dolzina, int sirina, int radius, int distRond, int distBord)
        {
            return IzsekovanjeRondelic.Izracunaj(dolzina, sirina, radius, distRond, distBord);
        }

        /*// POST: api/Izsekaj
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Izsekaj/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
