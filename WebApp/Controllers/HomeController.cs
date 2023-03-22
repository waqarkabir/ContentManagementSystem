using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger logger;

        public IHostingEnvironment _hostingEnvironment { get; }

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment, ILogger<HomeController> logger)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }

        #region Returns string
        //public string Index()
        //{
        //    return _employeeRepository.GetEmployee(1).Name;
        //}
        #endregion

        #region Returns JsonResult when we need Json
        //public JsonResult Details()
        //{ 
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    return Json(model);
        //}
        #endregion

        #region Returns ObjectResult when we deal with apis
        //public ObjectResult ObjectDetails()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    return new OkObjectResult(model);
        //}
        #endregion

        #region Details
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            //throw new Exception("Error in Details View");
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");

            Employee employee = _employeeRepository.GetEmployee(id.Value);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }
        #endregion

        #region Index
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }

        #endregion

        #region Create
        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadFile(model);

                Employee newEmployee = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.AddEmployee(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }

            return View();
        }

        #endregion

        #region Edit

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel()
            {
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath

            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                if (model.Photos != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = ProcessUploadFile(model);
                }

                _employeeRepository.UpdateEmployee(employee);
                return RedirectToAction("index");
            }

            return View();
        }
        #endregion

        #region Process Upload File Method
        private string ProcessUploadFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photos != null && model.Photos.Count > 0)
            {
                foreach (var photo in model.Photos)
                {

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return uniqueFileName;
        }
        #endregion
    }
}
