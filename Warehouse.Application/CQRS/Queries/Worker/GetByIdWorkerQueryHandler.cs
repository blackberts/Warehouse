using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Queries.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Worker
{
    public class GetByIdWorkerQueryHandler : BaseQueryHandler<GetByIdWorkerQuery, WorkerModel>
    {
        public GetByIdWorkerQueryHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<WorkerModel> ExecuteAsync(GetByIdWorkerQuery request, CancellationToken cancellationToken)
        {
            var workerModel = await UnitOfWork.Worker.GetByIdAsync(request.Id);

            if (workerModel is null)
            {
                throw new ArgumentNullException($"Cannot find worker with id... : {request.Id} ");
            }

            return workerModel;
        }
    }
}
