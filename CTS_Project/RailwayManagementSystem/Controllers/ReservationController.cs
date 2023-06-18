using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwayManagementSystem.Data;
using RailwayManagementSystem.Models.AddModels;
using RailwayManagementSystem.Models.DbModels;

namespace RailwayManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly RailwayDbContext _RailwayDbContext;

        public ReservationController(RailwayDbContext context)
        {
            _RailwayDbContext = context;
        }

        // GET: api/Reservation
         [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
         public async Task<IActionResult> GetReservations()
         {
           if (_RailwayDbContext.Reservations == null)
           {
               return NotFound("No reservation foumd");
           }
             return Ok(await _RailwayDbContext.Reservations.ToListAsync());
         }

        // GET: api/Reservation/5
         [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
         public async Task<IActionResult> GetReservationById(string id)
        {
          if (_RailwayDbContext.Reservations == null)
          {
              return NotFound();
          }
            var reservation = await _RailwayDbContext.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound("Reservation Id not found");
            }

            return Ok(reservation);
        }

        // DELETE: api/Reservation/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> DeleteReservation(string id)
        {
            if (_RailwayDbContext.Reservations == null)
            {
                return NotFound();
            }
            var reservation = await _RailwayDbContext.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
 
            _RailwayDbContext.Reservations.Remove(reservation);
            await _RailwayDbContext.SaveChangesAsync();

            return Ok("Reservation deleted successfully");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> AddReservation(string rid, [FromBody] AddReservation reservation)
        {
            if (_RailwayDbContext.Reservations == null)
                return NoContent();
            var reserv = await _RailwayDbContext.Reservations.FirstOrDefaultAsync(r => r.Id == rid);
            if(reserv == null)
            {
                var r = new Reservation()
                {
                    Id = reservation.Id,
                    Passenger = reservation.Passenger,
                    Date = reservation.Date,
                    UserId = reservation.UserId,
                    TrainId = reservation.TrainId

                };
                await _RailwayDbContext.Reservations.AddAsync(r);
                await _RailwayDbContext.SaveChangesAsync();
                return Ok("Reservation data added");
            }
            return BadRequest("Reservation Id already exists");
        }

    }
}
