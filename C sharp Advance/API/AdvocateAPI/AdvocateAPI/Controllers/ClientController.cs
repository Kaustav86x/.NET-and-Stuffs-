using AdvocateAPI.Interface;
using AdvocateAPI.Models;
using AdvocateAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvocateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClient clients = new ClientRepository();
        [HttpPost]
        [Route("~/api/[controller]/AddClient")]
        [Consumes(contentType: "application/json")]
        public IActionResult Post([FromBody] Client client)
        {
           var result = clients.AddClient(client); 
           if(result == false) 
            {
                return StatusCode(500);
            }
            else
            {
                return Ok();
            }
        }
    }
}
