using Multishop.Order.Application.Features.CQRS.Commands.AddressCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var value = await _repository.GetByIdAsync(command.AddressId);
            value.UserId = command.UserId;
            value.Name = command.Name;
            value.Surname = command.Surname;
            value.Email = command.Email;
            value.Phone = command.Phone;
            value.Country = command.Country;
            value.City = command.City;
            value.District = command.District;
            value.ZipCode = command.ZipCode;
            value.AddresLine1 = command.AddresLine1;
            value.AddresLine2 = command.AddresLine2;
            await _repository.UpdateAsync(value);
        }
    }
}
