using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using Multishop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using Multishop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace Multishop.Order.WebApi.Controllers
{
    //Not: 
    //Infrastructure/Multishop.Order.Persistence/Repositories yazdığımız her repository için önce typeof türünde program.cs tarafına tanıtmak gerekir, hem de buradaki controller için de method eklemesi gerekiyor. 

    //Core/MultiShop.Order.Application/Features/Mediator içerisinde ekledğimiz commands,handler,queries, result class'ları ve interface'ler için de geçerli.Bunlara dikkat etmek gerekiyor.


    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var value = await _mediator.Send(new GetOrderingQuery());
            return Ok(value);
        }

        [HttpGet("GetOrderingByUserId/{id}")]
        public async Task<IActionResult> GetOrderingByUserId(string id)
        {
            var value = await _mediator.Send(new GetOrderingByUserIdQuery(id));
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Sipariş Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş Başarıyla Güncellendi");
        }

        [HttpGet("GetOrderTotalCount")]
        public async Task<IActionResult> GetOrderTotalCount()
        {
            var value = await _mediator.Send(new GetOrderingQuery());
            return Ok(value);
        }
    }
}
