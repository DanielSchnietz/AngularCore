using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularWebApp.Services;
using AngularWebApp.Userclass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddNewUser([FromBody] User user)
        {
            //will be put in seperate class
            if (user == null)
            {
                return BadRequest("User Object is null");
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest("ModelState is not valid");
            }
            else
            {
               // var response = await UserService.CreateUser(user);
                return Created($"api/User/{response.Id}", JsonConvert.SerializeObject(response));
            }


        }
        // need to add json.serialize to the following responses.
        // putting the check for empty responses ( badrequest ) in additional class to avoid duplicate code
        // and better testing and debugging
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var db = new DatabaseAccess();
            var calculation = await db.GetCalculation();
            if (calculation == null)
            {
                return NotFound("No calculation found");
            }
            //  return Ok(JsonConvert.SerializeObject(calculation));
            return Ok();
        }

    }
}
