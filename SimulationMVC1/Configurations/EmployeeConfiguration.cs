using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationMVC1.Models;

namespace SimulationMVC1.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasColumnType("varchar(100)");
            builder.Property(b => b.Surname).HasColumnType("varchar(200)");


        }
    }
}
