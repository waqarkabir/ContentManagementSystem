using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController: Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
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

        #region Returns ViewResult
        public ViewResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel() 
            {
               Employee = model,
               PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }
        #endregion

        public ViewResult Index()
        { 
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }
    }
}
