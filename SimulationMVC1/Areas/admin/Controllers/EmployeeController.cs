using Microsoft.AspNetCore.Mvc;

namespace SimulationMVC1.Areas.admin.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
