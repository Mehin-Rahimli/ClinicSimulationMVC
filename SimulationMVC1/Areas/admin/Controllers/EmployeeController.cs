using Microsoft.AspNetCore.Mvc;

namespace SimulationMVC1.Areas.admin.Controllers
{
    [Area("Admin")]

    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
