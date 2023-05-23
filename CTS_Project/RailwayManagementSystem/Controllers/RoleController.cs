using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RailwayManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        [HttpGet("Admin")] 
        protected IActionResult Admin() 
        {
            return Ok();
        }
    }
}
