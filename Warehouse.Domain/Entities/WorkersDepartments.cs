namespace Warehouse.Domain.Entities
{
    public class WorkersDepartments
    {
        public Guid WorkerId { get; set; }
        public Guid DepartmentId { get; set; }

        public Worker Worker { get; set; }
        public Department Department { get; set; }
    }
}
