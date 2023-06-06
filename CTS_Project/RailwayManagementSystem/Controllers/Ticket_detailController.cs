using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly RailwayDbContext _context;

        public Ticket_detailController(RailwayDbContext context)
        {
            _context = context;
        }

        // GET: api/Ticket_detail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket_detail>>> GetTicketDetails()
        {
          if (_context.TicketDetails == null)
          {
              return NotFound();
          }
            return await _context.TicketDetails.ToListAsync();
        }

        // GET: api/Ticket_detail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket_detail>> GetTicket_detail(int id)
        {
          if (_context.TicketDetails == null)
          {
              return NotFound();
          }
            var ticket_detail = await _context.TicketDetails.FindAsync(id);

            if (ticket_detail == null)
            {
                return NotFound();
            }

            return ticket_detail;
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

            _context.Entry(ticket_detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
          if (_context.TicketDetails == null)
          {
              return Problem("Entity set 'RailwayDbContext.TicketDetails'  is null.");
          }
            _context.TicketDetails.Add(ticket_detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket_detail", new { id = ticket_detail.Id }, ticket_detail);
        }

        // DELETE: api/Ticket_detail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket_detail(int id)
        {
            if (_context.TicketDetails == null)
            {
                return NotFound();
            }
            var ticket_detail = await _context.TicketDetails.FindAsync(id);
            if (ticket_detail == null)
            {
                return NotFound();
            }

            _context.TicketDetails.Remove(ticket_detail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Ticket_detailExists(int id)
        {
            return (_context.TicketDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
