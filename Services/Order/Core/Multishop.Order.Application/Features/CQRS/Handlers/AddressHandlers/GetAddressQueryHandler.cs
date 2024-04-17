using Multishop.Order.Application.Features.CQRS.Results.AddressResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                UserId = x.UserId,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Phone = x.Phone,
                Country = x.Country,
                City = x.City,
                District = x.District,
                ZipCode = x.ZipCode,
                AddresLine1 = x.AddresLine1,
                AddresLine2 = x.AddresLine2
            }).ToList();
        }
    }
}
