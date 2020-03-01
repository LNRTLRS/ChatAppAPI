using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiteDB;
using ChatApp.Repository.Users;
using ChatApp.Models;
using ChatApp.Mappers;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUser _manager;
        public UsersController(IUser manager)
        {
            _manager = manager;
        }
        // GET api/Users
        [HttpGet]
        public ActionResult<IList<Models.User>> Get()
        {
            return Ok(_manager.GetUsers());
        }

        // GET api/Users/5
        [HttpGet("{id}")]
        public ActionResult<Models.User> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest(id);
            }
            else if (_manager.GetUser(id) == null)
            {
                return NotFound(id);
            }
            else
            {
                return Ok(_manager.GetUser(id));
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Models.User value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                foreach(Repository.Users.User user in _manager.GetUsers())
                {
                    if(user.Username == value.Username)
                    {
                        return BadRequest();
                    } else if(user.ID == value.ID)
                    {
                        return BadRequest();
                    }
                }
                _manager.AddUser(Mapper.Map(value));
                return Ok();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(!(_manager.GetUser(id) == null)) {
                _manager.RemoveUser(id);
                return Ok("Gebruiker succesvol verwijderd");
            } else
            {
                return BadRequest();
            }
        }
    }
}
