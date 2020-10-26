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


        public bool CommandExist(long id)
        {
            return context.CommandsItems.Any(e => e.Id == id);
        }



        ////////Create///////////////////

        [HttpPost]
        public async Task<ActionResult<Command>> CreateCommand(Command command)
        {
            context.CommandsItems.Add(command);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetSingleCommand", new { id = command.Id}, command);
        }


        ////////////Read single object and All objects/////////////////////

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Command>>> GetAllCommand()
        {
            return await context.CommandsItems.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Command>> GetSingleCommand(long id)
        {
            var commandItem = await context.CommandsItems.FindAsync(id);

            if(commandItem == null)
            {
                return NotFound();
            }

            return Ok(commandItem);

        }

        

        //////////Update the Object/////////////
        [HttpPut("{id}")]
        public async Task<IActionResult>  UpdateCommand(long id, Command command)
        {

            if(id != command.Id)
            {
                return BadRequest();
            }

            context.Entry(command).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!CommandExist(id))
                {

                    return NotFound();

                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
   

        ///////Delete Object/////////
        [HttpDelete("{id}")]
        public async Task<ActionResult<Command>> DeleteCommand(long id)
        {
            var deletedItem = await context.CommandsItems.FindAsync(id);

            if(deletedItem == null)
            {
                return NotFound();
            }

            context.CommandsItems.Remove(deletedItem);
            await context.SaveChangesAsync();


            return deletedItem;
        }
        

       
    }
}
