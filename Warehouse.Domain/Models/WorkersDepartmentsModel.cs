using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Models
{
    public class WorkersDepartmentsModel
    {
        public Guid WorkerId { get; set; }
        public Guid DepartmentId { get; set; }

        public Worker Worker { get; set; }
        public Department Department { get; set; }
    }
}
