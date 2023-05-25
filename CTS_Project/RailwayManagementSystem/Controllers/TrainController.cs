using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayManagementSystem.Data;

namespace RailwayManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        RailwayDbContext _Railwaycontext = new RailwayDbContext();

        // search for a particular train
        [HttpGet("TrainListId")]
        public IActionResult GetTrainListById(int train_id)
        {
            var train = _Railwaycontext.TrainDetails.Where(c => c.Id == train_id);
            if (train == null)
            {
                return NotFound();
            }
            else
                return Ok(train);
        }

        [HttpGet("TrainListTime")]
        // fetching train list on the basis of arrival time
        public IActionResult GetTrainListByTime(DateTime arrival)
        {
            var traintime = _Railwaycontext.TrainDetails.Where(a => a.Arr_time == arrival.ToString());
            if (traintime == null) 
                return NotFound();
            else
                return Ok(traintime);
        }

    }
}
