using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCNETCORE.Data;
using MVCNETCORE.Models;
using MVCNETCORE.Models.Domain;

namespace MVCNETCORE.Controllers
{
    public class ShowEmployee : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext; // this is a private property

        public ShowEmployee(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index() // function that'll show all the data
        {
            var employees = await mvcDemoDbContext.Employees.ToListAsync(); 

        }

        /*public ShowEmployee()
        { }*/
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                DOB = addEmployeeRequest.DOB,
                Department = addEmployeeRequest.Department
            };

            await mvcDemoDbContext.Employees.AddAsync(employee);
            await mvcDemoDbContext.SaveChangesAsync();
            // after adding the page should be redirected to home/index/Add
            return RedirectToAction("Add");
        }

    }
}
