using AutoMapper;
using MediatR;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;

namespace Warehouse.Application.CQRS.Commands.Product
{
    public class DeleteProductCommandHandler : BaseCommandHandler, IRequestHandler<DeleteProductCommand>
    {
        public DeleteProductCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.Product.DeleteById(request.Id);

            await UnitOfWork.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
