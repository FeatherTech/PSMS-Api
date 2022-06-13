using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using DocApi.DataLayer;


namespace PSMSWebApi.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public WeatherForecastController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        [Route("IsAlive")]
        public string IsAlive()
        {
            string toRtrn = "Did not Reach to Server";
             AdmissionDL dac = new AdmissionDL();
             toRtrn = dac.GetMySqlHealth();
            return toRtrn;
        }
        }
}
