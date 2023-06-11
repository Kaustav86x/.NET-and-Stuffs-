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
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetTrainsByName(string Tname)
        {
            var trains = _RailwayDbContext.TrainDetails.FirstOrDefaultAsync(t => t.Train_name == Tname);
            if (trains == null)
            {
                return NoContent();
            }
            return Ok(await trains);
        }

        // POST: api/Train_detail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> AddTrains([FromBody] AddTrains addtrain)
        {
            var trains = await _RailwayDbContext.TrainDetails.FindAsync(addtrain);
            if (addtrain.Train_name != "string" && addtrain.Source != "string" && addtrain.Destination != "string" && addtrain.Arr_time != "string" && addtrain.Dept_time != "string" && addtrain.Date.ToString() != "string")
            {
                var addt = new Train_detail()
                {
                    Source = addtrain.Source,
                    Destination = addtrain.Destination,
                    Train_name = addtrain.Train_name,
                    Arr_time = addtrain.Arr_time,
                    Dept_time = addtrain.Dept_time,
                    Date = new DateTime(2022, 01, 03)
                };
                await _RailwayDbContext.TrainDetails.AddAsync(addt);
                await _RailwayDbContext.SaveChangesAsync();
                return Ok("Train added successfully");
            }
            await _RailwayDbContext.SaveChangesAsync();
            return BadRequest("No column should contain null value");
            /*else
            {
                if (addtrain.Source == null || addtrain.Destination == null || addtrain.Arr_time == null || addtrain.Dept_time == null || addtrain.Train_name == null || addtrain.Date.ToString() == null)
                    return BadRequest("");
            }
            await _RailwayDbContext.SaveChangesAsync();
            return BadRequest("No two row can have identical set of data");*/
        }
            
        // DELETE: api/Train_detail/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> DeleteTrain(int id)
        {
            if (_RailwayDbContext.TrainDetails == null)
            {
                return NoContent();
            }
            var train_detail = await _RailwayDbContext.TrainDetails.FindAsync(id);
            if (train_detail == null)
            {
                return NotFound("No train found with id - " + id);
            }
            _RailwayDbContext.TrainDetails.Remove(train_detail);
            await _RailwayDbContext.SaveChangesAsync();

            return Ok("Train deleted successfully");
        }

        private bool Train_detailExists(int id)
        {
            return (_RailwayDbContext.TrainDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        /*[HttpGet]
        [Authorize(Roles = "Admin,Passenger")]
        [Route("[action]")]
        public async Task<IActionResult> GetTrainsByClass(string classid)
        {
            var trains = _RailwayDbContext.TrainDetails.FirstOrDefault(c => c. == classid)
        }*/
    }
}

/* _RailwayDbContext.Entry(train_detail).State = EntityState.Modified;

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

            return NoContent();*/
