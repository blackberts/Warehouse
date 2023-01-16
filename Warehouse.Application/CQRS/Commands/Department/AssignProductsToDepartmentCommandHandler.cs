using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Entities;
using DepartmentEntity = Warehouse.Domain.Entities.Department;
using ProductEntity = Warehouse.Domain.Entities.Product;

namespace Warehouse.Application.CQRS.Commands.Department
{
    public class AssignProductsToDepartmentCommandHandler : BaseCommandHandler<AssignProductsToDepartmentCommand, Unit>
    {
        public AssignProductsToDepartmentCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<Unit> ExecuteAsync(AssignProductsToDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentModel = await UnitOfWork.Department.GetByIdAsync(request.DepartmentId);

            if(departmentModel is null) 
            {
                throw new ArgumentNullException("Cannot find department");
            }

            foreach(var productId in request.ProductIds)
            {
                var productModel = await UnitOfWork.Product.GetByIdAsync(productId);

                if(productModel is null)
                {
                    throw new ArgumentNullException("Cannot find product");
                }

                var productEntity = new ProductEntity
                {
                    Id = productId,
                    Name = productModel.Name,
                    DeparmentId = departmentModel.Id
                };

                UnitOfWork.Product.CreateDependencies(productEntity);
            }

            await UnitOfWork.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
