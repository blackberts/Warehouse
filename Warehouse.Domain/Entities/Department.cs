namespace Warehouse.Domain.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Worker> Workers { get; set; }
        public List<Product> Products { get; set; }
    }
}
