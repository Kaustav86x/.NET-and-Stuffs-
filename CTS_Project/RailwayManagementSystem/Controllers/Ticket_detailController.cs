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
using RailwayManagementSystem.Models.AddModels;
using Microsoft.AspNetCore.Cors;

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
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> GetTicket_detailById(int id)
        {
          if (_RailwayDbContext.TicketDetails == null)
          {
              return NotFound();
          }
            var ticket_detail = await _RailwayDbContext.TicketDetails.FindAsync(id);

            if (ticket_detail == null)
            {
                return NotFound("Ticket Id not found");
            }
            return Ok(ticket_detail);
        }

        // PUT: api/Ticket_detail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> GetTicketDetailsByPassengerName(string pass)
        {
            if (_RailwayDbContext.TicketDetails == null)
            {
                return NotFound();
            }
            var ticket_detail = await _RailwayDbContext.TicketDetails.FirstOrDefaultAsync(t => t.Passenger == pass);
            if (ticket_detail == null)
            {
                return NotFound("Passenger not found");
            }
            return Ok(ticket_detail);
        }

        // POST: api/Ticket_detail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> UpdateTicketDetails(int tid, [FromBody] UpdateTicketDetails ticket)
        {
          if (_RailwayDbContext.TicketDetails == null)
              return NoContent();
            var tick = await _RailwayDbContext.TicketDetails.FindAsync(tid);
            if (tick != null)
            {
                tick.Passenger = ticket.Passenger;
                tick.Class_type = ticket.Class_Type;
                tick.Seat_no = ticket.SeatNo;
                await _RailwayDbContext.SaveChangesAsync();
                return Ok("Ticket detail updated successfully");
            }
            return BadRequest("Ticket Id doesn't exist");
        }
        // DELETE: api/Ticket_detail/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> DeleteTicketDetails(string id)
        {
            if (_RailwayDbContext.TicketDetails == null)
            {
                return NoContent();
            }
            var ticket_detail = await _RailwayDbContext.TicketDetails.FirstOrDefaultAsync(t => t.Id == id);
            if(ticket_detail != null)
            {
                if (ticket_detail.Passenger == " " || ticket_detail.PaymentId == null)
                    return BadRequest("Ticket Detail must have a passenger name");
                _RailwayDbContext.TicketDetails.Remove(ticket_detail);
                await _RailwayDbContext.SaveChangesAsync();
                return Ok("Ticket detail deleted successfully");
            }
            return BadRequest("Ticket id is not valid");
        }
        [HttpPost]
        [Authorize(Roles = "Passenger")]
        [Route("[action]")]
        public async Task<IActionResult> AddTicket(string tid)
        {
            var tick = await _RailwayDbContext.TicketDetails.FirstOrDefaultAsync(t => t.Id == tid);
            if(tick == null)
            {
                var t = new Ticket_detail()
                {
                    Id = tick.Id,
                    Train_name = tick.Train_name,
                    Passenger = tick.Passenger,
                    Class_type = tick.Class_type,
                    Seat_no = tick.Seat_no,
                    Date = tick.Date,
                    PaymentId = tick.PaymentId
                };
                await _RailwayDbContext.TicketDetails.AddAsync(t);
                await _RailwayDbContext.SaveChangesAsync();
                return Ok("Ticket Details added successfully");
            }
            return BadRequest("Ticket Id already exists");
        }
    }
}
