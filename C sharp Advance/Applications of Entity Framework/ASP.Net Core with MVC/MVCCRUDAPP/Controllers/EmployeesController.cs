using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        // to show something we need a view
        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            var emp = await demoDbContext.Employees.ToListAsync();
            return View(emp);
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
            // we'll get back to the Index method
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid Id) 
        { 
            var empId = await demoDbContext.Employees.FirstOrDefaultAsync(x => x.Id == Id);
            if(empId != null)
            {
                var UpdateEmp = new UpdateEmployeeViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = empId.Name,
                    Email = empId.Email,
                    Salary = empId.Salary,
                    DateOfBirth = empId.DateOfBirth,
                    Department = empId.Department
                };
                return await Task.Run(() => View("View",UpdateEmp));
            }
            return RedirectToAction("Index");
            
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            var employee = await demoDbContext.Employees.FindAsync(model.Id);
            if(employee != null) 
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Department = model.Department;

                await demoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var emp = await demoDbContext.Employees.FindAsync(model.Id);
            if(emp != null) 
            {
                demoDbContext.Employees.Remove(emp);
                await demoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
