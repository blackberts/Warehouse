using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Entities;

namespace Warehouse.DataContext.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);

            builder.HasOne(product => product.Department)
                .WithMany(department => department.Products)
                .HasForeignKey(product => product.DeparmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(product => product.Name)
                .IsUnique(true);
        }
    }
}
