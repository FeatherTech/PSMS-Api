using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using DocApi.Models;
using DocApi.LogicLayer;
using System.Text.Json;
namespace PSMSWebApi.Controllers
{
    [Route("api/Admission")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        AdmissionLL _ll = new AdmissionLL(); 
        [HttpGet]    
        [Route("IsAlive")]
        public string IsAlive()
        {
            return "From some controller";
        }
       
        [Route("GetMiscFees")]
        [HttpPost]
        public List<MISC_FEES> GetMiscFees([FromBody] MISC_FEES tdt)
        {
            return _ll.GetMiscFees(tdt);
        }
       
        [Route("GetFeesStructure")]
        [HttpPost]
        public List<FEES_STRUCTURE> GetFeesStructure([FromBody] FEES_STRUCTURE tdt)
        {
            return _ll.GetFeesStructure(tdt);
        }
        [Route("GetAdmission")]
        [HttpPost]
        public List<ADMISSION> GetAdmission([FromBody] ADMISSION tdt)
        {
             return _ll.GetAdmission(tdt);
           
        }
        public class WeatherForecast
    {
        public DateTimeOffset DATEOFD { get; set; }
        public int TEMP { get; set; }
        public string? SUMM { get; set; }
    }

        [Route("InsertAdmission")]
        [HttpPost]
        public ADMISSION InsertAdmission([FromBody] ADMISSION tdt)
        {
           return _ll.InsertAdmission(tdt);
        }

        [Route("UpdateAdmission")]
        [HttpPost]
        public string UpdateAdmission([FromBody] ADMISSION tdt)
        {
           return _ll.UpdateAdmission(tdt);
        }
     
    }
}