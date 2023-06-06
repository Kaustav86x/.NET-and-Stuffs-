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
    public class Train_detailController : ControllerBase
    {
        private readonly RailwayDbContext _context;

        public Train_detailController(RailwayDbContext context)
        {
            _context = context;
        }

        // GET: api/Train_detail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Train_detail>>> GetTrainDetails()
        {
          if (_context.TrainDetails == null)
          {
              return NotFound();
          }
            return await _context.TrainDetails.ToListAsync();
        }

        // GET: api/Train_detail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Train_detail>> GetTrain_detail(int id)
        {
          if (_context.TrainDetails == null)
          {
              return NotFound();
          }
            var train_detail = await _context.TrainDetails.FindAsync(id);

            if (train_detail == null)
            {
                return NotFound();
            }

            return train_detail;
        }

        // PUT: api/Train_detail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrain_detail(int id, Train_detail train_detail)
        {
            if (id != train_detail.Id)
            {
                return BadRequest();
            }

            _context.Entry(train_detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Train_detailExists(id))
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

        // POST: api/Train_detail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Train_detail>> PostTrain_detail(Train_detail train_detail)
        {
          if (_context.TrainDetails == null)
          {
              return Problem("Entity set 'RailwayDbContext.TrainDetails'  is null.");
          }
            _context.TrainDetails.Add(train_detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrain_detail", new { id = train_detail.Id }, train_detail);
        }

        // DELETE: api/Train_detail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrain_detail(int id)
        {
            if (_context.TrainDetails == null)
            {
                return NotFound();
            }
            var train_detail = await _context.TrainDetails.FindAsync(id);
            if (train_detail == null)
            {
                return NotFound();
            }

            _context.TrainDetails.Remove(train_detail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Train_detailExists(int id)
        {
            return (_context.TrainDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
