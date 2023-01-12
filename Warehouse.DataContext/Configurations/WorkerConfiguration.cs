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

            builder.HasMany(worker => worker.Departments)
                .WithMany(department => department.Workers);

            builder.HasIndex(worker => worker.FullName)
                .IsUnique(true);
        }
    }
}
