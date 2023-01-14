using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Api.Controllers.Base;
using Warehouse.Application.CQRS.Commands.Department;
using Warehouse.Application.CQRS.Commands.Product;
using Warehouse.Application.CQRS.Queries.Department;
using Warehouse.Application.CQRS.Queries.Product;

namespace Warehouse.Api.Controllers
{
    public class ProductController : WarehouseBaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("get-all-products")]
        public async Task<IActionResult> GetAll()
        {
            GetAllProductsQuery query = new GetAllProductsQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GetById(GetByIdProductQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("delete-product")]
        public async Task<IActionResult> Delete(DeleteProductCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
