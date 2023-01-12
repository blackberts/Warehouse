using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid DeparmentId { get; set; }
        public Department Department { get; set; }
    }
}
