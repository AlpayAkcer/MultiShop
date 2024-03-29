using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Order.Application.Features.CQRS.Commands.AddressCommands;
using Multishop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Multishop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Multishop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Multishop.Order.Application.Features.CQRS.Queries.AddressQueries;
using Multishop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace Multishop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        //Return geri veri dönüş tipi olan methodlarda query kullanılır.
        private readonly GetOrderDetailQueryHandler _queryHandler;
        private readonly GetOrderDetailByIdQueryHandler _orderDetailByIdQueryHandler;

        //Geri dönüş tipi olmayan methodlarda normal command kullanılır.
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

        public OrderDetailsController(GetOrderDetailQueryHandler queryHandler, GetOrderDetailByIdQueryHandler orderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
        {
            _queryHandler = queryHandler;
            _orderDetailByIdQueryHandler = orderDetailByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var value = await _queryHandler.Handle();
            return Ok(value);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailListById(int id)
        {
            var value = await _orderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _createOrderDetailCommandHandler.Handle(createOrderDetailCommand);
            return Ok("Sipariş Bilgisi Başarıyla Eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            await _updateOrderDetailCommandHandler.Handle(updateOrderDetailCommand);
            return Ok("Sipariş Bilgisi Başarıyla Güncellendi.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Sipariş Bilgisi Başarıyla Silindi.");
        }
    }
}
