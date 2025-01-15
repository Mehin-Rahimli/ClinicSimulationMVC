using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimulationMVC1.DAL;
using SimulationMVC1.ViewModels;

namespace SimulationMVC1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Employees=await _context.Employees.OrderByDescending(e=>e.Name).Take(5).ToListAsync()
            };
            return View(homeVM);
        }
    }
}
