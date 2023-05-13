using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Models;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private static List<Category> categories = new List<Category>()
        {
            new Category { Id = 1, Name = "A1", ImageUrl = "A1.png"},
            new Category { Id = 2, Name = "A2", ImageUrl = "A2.png"},
            new Category { Id = 3, Name = "A3", ImageUrl = "A4.pmg"}
        };

        [HttpGet] //api/categories
        public IEnumerable<Category> GetCategories() 
        {
            return categories; 
        }

        [HttpPost]
        public void PostCategories([FromBody] Category cat)
        {
            categories.Add(cat);
        }
    }
}
