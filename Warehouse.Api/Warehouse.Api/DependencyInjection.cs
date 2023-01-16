using Warehouse.Application.UoW;
using Warehouse.DataContext.Repositories.Department;
using Warehouse.DataContext.Repositories.Product;
using Warehouse.DataContext.Repositories.Worker;
using Warehouse.DataContext.Repositories.WorkersDepartments;

namespace Warehouse.Api
{
    public static class DependencyInjection
    {
        public static void AddMyDependencyGroup(this IServiceCollection services)
        {           
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<DepartmentRepository>>();
            services.AddSingleton(typeof(ILogger), logger);

            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IWorkerRepository, WorkerRepository>();
            services.AddTransient<IWorkersDepartmentsRepository, WorkersDepartmentsRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
