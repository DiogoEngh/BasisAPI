using AutoMapper;
using Basis.Domain.Common;
using Basis.Application.DTOs.Address;
using Basis.Domain.Aggregates.CustomerAggregate;
using Basis.Domain.Interfaces;
using Basis.Domain.Common.Exceptions;

namespace Basis.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public AddressService(
            IAddressRepository addressRepository, 
            ICustomerRepository customerRepository, 
            IMapper mapper)
        {
            _addressRepository = addressRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task Add(AddAddressDto query)
        {
            var customer = await _customerRepository.GetById(query.CustomerId) ?? throw new NotFoundException("Cliente não encontrado.");

            var address = new Address(
                customer.Id, query.Street,
                query.Number, query.Neighborhood, 
                query.City, query.State, query.Zipcode,
                query.Country, query.Complement);

            customer.AddAddress(address);
            await _addressRepository.UnitOfWork.SaveEntitiesAsync();
        }

        public async Task Delete(DeleteAddressDto command)
        {
            var address = await _addressRepository.GetByIdAndCustomerId(command.AddressId, command.CustomerId) ?? throw new NotFoundException("Endereço informado não encontrado.");
            address.Delete();
            await _addressRepository.UnitOfWork.SaveEntitiesAsync();
        }

        public async Task<PagedResult<AddressDto>> GetByCustomerId(GetAddressByCustomerId query)
        {
            var customer = await _customerRepository.GetById(query.CustomerId) ?? throw new NotFoundException("Cliente informado não encontrado.");
            var addresses = await _addressRepository.GetByCustomerId(customer.Id, query.Page, query.Limit);
            var count = await _addressRepository.Count(customer.Id);

            var result = _mapper.Map<List<AddressDto>>(addresses);

            return new PagedResult<AddressDto>(result, count, query.Limit);
        }

        public async Task Update(UpdateAddressDto command)
        {
            var address = await _addressRepository.GetByIdAndCustomerId(command.AddressId, command.CustomerId) ?? throw new NotFoundException("Endereço informado não encontrado.");

            address.Update(
                command.Street,
                command.Number,
                command.Neighborhood,
                command.City,
                command.State,
                command.Zipcode,
                command.Country,
                command.Complement);

            await _addressRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
