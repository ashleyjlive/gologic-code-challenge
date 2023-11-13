using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Commands;
using VendingMachine.Application.Models.VendingMachine;
using VendingMachine.Application.Queries.VendingMachine;
using VendingMachine.Domain.Exceptions;
using VendingMachine.Presentation.Controllers.VendingMachine.Requests;

namespace VendingMachine.Presentation.Controllers.VendingMachine
{
    [ApiController]
    [Route("api/v1.0/VendingMachine")]
    public class VendingMachineController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VendingMachineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<VendingMachineDto>> Get()
        {
            var vendingMachine = await _mediator.Send(new GetVendingMachineQuery());
            return Ok(vendingMachine);
        }

        [HttpPost]
        [Route("Money/Add")]
        public async Task<ActionResult> AddMoney([FromQuery] AddMoneyRequest request)
        {
            try
            {
                await _mediator.Send(new AddMoneyCommand(request.Amount));
            } catch (InsufficientMoneyException)
            {
                return Problem("Insufficient user money");
            }
            return Ok();
        }

        [HttpPost]
        [Route("Purchase")]
        public async Task<ActionResult> PurchaseProduct([FromQuery] PurchaseProductRequest request)
        {
            try
            {
                await _mediator.Send(new PurchaseProductCommand(request.SlotId));
            }
            catch (InsufficientMoneyException)
            {
                return Problem("Insufficient money has been entered");
            }
            return Ok();
        }

        [HttpPost]
        [Route("ReturnChange")]
        public async Task<ActionResult> ReturnChange()
        {
            await _mediator.Send(new ReturnChangeCommand());
            return Ok();
        }
    }
}
