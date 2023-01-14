using AutoMapper;
using MediatR;
using Warehouse.Application.CQRS.Queries.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Worker
{
    public class GetAllWorkersQueryHandler : BaseQueryHandler, IRequestHandler<GetAllWorkersQuery, List<WorkerModel>>
    {
        public GetAllWorkersQueryHandler(IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<List<WorkerModel>> Handle(GetAllWorkersQuery request, CancellationToken cancellationToken)
        {
            var listOfModels = await UnitOfWork.Worker.GetAllAsync();

            if (listOfModels is null || listOfModels.Count == 0)
            {
                throw new ArgumentNullException("Worker list is empty... ");
            }

            return listOfModels;
        }
    }
}
