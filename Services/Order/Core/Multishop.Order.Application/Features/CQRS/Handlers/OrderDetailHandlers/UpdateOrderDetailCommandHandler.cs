using Multishop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.OrderDetailId);

            value.OrderingId = command.OrderingId;
            value.ProductId = command.ProductId;
            value.ProductPrice = command.ProductPrice;
            value.ProductName = command.ProductName;
            value.TotalPrice = command.TotalPrice;
            value.ProductAmount = command.ProductAmount;

            await _repository.UpdateAsync(value);
        }
    }
}
