using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Entities;

namespace Warehouse.DataContext.Configurations
{
    public class WorkersDepartmentsConfiguration : IEntityTypeConfiguration<WorkersDepartments>
    {
        public void Configure(EntityTypeBuilder<WorkersDepartments> builder)
        {
            builder.HasKey(c => new { c.WorkerId, c.DepartmentId });

            builder.HasOne(x => x.Department)
                .WithMany(x => x.WorkersDepartments)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Worker)
                .WithMany(x => x.WorkersDepartments)
                .HasForeignKey(x => x.WorkerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
