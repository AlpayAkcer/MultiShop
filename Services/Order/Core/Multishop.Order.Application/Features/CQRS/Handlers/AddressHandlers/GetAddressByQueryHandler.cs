using Multishop.Order.Application.Features.CQRS.Queries.AddressQueries;
using Multishop.Order.Application.Features.CQRS.Results.AddressResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = value.AddressId,
                City = value.City,
                District = value.District,
                Detail = value.Detail,
                UserId = value.UserId
            };
        }
    }
}
