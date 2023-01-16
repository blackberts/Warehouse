using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Models
{
    public class WorkerModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public List<WorkersDepartments> WorkersDepartments { get; set; }
    }
}
