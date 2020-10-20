using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommandAPI.Models;
using CommandAPI.Data;
using System.Threading.Tasks.Dataflow;

namespace CommandAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext context;

        public CommandsController(CommandContext cont)
        {
            context = cont;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Command>>> GetAllCommand()
        {
            return await context.Commands.ToListAsync();
        }


        //Get Single command by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Command>> GetSingleCommand(long id)
        {
            var commandItem = await context.Commands.FindAsync(id);

            if(commandItem == null)
            {
                return NotFound();
            }

            return Ok(commandItem);

        }
   
        

       
    }
}
