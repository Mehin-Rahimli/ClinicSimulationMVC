using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationMVC1.Models;
using SimulationMVC1.ViewModels;

namespace SimulationMVC1.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Name).IsRequired().HasColumnType("varchar(max)");
            builder.HasIndex(d => d.Name).IsUnique();
        }
    }
}
