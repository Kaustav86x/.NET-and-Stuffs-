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

        [HttpGet("TrainList")]
        // search for a particular train
        // [Authorize] - haven't done yet
        public IActionResult GetTrainList(int train_id) 
        {
            var trainresult = _Railwaycontext.TrainDetails.Where(t => t.Id == train_id);
            if(trainresult == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(trainresult);
            }
        }

        [HttpGet("TrainListByTime")]
        // fetching train list on the basis of arrival time
        public IActionResult GetTrainListByTime(DateTime arrival)
        {
            
        }

    }
}
