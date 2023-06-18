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
    public class ClassController : ControllerBase
    {
        private readonly RailwayDbContext _RailwayDbContext;

        public ClassController(RailwayDbContext context)
        {
            _RailwayDbContext = context;
        }

        // GET: api/Class
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> GetClasses()
        {
          if (_RailwayDbContext.Classes == null)
          {
              return NotFound();
          }
            return Ok(await _RailwayDbContext.Classes.ToListAsync());
        }

        // GET: api/Class/5
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> GetClassById(int id)
        {
          if (_RailwayDbContext.Classes == null)
          {
              return NotFound();
          }
            var @class = await _RailwayDbContext.Classes.FindAsync(id);

            if (@class == null)
            {
                return NotFound("Class with that Id is not found");
            }
            return Ok(@class);
        }

        // PUT: api/Class/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> UpdateClassFareById(string id, int newFare)
        {
            var tclass = await _RailwayDbContext.Classes.FirstOrDefaultAsync(c => c.Id == id);
            if(tclass != null) 
            {
                tclass.Fare = newFare;
                await _RailwayDbContext.SaveChangesAsync();
                return Ok("Record updated successfully");
            }
            return BadRequest("Class Id doesn't exist");
        }

        // POST: api/Class
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> AddClass(string cid, AddClass addc)
        {
            var cls = await _RailwayDbContext.Classes.FirstOrDefaultAsync(c => c.Id == cid);
            var clsname = await _RailwayDbContext.Classes.FirstOrDefaultAsync(n => n.Class_type == addc.Class_type);

          if (_RailwayDbContext.Classes == null)
          {
                return NoContent() ;
          }
          if(cls == null)
          {
                if(clsname != null)
                {
                    return BadRequest("This Class name already exists");
                }
                var c = new Class()
                {
                    Class_type = addc.Class_type,
                    Fare = addc.Fare,
                    SeatCapacity = addc.SeatCapacity
                };
                await _RailwayDbContext.AddAsync(c);
                await _RailwayDbContext.SaveChangesAsync();
                return Created("201", "Class created");
           }
           return BadRequest("Class Id already exists");
        }

        // DELETE: api/Class/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            if (_RailwayDbContext.Classes == null)
            {
                return NotFound();
            }
            var @class = await _RailwayDbContext.Classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }

            _RailwayDbContext.Classes.Remove(@class);
            await _RailwayDbContext.SaveChangesAsync();
            return Ok("Role with that Id is deleted");
        }
        //[HttpPut]
        //[Authorize(Roles = "Admin")]
        //[Route("[action]")]
        //public async Task<IActionResult> UpdateSeat(int seacCap, string ClassType, int tid)
        //{
        //    // we'll get the class id from here
        //   var cls = await _RailwayDbContext.Classes.FirstOrDefaultAsync(c => c.Class_type == ClassType);
        //    // I need to find which train the user reserved
        //    // if tid matches with TrainId the user Reserved a class in that train 
        //    var train = await _RailwayDbContext.Reservations.FirstOrDefaultAsync(t => t.TrainId == tid);
        //    // var tclass = await _RailwayDbContext.TrainDetails.FirstOrDefaultAsync(v => v.)
        //    if(train != null)
        //    {
        //        // the user has registered and booked a class in a train

        //    }

            
           
        }

    }
