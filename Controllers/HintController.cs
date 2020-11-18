using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularWebApp.Repositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AngularWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HintController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSpecificHint([FromQuery] string terms)
        {
            var splittedTerms = terms.Trim('"', '\'').Split(" ");
            var db = new DatabaseAccess();
            var hint = await db.CheckDbForHint(splittedTerms);
             if (hint == null)
            {
               return NotFound("No hint found");
            }
            return Ok(JsonConvert.SerializeObject(hint));
        }
    }
}
