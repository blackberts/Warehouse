namespace Warehouse.Domain.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NeVazhno { get; set; }

        public List<WorkersDepartments> WorkersDepartments { get; set; }
        public List<Product> Products { get; set; }
    }
}
