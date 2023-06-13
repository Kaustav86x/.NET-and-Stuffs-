﻿using System;
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
    public class ReservationController : ControllerBase
    {
        private readonly RailwayDbContext _RailwayDbContext;

        public ReservationController(RailwayDbContext context)
        {
            _RailwayDbContext = context;
        }

        // GET: api/Reservation
         [HttpGet]
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

        // PUT: api/Reservation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(string id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            _RailwayDbContext.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _RailwayDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }*/

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

    }
}