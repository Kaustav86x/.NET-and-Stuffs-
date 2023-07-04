using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
        public async Task<IActionResult> GetTrains()
        {
            if(_RailwayDbContext.TrainDetails == null)
                return NoContent();
            /*var trainList = _RailwayDbContext.*/
            return Ok(_RailwayDbContext.TrainDetails);
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
        public async Task<IActionResult> AddTrains(AddTrains addtrain)
        {
            //var trains = await _RailwayDbContext.TrainDetails.FindAsync(tid);
            //if (addtrain.Train_name != "string" && addtrain.Source != "string" && addtrain.Destination != "string" && addtrain.Arr_time != "string" && addtrain.Dept_time != "string" && addtrain.DateOfDeparture.ToString() != "string" && addtrain.Duration != 0)
            if (_RailwayDbContext.TrainDetails == null)
            {
                var addt = new Train_detail()
                {
                    Id = Guid.NewGuid().ToString(),
                    Source = addtrain.Source,
                    Destination = addtrain.Destination,
                    Train_name = addtrain.Train_name,
                    Arr_time = addtrain.Arr_time,
                    Dept_time = addtrain.Dept_time,
                    DateOfDeparture = addtrain.DateOfDeparture,
                    Duration = addtrain.Duration
                };
                await _RailwayDbContext.TrainDetails.AddAsync(addt);
                await _RailwayDbContext.SaveChangesAsync();
                return Ok("Train added successfully");
            }
            else
            {
                if (addtrain.Duration == 0)
                    return BadRequest("No column should contain null value");
            }
            await _RailwayDbContext.SaveChangesAsync();
            return Ok("Train Database updated!");
        }
            
        // DELETE: api/Train_detail/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> DeleteTrain(string id)
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

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> UpdateTrains(string tid, AddTrains addtrain)
        {
            var trains = await _RailwayDbContext.TrainDetails.FindAsync(tid);
            //if (addtrain.Train_name != "string" && addtrain.Source != "string" && addtrain.Destination != "string" && addtrain.Arr_time != "string" && addtrain.Dept_time != "string" && addtrain.DateOfDeparture.ToString() != "string" && addtrain.Duration != 0)
            if (trains != null)
            {
                trains.Source = addtrain.Source;
                trains.Destination = addtrain.Destination;
                trains.Train_name = addtrain.Train_name;
                trains.Arr_time = addtrain.Arr_time;
                trains.Dept_time = addtrain.Dept_time;
                trains.DateOfDeparture = addtrain.DateOfDeparture;
                trains.Duration = addtrain.Duration;

                await _RailwayDbContext.SaveChangesAsync();
                return Ok("Train Detail Updated");
            }
            return NotFound("Invalid train Id");
            }
        }
    }
