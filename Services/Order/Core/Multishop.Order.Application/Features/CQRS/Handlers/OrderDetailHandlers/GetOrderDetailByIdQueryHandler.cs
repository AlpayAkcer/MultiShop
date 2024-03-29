using Multishop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Multishop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = value.OrderDetailId,
                ProductAmount = value.ProductAmount,
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                TotalPrice = value.TotalPrice,
            };
        }
    }
}
