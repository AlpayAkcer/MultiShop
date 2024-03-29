using MediatR;
using Multishop.Order.Application.Features.Mediator.Results.OrderingResults;

namespace Multishop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult>
    {
        public int Id { get; set; }
        public GetOrderingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
