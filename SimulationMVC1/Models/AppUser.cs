using Microsoft.AspNetCore.Identity;

namespace SimulationMVC1.Models
{
    public class AppUser:IdentityUser
    {
        public string  Name { get; set; }
        public string Surname { get; set; }
    }
}
