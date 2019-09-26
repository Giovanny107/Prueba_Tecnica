using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Business;
using Prueba_Tecnica.Models;

namespace Prueba_Tecnica.Controllers
{
    public class HomeController : Controller
    {
        internal readonly IEmployeesService _service;

        public HomeController(IEmployeesService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllEmployees(int id)
        {
            var model = new List<EmployeesDTO>();

            if (id == 0)
            {
                model = await _service.GetAllEmployeesAsync();
                return View(model);
            }
            else
            {
                var employee = await _service.GetEmployeeByIdAsync(id);
                model.Add(employee);
                return View(model);
            }
        }
    }
}
