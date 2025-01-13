using SimulationMVC1.Models;

namespace SimulationMVC1.Models
{
    public class Department:BaseEntity
    {
        
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
      
    }
}
