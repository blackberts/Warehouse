using Warehouse.Application.UoW;
using Warehouse.DataContext.Repositories.Department;

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
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
