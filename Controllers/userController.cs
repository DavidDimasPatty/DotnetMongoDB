using Microsoft.AspNetCore.Mvc;
using WebApi.Services;
using WebApi.Models;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IranwebService iranweb;


        public userController(IranwebService ranwebService)
        {
            this.iranweb = ranwebService;
        }

        [HttpGet]
        public ActionResult<List<user>> Get()
        {
            return iranweb.Get();
        }

 
        [HttpGet("{id}")]
        public ActionResult<user> Get(string id)
        {
            var user = iranweb.Get(id);
            if(user == null)
            {
                return NotFound("error");
            }
            return user;
        }


       [HttpPost]
       public ActionResult<user> Post([FromBody] user user )
        {
            iranweb.Create(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }


     [HttpPut("{id}")]
        public ActionResult<user> Put(string id, [FromBody] user user)
          {
                var existingUser = iranweb.Get(id);
                if (existingUser == null)
                {
                    return NotFound("Not Found");
                }

                iranweb.Update(id, user);
        
                return NoContent();
            }

    [HttpDelete("{id}")]
       public ActionResult<user> Delete(string id)
            {
                var existingUser = iranweb.Get(id);

                if (existingUser == null)
                {
                    return NotFound("Not Found");
                }

                iranweb.Remove(id);

                return Ok("Remove user");
            }

    }
}
