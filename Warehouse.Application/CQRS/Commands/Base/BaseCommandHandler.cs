using AutoMapper;
using Warehouse.Application.UoW;

namespace Warehouse.Application.CQRS.Commands.Base
{
    public abstract class BaseCommandHandler 
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;

        public BaseCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
    }
}
