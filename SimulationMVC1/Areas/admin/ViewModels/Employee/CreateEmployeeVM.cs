using SimulationMVC1.Models;

namespace SimulationMVC1.Areas.admin.ViewModels.Employee
{
    public class CreateEmployeeVM
    {
        public IFormFile Image { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? FbLink { get; set; }
        public string? TwitterLink { get; set; }
        public string? InstagramLink { get; set; }
        public ICollection<Department>? Departments { get; set; }
        public int? DepartmentId { get; set; }
    }
}
