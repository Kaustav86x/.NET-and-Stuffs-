using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwayManagementSystem.Data;
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
        public async Task<IActionResult> PutClass(int id, Class @class)
        {
            if (id != @class.Id)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // POST: api/Class
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostClass(Class @class)
        {
          if (_RailwayDbContext.Classes == null)
          {
              return Problem("Entity set 'RailwayDbContext.Classes'  is null.");
          }
            _RailwayDbContext.Classes.Add(@class);
            await _RailwayDbContext.SaveChangesAsync();

            return CreatedAtAction("GetClass", new { id = @class.Id }, @class);
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

    }
}
