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
        public Category Get(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            return category == null ? null : category;
        }

        // adding data to the database
        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] Category value)
        {
            _dbContext.Categories.Add(value);
            _dbContext.SaveChanges();
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category value)
        {
            var cat = _dbContext.Categories.Find(id);
            cat.Name = value.Name;
            cat.ImageUrl = value.ImageUrl; 
            _dbContext.SaveChanges();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cat = _dbContext.Categories.Find(id);
            _dbContext.Categories.Remove(cat);
            _dbContext.SaveChanges();
        }
    }
}
