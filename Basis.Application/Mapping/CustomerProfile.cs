using AutoMapper;
using Basis.Application.DTOs.Address;
using Basis.Application.DTOs.Customer;
using Basis.Domain.Aggregates.CustomerAggregate;

namespace Basis.Application.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses));

            CreateMap<Address, AddressDto>();
        }
    }
}
