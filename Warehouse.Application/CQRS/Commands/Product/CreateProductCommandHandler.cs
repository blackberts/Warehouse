using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;
using ProductEntity = Warehouse.Domain.Entities.Product;

namespace Warehouse.Application.CQRS.Commands.Product
{
    public class CreateProductCommandHandler : BaseCommandHandler<CreateProductCommand, ProductModel>
    {
        public CreateProductCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<ProductModel> ExecuteAsync(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new ProductEntity
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                DeparmentId = request.DepartmentId
            };

            UnitOfWork.Product.CreateDependencies(newProduct);
            var departmentModel = await UnitOfWork.Department.GetByIdAsync(request.DepartmentId);

            if (departmentModel is null)
            {
                throw new ArgumentNullException("Cannot find department");
            }
          
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
