﻿using System;
using System.Threading.Tasks;
using AngularWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AngularWebApp.Repositorys;
using System.Collections.Generic;

namespace AngularWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> AddNewCalculation([FromBody] InputObject content)
        {
            //will be put in seperate class
            if(content == null)
            {
                return BadRequest("Calculation Object is null");
            }
            else if(!ModelState.IsValid)
            {
                return BadRequest("ModelState is not valid");
            }
            else
            {
                var response = await CalculationService.CreateCalculation(content);
                return Created($"api/calculate/{response.Id}", JsonConvert.SerializeObject(response));
            }


        }
        // need to add json.serialize to the following responses.
        // putting the check for empty responses ( badrequest ) in additional class to avoid duplicate code
        // and better testing and debugging
        [HttpGet]
        public async Task<IActionResult> GetAllCalculations()
        {
            var db = new DatabaseAccess();
            var calculation =  await db.GetCalculation();
            if (calculation == null)
            {
                return NotFound("No calculation found");
            }
            //  return Ok(JsonConvert.SerializeObject(calculation));
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalculationById(string id)
        {

            var db = new DatabaseAccess();
            var calculation = await db.GetCalculationById(id);
            if (calculation == null)
            {
                return NotFound($"No calculation with Id {id} found");
            }
            return Ok(JsonConvert.SerializeObject(calculation));
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

        //get request for hints
    }
}
