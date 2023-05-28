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

        // search for a particular train using Id
        [HttpGet("TrainListId")]
        public IActionResult GetTrainsById(int train_id)
        {
            var train = _Railwaycontext.TrainDetails.Where(c => c.Id == train_id);
            if (train == null)
            {
                return NotFound();
            }
            else
                return Ok(train);
        }
        [HttpGet("TrainName")]
        [Authorize(Policy = "passenger")]
        // finding train by name
        public IActionResult GetTrainNames(string Tname)
        {
            var trainname = _Railwaycontext.TrainDetails.Where(a => a.Train_name == Tname);
            if (trainname == null)
                return NotFound();
            else
                return Ok(trainname.ToList());
        }
        [HttpGet("TrainsAvailable")]
        [Authorize(Policy = "passenger")]
        public IActionResult GetTrains()
        {
            return Ok(_Railwaycontext.TrainDetails);
        }

    }
}
