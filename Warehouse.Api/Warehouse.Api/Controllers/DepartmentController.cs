using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Api.Controllers.Base;

namespace Warehouse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : WarehouseBaseController
    {
        public DepartmentController(IMediator mediator) : base(mediator)
        {
        }


    }
}
