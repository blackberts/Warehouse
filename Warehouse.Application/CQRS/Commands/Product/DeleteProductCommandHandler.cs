using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Commands.Product
{
    public class DeleteProductCommandHandler : BaseCommandHandler<DeleteProductCommand, Unit>
    {
        public DeleteProductCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<Unit> ExecuteAsync(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.Product.DeleteById(request.Id);

            await UnitOfWork.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
