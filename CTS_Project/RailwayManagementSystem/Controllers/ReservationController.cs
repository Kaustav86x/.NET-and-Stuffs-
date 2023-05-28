using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayManagementSystem.Data;

namespace RailwayManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        RailwayDbContext _Railwaycontext = new RailwayDbContext();
        [HttpGet("{id}")]
        [Authorize(Policy = "passenger")]
        public ActionResult GetReservationsByUserId(string userId)
        {
            var reservations = _Railwaycontext.Reservations.FirstOrDefault(r => r.User_id == userId);
            if (reservations == null) 
            {
                return NotFound("No reservations found with this Id");
            }
            else
                return Ok(_Railwaycontext.Reservations);
        }
    }
}
