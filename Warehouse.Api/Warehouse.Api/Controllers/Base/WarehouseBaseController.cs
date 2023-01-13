using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Api.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseBaseController : ControllerBase
    {
        protected IMediator Mediator;

        protected WarehouseBaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
