using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Commands.Department
{
    public class DeleteDepartmentCommandHandler : BaseCommandHandler<DeleteDepartmentCommand, Unit>
    {
        public DeleteDepartmentCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<Unit> ExecuteAsync(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.Department.DeleteById(request.Id);

            await UnitOfWork.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
