using Multishop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                TotalPrice = createOrderDetailCommand.TotalPrice,
                ProductPrice = createOrderDetailCommand.ProductPrice,
                ProductName = createOrderDetailCommand.ProductName,
                ProductId = createOrderDetailCommand.ProductId,
                ProductAmount = createOrderDetailCommand.ProductAmount,
                OrderingId = createOrderDetailCommand.OrderingId
            });
        }
    }
}

