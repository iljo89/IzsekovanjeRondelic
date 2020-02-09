using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IzsekovanjeRondelicLib;

namespace RESTApi.Controllers
{
    public class IzsekovanjeController : ApiController
    {
        [Route("api/izsekaj/get/{length}/{width}/{rondRadius}/{distBetRonds}/{distBetBord}")]
        public IEnumerable<OkroglaRondelica> GetList(int length, int width, int rondRadius, int distBetRonds, int distBetBord)
        {
            return IzsekovanjeRondelic.Izracunaj(length, width, rondRadius, distBetRonds, distBetBord);
        }
    }
}
