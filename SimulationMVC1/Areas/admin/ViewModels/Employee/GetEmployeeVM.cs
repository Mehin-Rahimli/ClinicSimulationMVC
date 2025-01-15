using SimulationMVC1.Models;

namespace SimulationMVC1.Areas.admin.ViewModels
{
    public class GetEmployeeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        public string? FbLink { get; set; }
        public string? TwitterLink { get; set; }
        public string? InstagramLink { get; set; }
        public string DepartmentName { get; set; }

    }
}
