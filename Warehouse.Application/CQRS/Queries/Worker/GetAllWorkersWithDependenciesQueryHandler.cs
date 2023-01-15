﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Queries.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Worker
{
    public class GetAllWorkersWithDependenciesQueryHandler : BaseQueryHandler<GetAllWorkersWithDependenciesQuery, List<WorkerModel>>
    {
        public GetAllWorkersWithDependenciesQueryHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<List<WorkerModel>> ExecuteAsync(GetAllWorkersWithDependenciesQuery request, CancellationToken cancellationToken)
        {
            var listOfModels = await UnitOfWork.Worker.GetAllWithDependenciesAsync();

            if (listOfModels is null || listOfModels.Count == 0)
            {
                throw new ArgumentNullException("Worker list is empty... ");
            }

            return listOfModels;
        }
    }
}
