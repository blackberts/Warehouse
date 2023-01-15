namespace Warehouse.Domain.Entities
{
    public class Worker
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public List<WorkersDepartments> WorkersDepartments { get; set; }
    }
}
