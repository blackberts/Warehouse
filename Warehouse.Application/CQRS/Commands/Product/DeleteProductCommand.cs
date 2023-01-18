using MediatR;

namespace Warehouse.Application.CQRS.Commands.Product
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }    
    }
}
