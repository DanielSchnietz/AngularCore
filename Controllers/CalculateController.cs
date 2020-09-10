using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private InputObject content;
        private Calculate calc;
        [HttpPost]
        //JSON Formatierung hinzufügen
        public List<CostObjectWithPercentage> Get()
        {
            calc = new Calculate(content);
            return calc.Output;
        }
    }
}
