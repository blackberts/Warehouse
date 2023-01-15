using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Warehouse.Domain.Entities;

namespace Warehouse.DataContext
{
    public class WarehouseDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkersDepartments> WorkersDepartments { get; set; }

        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
