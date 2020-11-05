using System;
using System.Threading.Tasks;
using AngularWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AngularWebApp.Repositorys;

namespace AngularWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> AddNewCalculation([FromBody] InputObject content)
        {
            if(content == null)
            {
                return BadRequest("Calculation Object is null");
            }
            else
            {
                var response = await Calculate.CreateCalculation(content);
                return Created($"api/calculate/{response.Id}", JsonConvert.SerializeObject(response));
            }


        }
        // need to add json.serialize to the following responses.
        // putting the check for empy responses ( badrequest ) in additional class to avoid duplicate code
        // and better testing and debugging
        [HttpGet]
        public async Task<IActionResult> GetAllCalculations()
        {
            var db = new DatabaseAccess();
            var calculation = await db.GetCalculation();
            if (calculation == null)
            {
                return BadRequest("No calculation found");
            }
            return Ok(calculation);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalculationById(string id)
        {

            var db = new DatabaseAccess();
            var calculation = await db.GetCalculationById(id);
            if (calculation == null)
            {
                return BadRequest($"No calculation with Id {id} found");
            }
            return Ok(calculation);
        }
       [HttpDelete("{id}")]
       public async Task<ActionResult> DeleteCalculation(string id)
        {
            var db = new DatabaseAccess();
            await db.DeleteCalculationWithId(id);
            return NoContent();
        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> ChangeCalculation(string id, [FromBody]InputObject calculation)
       // {
         //   var db = new DatabaseAccess();
         //   await db.ChangeCalculationById(id, calculation);
       // }
    }
}
