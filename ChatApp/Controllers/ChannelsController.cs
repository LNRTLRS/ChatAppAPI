using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiteDB;
using ChatApp.Repository.Channels;
using ChatApp.Models;
using ChatApp.Mappers;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelsController : ControllerBase
    {
        private IChannel _manager;
        public ChannelsController(IChannel manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// Haalt een lijst van alle kanalen op
        /// </summary>
        /// <response code="200">Lijst opgehaald</response>
        // GET api/Channels
        [HttpGet]
        public ActionResult<IList<Models.Channel>> Get()
        {
            if(!(_manager.GetChannels()== null))
            {
                return Ok(_manager.GetChannels());
            } else
            {
                return NotFound();
            }
        }

        // GET api/Channels/5
        [HttpGet("{id}")]
        public ActionResult<Models.Channel> Get(int id)
        {
            if(id <= 0)
            {
                return BadRequest(id);
            } else if(_manager.GetChannel(id) == null)
            {
                return NotFound(id);
            } else
            {
                return Ok(Mapper.Map(_manager.GetChannel(id)));
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Models.Channel value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } else if(value == null)
            {
                return BadRequest();
            } else 
            {     
                _manager.CreateChannel(Mapper.Map(value));
                return Ok(value);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!(_manager.GetChannel(id) == null))
            {
                _manager.RemoveChannel(id);
                return Ok("Kanaal succesvol verwijderd");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
