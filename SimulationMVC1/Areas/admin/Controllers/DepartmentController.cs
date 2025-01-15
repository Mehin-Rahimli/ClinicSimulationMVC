using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimulationMVC1.Areas.admin.ViewModels;
using SimulationMVC1.DAL;
using SimulationMVC1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulationMVC1.Areas.admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var departmentVM=await _context.Departments
                .Where(d=>!d.IsDeleted)
                .Include(d=>d.Employees)
                .Select(d=>new GetDepartmentVM
                {
                    Id = d.Id,
                    Name=d.Name,
                    EmployeeCount=d.Employees.Count
                }).ToListAsync();
            return View(departmentVM);
        }

        public async Task<IActionResult> Create()
        {
            CreateDepartmentVM departmentVM=new CreateDepartmentVM();
            return View(departmentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(CreateDepartmentVM departmentVM)
        {
            if (!ModelState.IsValid) return View();

            bool result=await _context.Departments.AnyAsync(d=>d.Name.Trim()==departmentVM.Name.Trim());
            if(result)
            {
                 ModelState.AddModelError("Name", "Department Name already exists");
                return View(departmentVM);
            }

            Department department = new Department
            {
                Name = departmentVM.Name
            };
            await _context.AddAsync(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult>Update(int? id)
        {
            if(id<1 || id==null) return BadRequest();

            Department department=await _context.Departments.FirstOrDefaultAsync(d=>d.Id==id);          
            if(department==null) return NotFound();
            UpdateDepartmentVM departmentVM = new()
            {
               
                Name = department.Name,
                Id = department.Id
            };
            
            return View(departmentVM);

        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult>Update(int? id,UpdateDepartmentVM departmentVM)
        {
            if (id < 1 || id == null) return BadRequest();

            Department existed = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
            if (existed == null) return NotFound();

            if (!ModelState.IsValid) return View(departmentVM);

            bool result=await _context.Departments.AnyAsync(d => d.Id!=id && d.Name.Trim()==departmentVM.Name.Trim());

            if (result)
            {
                ModelState.AddModelError(nameof(departmentVM.Name), "Name already exists");
                return View(departmentVM);
            }
            existed.Name=departmentVM.Name;
            _context.Departments.Update(existed);                
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id<1 || id==null) return BadRequest();
             Department department= await _context.Departments.FirstOrDefaultAsync(d=>d.Id==id);
            if(department==null) return NotFound();
           department.IsDeleted=true;
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
