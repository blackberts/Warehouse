using AutoMapper;
using Warehouse.Application.UoW;

namespace Warehouse.Application.CQRS.Queries.Base
{
    public abstract class BaseQueryHandler
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;

        public BaseQueryHandler(IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
    }
}
