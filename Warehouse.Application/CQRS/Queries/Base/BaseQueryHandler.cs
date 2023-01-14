using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.UoW;

namespace Warehouse.Application.CQRS.Queries.Base
{
    public abstract class BaseQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly ILogger Logger;

        public BaseQueryHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Request {typeof(TRequest).Name} processed");

            var result = await ExecuteAsync(request, cancellationToken);

            Logger.LogInformation($"Request {typeof(TRequest).Name} was successfully processed");

            return result;
        }

        protected abstract Task<TResponse> ExecuteAsync(TRequest request, CancellationToken cancellationToken);
    }
}
