using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator __mediator;
        protected IMediator Mediator => __mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}