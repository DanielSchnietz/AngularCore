using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Google.Cloud.Firestore;
using AngularWebApp.Repositorys;

namespace AngularWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {

        [HttpPost]
        //JSON Formatierung hinzufügen
        public async Task<CalculationDetailDTO> ReadStringDataManual(InputObject content)
        {
            var calc = new Calculate(content);
            return await calc.ForwardCalculation();

        }
        [HttpGet]
        public async Task<List<CalculationDetailDTO>> GetAllCalculations()
        {
            var db = new DatabaseAccess();

            return await db.GetCalculation();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CalculationDetailDTO>> GetCalculationById(string id)
        {
            var db = new DatabaseAccess();

            return await db.GetCalculationById(id);
        }
       [HttpDelete("{id}")]
       public async Task<ActionResult> DeleteCalculation(string id)
        {
            var db = new DatabaseAccess();
            await db.DeleteCalculationWithId(id);
            return Ok();
        }
    }
}
