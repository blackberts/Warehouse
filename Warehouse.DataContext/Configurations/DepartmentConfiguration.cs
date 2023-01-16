using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Entities;

namespace Warehouse.DataContext.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(department => department.Id);

            //builder.HasMany(department => department.Products)
            //    .WithOne(product => product.Department)
            //    .HasForeignKey(product => product.DeparmentId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(department => department.WorkersDepartments)
                .WithOne(wd => wd.Department)
                .HasForeignKey(wd => wd.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(department => department.Name)
                .IsUnique(true);
        }
    }
}
