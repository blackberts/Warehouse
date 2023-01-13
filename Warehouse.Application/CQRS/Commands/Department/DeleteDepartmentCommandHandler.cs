using AutoMapper;
using MediatR;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;

namespace Warehouse.Application.CQRS.Commands.Department
{
    internal class DeleteDepartmentCommandHandler : BaseCommandHandler, IRequestHandler<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.Department.DeleteById(request.Id);

            await UnitOfWork.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
