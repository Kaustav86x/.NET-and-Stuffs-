using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwayManagementSystem.Data;
using RailwayManagementSystem.Models.DbModels;
using RailwayManagementSystem.Models.ViewModels;

namespace RailwayManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Train_detailController : ControllerBase
    {
        private readonly RailwayDbContext _RailwayDbContext;

        public Train_detailController(RailwayDbContext context)
        {
            _RailwayDbContext = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetTrainsForDestination([FromBody] GetTrainsByDestination trains)
        {
            if (_RailwayDbContext.TrainDetails == null)
            {
                return NoContent();
            }
            var trainList = _RailwayDbContext.TrainDetails.FirstOrDefault(snd => snd.Source == trains.Source && snd.Destination == trains.Destination);
            if(trainList == null) 
                return NotFound("No trains are found for this route");
            else
                return Ok(trainList);
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

            _RailwayDbContext.Entry(train_detail).State = EntityState.Modified;

            try
            {
                await _RailwayDbContext.SaveChangesAsync();
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
          if (_RailwayDbContext.TrainDetails == null)
          {
              return Problem("Entity set 'RailwayDbContext.TrainDetails'  is null.");
          }
            _RailwayDbContext.TrainDetails.Add(train_detail);
            await _RailwayDbContext.SaveChangesAsync();

            return CreatedAtAction("GetTrain_detail", new { id = train_detail.Id }, train_detail);
        }

        // DELETE: api/Train_detail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrain_detail(int id)
        {
            if (_RailwayDbContext.TrainDetails == null)
            {
                return NotFound();
            }
            var train_detail = await _RailwayDbContext.TrainDetails.FindAsync(id);
            if (train_detail == null)
            {
                return NotFound();
            }

            _RailwayDbContext.TrainDetails.Remove(train_detail);
            await _RailwayDbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool Train_detailExists(int id)
        {
            return (_RailwayDbContext.TrainDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
