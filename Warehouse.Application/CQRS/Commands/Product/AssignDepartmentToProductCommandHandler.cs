using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using ProductEntity = Warehouse.Domain.Entities.Product;

namespace Warehouse.Application.CQRS.Commands.Product
{
    public class AssignDepartmentToProductCommandHandler : BaseCommandHandler<AssignDepartmentToProductCommand, Unit>
    {
        public AssignDepartmentToProductCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<Unit> ExecuteAsync(AssignDepartmentToProductCommand request, CancellationToken cancellationToken)
        {
            var productModel = await UnitOfWork.Product.GetByIdAsync(request.ProductId);

            if(productModel is null)
            {
                throw new ArgumentNullException("Cannot find product");
            }

            var departmentModel = await UnitOfWork.Product.GetByIdAsync(request.DepartmentId);

            if(departmentModel is null)
            {
                throw new ArgumentNullException("Cannot find department");
            }

            var productEntity = new ProductEntity
            {
                Id = productModel.Id,
                DeparmentId = departmentModel.Id,
            };

            UnitOfWork.Product.CreateDependencies(productEntity);
            await UnitOfWork.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
