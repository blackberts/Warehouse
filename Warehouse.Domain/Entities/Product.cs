namespace Warehouse.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid DeparmentId { get; set; }
        public Department Department { get; set; }
    }
}
