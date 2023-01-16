using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Api.Controllers.Base;
using Warehouse.Application.CQRS.Commands.Product;
using Warehouse.Application.CQRS.Commands.Worker;
using Warehouse.Application.CQRS.Queries.Product;
using Warehouse.Application.CQRS.Queries.Worker;

namespace Warehouse.Api.Controllers
{
    public class WorkerController : WarehouseBaseController
    {
        public WorkerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("get-all-workers")]
        public async Task<IActionResult> GetAll()
        {
            GetAllWorkersQuery query = new GetAllWorkersQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("get-all-workers-with-dependencies")]
        public async Task<IActionResult> GetAllWithDependencies()
        {
            GetAllWorkersWithDependenciesQuery query = new GetAllWorkersWithDependenciesQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GetById(GetByIdWorkerQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPut("update-worker")]
        public async Task<IActionResult> Update(UpdateWorkerCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpOptions("update-worker-firstName")]
        public async Task<IActionResult> UpdateFirstName(UpdateWorkerFirstNameCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpOptions("update-worker-lastName")]
        public async Task<IActionResult> UpdateLastName(UpdateWorkerLastNameCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("create-worker")]
        public async Task<IActionResult> Create(CreateWorkerCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("assign-departments")]
        public async Task<IActionResult> AssignDepartments(AssignDepartmentsToWorkerCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("delete-worker")]
        public async Task<IActionResult> Delete(DeleteWorkerCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
