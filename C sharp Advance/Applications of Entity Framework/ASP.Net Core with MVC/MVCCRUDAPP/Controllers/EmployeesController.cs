using Microsoft.AspNetCore.Mvc;
using MVCCRUDAPP.Data;
using MVCCRUDAPP.Models;
using MVCCRUDAPP.Models.Domain;

namespace MVCCRUDAPP.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDbContext demoDbContext;

        public EmployeesController(MVCDbContext demoDbContext)
        {
            this.demoDbContext = demoDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        // when we are submitting the form this method will be called
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmp)
        {
            // values have been updated, now changes in the database need to be made
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmp.Name,
                Email = addEmp.Email,
                Salary = addEmp.Salary,
                DateOfBirth = addEmp.DateOfBirth,
                Department = addEmp.Department
            };

            await demoDbContext.Employees.AddAsync(employee);
            await demoDbContext.SaveChangesAsync();
            // we'll get back to the Add method
            return RedirectToAction("Add");
        }
    }
}
