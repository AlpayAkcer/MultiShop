using MediatR;
using Multishop.Order.Application.Features.Mediator.Results.OrderingResults;

namespace Multishop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    //Tüm listeyi döneceği için rütü IRequest=> List olarak kullanılacak.
    // Yani ben GetOrderingQuery'i çağırdığımda Ordering ile ilgili tüm liste gelecek.
    public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
    {

    }


}
