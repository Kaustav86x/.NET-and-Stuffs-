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
    public class ReservationController : ControllerBase
    {
        private readonly RailwayDbContext _context;

        public ReservationController(RailwayDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservation
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        //{
        //  if (_context.Reservations == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Reservations.ToListAsync();
        //}

        // GET: api/Reservation/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Reservation>> GetReservation(string id)
        //{
        //  if (_context.Reservations == null)
        //  {
        //      return NotFound();
        //  }
        //    var reservation = await _context.Reservations.FindAsync(id);

        //    if (reservation == null)
        //    {
        //        return NotFound();
        //    }

        //    return reservation;
        //}

        // PUT: api/Reservation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutReservation(string id, Reservation reservation)
        //{
        //    if (id != reservation.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(reservation).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ReservationExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Reservation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        //{
        //  if (_context.Reservations == null)
        //  {
        //      return Problem("Entity set 'RailwayDbContext.Reservations'  is null.");
        //  }
        //    _context.Reservations.Add(reservation);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ReservationExists(reservation.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
        //}

        // DELETE: api/Reservation/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteReservation(string id)
        //{
        //    if (_context.Reservations == null)
        //    {
        //        return NotFound();
        //    }
        //    var reservation = await _context.Reservations.FindAsync(id);
        //    if (reservation == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Reservations.Remove(reservation);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

    }
}
