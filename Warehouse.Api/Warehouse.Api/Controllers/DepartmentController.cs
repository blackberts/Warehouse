using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Warehouse.Api.Controllers.Base;
using Warehouse.Application.CQRS.Commands.Department;
using Warehouse.Application.CQRS.Queries.Department;

namespace Warehouse.Api.Controllers
{
    public class DepartmentController : WarehouseBaseController
    {
        public DepartmentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("get-all-departments")]
        public async Task<IActionResult> GetAll()
        {
            GetAllDepartmentsQuery query = new GetAllDepartmentsQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GetById(GetByIdDepartmentQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPut("update-department")]
        public async Task<IActionResult> Update(UpdateDepartmentCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("create-department")]
        public async Task<IActionResult> Create(CreateDepartmentCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("delete-department")]
        public async Task<IActionResult> Delete(DeleteDepartmentCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
