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
using RailwayManagementSystem.Models.DbModels;

namespace RailwayManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly RailwayDbContext _Railwaycontext;
        public int total_Seat = 0;

        public SeatController(RailwayDbContext context)
        {
            _Railwaycontext = context;
        }

        // GET: api/Seat
        [HttpGet]
        //[Authorize(Roles = "Admin,Passenger")]
        [Route("[action]")]
        public async Task<IActionResult> GetTCDID()
        {
          if (_Railwaycontext.TrainDetailClass == null)
          {
              return NotFound();
          }
            return Ok(await _Railwaycontext.TrainDetailClass.ToListAsync());
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        // to update seat number, we need to know the Class type and the train Id
        // first we have to check whether the reservation was successfull or not
        // check whether the payment table containing the reservationId or not
        public async Task<IActionResult> UpdateSeatDetails(string resId, string classtype, string TrainId)
        {
            
            var successful_reservation = await _Railwaycontext.Payments.FirstOrDefaultAsync(s => s.ReservationId == resId);
            if(successful_reservation == null)
            {
                return BadRequest("The user doesn't have a Reservation Id");
            }
            else
            {
                // checks whether the TCD Id from the classes table matches with TCD Id from the train table or not
                var cls = await _Railwaycontext.Classes.FirstOrDefaultAsync(c => c.Class_type == classtype);
                var train1 = await _Railwaycontext.TrainDetails.FirstOrDefaultAsync(t => t.Id == TrainId);
                var train2 = await _Railwaycontext.TrainDetails.FindAsync(TrainId);
                // this is to keep track of the seat capacity of a particular train
                foreach (var t in train2.TDCID) 
                //if()
                {
                    var cl = await _Railwaycontext.TrainDetailClass.FirstOrDefaultAsync(c => c.Id == t.ToString());
                    foreach(var c in cl.Classes)
                    {
                        total_Seat = total_Seat + c.SeatCapacity;
                    }
                }
                foreach(var c in cls.TDCID) 
                {
                    foreach(var t in train1.TDCID)
                    {
                        if(c == t)
                        {
                            total_Seat -= 1;
                        }
                    }
                }
            }
            return Ok();
        }

        // GET: api/Seat/5
        /*[HttpGet("{id}")]
        public async Task<ActionResult<Train_Detail_Class>> GetTrain_Detail_Class(string id)
        {
          if (_Railwaycontext.TrainDetailClass == null)
          {
              return NotFound();
          }
            var train_Detail_Class = await _Railwaycontext.TrainDetailClass.FindAsync(id);

            if (train_Detail_Class == null)
            {
                return NotFound();
            }

            return train_Detail_Class;
        }

        // PUT: api/Seat/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrain_Detail_Class(string id, Train_Detail_Class train_Detail_Class)
        {
            if (id != train_Detail_Class.Id)
            {
                return BadRequest();
            }

            _Railwaycontext.Entry(train_Detail_Class).State = EntityState.Modified;

            try
            {
                await _Railwaycontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Train_Detail_ClassExists(id))
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

        // POST: api/Seat
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Train_Detail_Class>> PostTrain_Detail_Class(Train_Detail_Class train_Detail_Class)
        {
          if (_Railwaycontext.TrainDetailClass == null)
          {
              return Problem("Entity set 'RailwayDbContext.TrainDetailClass'  is null.");
          }
            _Railwaycontext.TrainDetailClass.Add(train_Detail_Class);
            try
            {
                await _Railwaycontext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Train_Detail_ClassExists(train_Detail_Class.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrain_Detail_Class", new { id = train_Detail_Class.Id }, train_Detail_Class);
        }

        // DELETE: api/Seat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrain_Detail_Class(string id)
        {
            if (_Railwaycontext.TrainDetailClass == null)
            {
                return NotFound();
            }
            var train_Detail_Class = await _Railwaycontext.TrainDetailClass.FindAsync(id);
            if (train_Detail_Class == null)
            {
                return NotFound();
            }

            _Railwaycontext.TrainDetailClass.Remove(train_Detail_Class);
            await _Railwaycontext.SaveChangesAsync();

            return NoContent();
        }

        private bool Train_Detail_ClassExists(string id)
        {
            return (_Railwaycontext.TrainDetailClass?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
