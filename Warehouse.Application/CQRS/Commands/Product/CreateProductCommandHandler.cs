using AutoMapper;
using MediatR;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;
using ProductEntity = Warehouse.Domain.Entities.Product;

namespace Warehouse.Application.CQRS.Commands.Product
{
    public class CreateProductCommandHandler : BaseCommandHandler, IRequestHandler<CreateProductCommand, ProductModel>
    {
        public CreateProductCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ProductModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new ProductEntity
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            var productModel = await UnitOfWork.Product.CreateProductAsync(newProduct);

            if (productModel is null)
            {
                throw new ArgumentNullException("Something wrong when created product... ");
            }

            await UnitOfWork.SaveChangesAsync();

            return productModel;
        }
    }
}
