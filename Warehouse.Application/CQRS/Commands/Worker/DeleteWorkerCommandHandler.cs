using AutoMapper;
using MediatR;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;

namespace Warehouse.Application.CQRS.Commands.Worker
{
    public class DeleteWorkerCommandHandler : BaseCommandHandler, IRequestHandler<DeleteWorkerCommand>
    {
        public DeleteWorkerCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<Unit> Handle(DeleteWorkerCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.Worker.DeleteById(request.Id);

            await UnitOfWork.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
