using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Queries.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Product
{
    public class GetByIdProductQueryHandler : BaseQueryHandler<GetByIdProductQuery, ProductModel>
    {
        public GetByIdProductQueryHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<ProductModel> ExecuteAsync(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var productModel = await UnitOfWork.Product.GetByIdAsync(request.Id);

            if (productModel is null)
            {
                throw new ArgumentNullException("cannot find product... ");
            }

            return productModel;
        }
    }
}
