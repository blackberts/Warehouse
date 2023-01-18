using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Queries.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Product
{
    public class GetAllProductsQueryHandler : BaseQueryHandler<GetAllProductsQuery, List<ProductModel>>
    {
        public GetAllProductsQueryHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<List<ProductModel>> ExecuteAsync(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var listOfModels = await UnitOfWork.Product.GetAllAsync();

            if (listOfModels is null || listOfModels.Count == 0)
            {
                throw new ArgumentNullException("Product list is empty... ");
            }

            return listOfModels;
        }
    }
}
