using AutoMapper;
using MediatR;
using Warehouse.Application.CQRS.Queries.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Product
{
    public class GetByIdProductQueryHandler : BaseQueryHandler, IRequestHandler<GetByIdProductQuery, ProductModel>
    {
        public GetByIdProductQueryHandler(IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ProductModel> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var productModel = await UnitOfWork.Product.GetByIdAsync(request.Id);

            if (productModel is null)
            {
                throw new ArgumentNullException("Cannot find product... ");
            }

            return productModel;
        }
    }
}
