using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Models.User;
using VendingMachine.Application.Queries.User;

namespace VendingMachine.Presentation.Controllers.User
{
    [ApiController]
    [Route("api/v1.0/User")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> Get()
        {
            var user = await _mediator.Send(new GetUserQuery());
            return Ok(user);
        }
    }
}
