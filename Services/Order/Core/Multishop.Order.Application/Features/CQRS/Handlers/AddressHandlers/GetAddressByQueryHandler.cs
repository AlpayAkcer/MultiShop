using Multishop.Order.Application.Features.CQRS.Commands.AddressCommands;
using Multishop.Order.Application.Features.CQRS.Queries.AddressQueries;
using Multishop.Order.Application.Features.CQRS.Results.AddressResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection.Emit;
using System.Xml.Linq;

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
                UserId = value.UserId,
                Name = value.Name,
                Surname = value.Surname,
                Email = value.Email,
                Phone = value.Phone,
                Country = value.Country,
                City = value.City,
                District = value.District,
                ZipCode = value.ZipCode,
                AddresLine1 = value.AddresLine1,
                AddresLine2 = value.AddresLine2
            };
        }
    }
}
