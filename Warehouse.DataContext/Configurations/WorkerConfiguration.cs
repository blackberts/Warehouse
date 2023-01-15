using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Entities;

namespace Warehouse.DataContext.Configurations
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.HasKey(worker => worker.Id);

            builder.HasMany(worker => worker.WorkersDepartments)
                .WithOne(wd => wd.Worker)
                .HasForeignKey(wd => wd.WorkerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(worker => worker.FullName)
                .IsUnique(true);
        }
    }
}
