using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwayManagementSystem.Data;
using RailwayManagementSystem.Models.DbModels;

namespace RailwayManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ticket_detailController : ControllerBase
    {
        private readonly RailwayDbContext _RailwayDbContext;

        public Ticket_detailController(RailwayDbContext context)
        {
            _RailwayDbContext = context;
        }

        // GET: api/Ticket_detail
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> GetAllTickets()
        {
          if (_RailwayDbContext.TicketDetails == null)
          {
              return NotFound("No ticket details found in the database");
          }
            return Ok(_RailwayDbContext.TicketDetails);
        }

        // GET: api/Ticket_detail/5
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetTicket_detailByUsedId(int id)
        {
          if (_RailwayDbContext.TicketDetails == null)
          {
              return NotFound();
          }
            var ticket_detail = await _RailwayDbContext.TicketDetails.FindAsync(id);

            if (ticket_detail == null)
            {
                return NotFound();
            }

            return Ok(ticket_detail);
        }

        // PUT: api/Ticket_detail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket_detail(int id, Ticket_detail ticket_detail)
        {
            if (id != ticket_detail.Id)
            {
                return BadRequest();
            }

            _RailwayDbContext.Entry(ticket_detail).State = EntityState.Modified;

            try
            {
                await _RailwayDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ticket_detailExists(id))
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

        // POST: api/Ticket_detail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket_detail>> PostTicket_detail(Ticket_detail ticket_detail)
        {
          if (_RailwayDbContext.TicketDetails == null)
          {
              return Problem("Entity set 'RailwayDbContext.TicketDetails'  is null.");
          }
            _RailwayDbContext.TicketDetails.Add(ticket_detail);
            await _RailwayDbContext.SaveChangesAsync();

            return CreatedAtAction("GetTicket_detail", new { id = ticket_detail.Id }, ticket_detail);
        }

        // DELETE: api/Ticket_detail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket_detail(int id)
        {
            if (_RailwayDbContext.TicketDetails == null)
            {
                return NotFound();
            }
            var ticket_detail = await _RailwayDbContext.TicketDetails.FindAsync(id);
            if (ticket_detail == null)
            {
                return NotFound();
            }

            _RailwayDbContext.TicketDetails.Remove(ticket_detail);
            await _RailwayDbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool Ticket_detailExists(int id)
        {
            return (_RailwayDbContext.TicketDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
