using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Models
{
    public class DepartmentModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<WorkersDepartments> WorkersDepartments { get; set; }
        public List<Product> Products { get; set; }
    }
}
