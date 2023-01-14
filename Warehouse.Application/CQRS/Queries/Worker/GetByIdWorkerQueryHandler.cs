using AutoMapper;
using MediatR;
using Warehouse.Application.CQRS.Queries.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Worker
{
    public class GetByIdWorkerQueryHandler : BaseQueryHandler, IRequestHandler<GetByIdWorkerQuery, WorkerModel>
    {
        public GetByIdWorkerQueryHandler(IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<WorkerModel> Handle(GetByIdWorkerQuery request, CancellationToken cancellationToken)
        {
            var workerModel = await UnitOfWork.Worker.GetByIdAsync(request.Id);

            if (workerModel is null)
            {
                throw new ArgumentNullException("Cannot find worker... ");
            }

            return workerModel;
        }
    }
}
