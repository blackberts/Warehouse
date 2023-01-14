using AutoMapper;
using MediatR;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;
using ProductEntity = Warehouse.Domain.Entities.Product;

namespace Warehouse.Application.CQRS.Commands.Product
{
    public class UpdateProductCommandHandler : BaseCommandHandler, IRequestHandler<UpdateProductCommand, ProductModel>
    {
        public UpdateProductCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ProductModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productModel = await UnitOfWork.Product.GetByIdAsync(request.Id);

            if (productModel is null)
            {
                throw new ArgumentNullException("Cannot find product... ");
            }

            var productEntity = new ProductEntity
            {
                Id = productModel.Id,
                Name = request.Name,
            };

            var updatedProductModel = await UnitOfWork.Product.UpdateProductAsync(productEntity);

            if (updatedProductModel is null)
            {
                throw new ArgumentNullException("Something wrong when updated product... ");
            }

            await UnitOfWork.SaveChangesAsync();

            return updatedProductModel;
        }
    }
}
