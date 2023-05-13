using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Data;
using RealEstateAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        APIDbContext _dbContext = new APIDbContext(); // name of our dbcontext

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            /*return new string[] { "value1", "value2" };*/
            return _dbContext.Categories;
        }

        // GET api/<CategoriesController>/5
        // returning a particular value
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound("No data found");
            else
                // return the 200 status code
                return Ok(category);

        }
        // GET : api/<CategoriesController>/<Name_of_the_below_method>
        [HttpGet("[action]")]
        // same signature as Get method above
        public IActionResult GetSortCategories(int id) 
        {
            return Ok(_dbContext.Categories.OrderByDescending(x => x.Id));
        }

        // adding data to the database
        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] Category value)
        {
            _dbContext.Categories.Add(value);
            _dbContext.SaveChanges();
            // retruns 201 to indicate creation of data (addition)
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category value)
        {
            var cat = _dbContext.Categories.Find(id);
            if(cat == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            cat.Name = value.Name;
            cat.ImageUrl = value.ImageUrl; 
            _dbContext.SaveChanges();
            return Ok("Record updated successfully!");
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cat = _dbContext.Categories.Find(id);
            if (cat == null)
            {
                // either one is working fine
                return NotFound(id + " not found ");
                /*return StatusCode(StatusCodes.Status404NotFound);*/
            }
            else
            {
                _dbContext.Categories.Remove(cat);
                _dbContext.SaveChanges();
                return Ok("Record Deleted successfully !!");
            }
        }
    }
}
