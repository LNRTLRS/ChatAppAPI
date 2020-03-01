using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiteDB;
using ChatApp.Repository.Messages;
using ChatApp.Models;
using ChatApp.Mappers;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private IMessage _manager;
        public MessagesController(IMessage manager)
        {
            _manager = manager;
        }
        // GET api/Users
        [HttpGet]
        public ActionResult<IList<Models.Message>> GetMessages()
        {
            if (!(_manager.GetMessages() == null))
            {
                return Ok(_manager.GetMessages());
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/Users/5
        [HttpGet("{id}")]
        public ActionResult<Models.Message> Get(int id)
        {
            if(id <= 0)
            {
                return BadRequest(id);
            } else if(_manager.GetMessage(id) == null)
            {
                return NotFound(id);
            } else
            {
                return Ok(_manager.GetMessage(id));
            }
        }
        // GET api/Messages/Channel
        [HttpGet("Channel/{id}")]
        public ActionResult<IList<Models.Message>> GetFromChannel(int id)
        {
            if(id <= 0)
            {
                return BadRequest(id);
            } else if(_manager.GetFromChannel(id) == null)
            {
                return NotFound(id);
            } else
            {
                return Ok(_manager.GetFromChannel(id));
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Models.Message value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            } else
            {
                _manager.CreateMessage(Mapper.Map(value));
                return Ok();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!(_manager.GetMessage(id) == null))
            {
                _manager.DeleteMessage(id);
                return Ok("Bericht succesvol verwijderd");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
