using Microsoft.AspNetCore.Mvc;
using SimulationMVC1.DAL;

namespace SimulationMVC1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
