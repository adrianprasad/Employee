using Employee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Employee.Data;
using Employee.Entity;
using Employee.ViewModels;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeTable _employeeTable;
        private readonly IWebHostEnvironment _environment;


        public HomeController(ILogger<HomeController> logger, IEmployeeTable employeeTable, IWebHostEnvironment environment)
        {
            _logger = logger;
            _employeeTable = employeeTable;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string fileName = null;
            if (employee.Profile != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                fileName = Guid.NewGuid().ToString() + "_" + employee.Profile.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    employee.Profile.CopyTo(fileStream);
                }
            }

            Employeedata addEmployee = new Employeedata()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Salary = employee.Salary,
                Profile = fileName 
            };

            _employeeTable.Insert(addEmployee);
            return RedirectToAction("EmployeeDetails");
        }

        public IActionResult EmployeeDetails()
        {
            var employees = _employeeTable.GetAll();
            return View(employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
