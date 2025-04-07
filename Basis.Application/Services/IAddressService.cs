using Basis.Domain.Common;
using Basis.Application.DTOs.Address;

namespace Basis.Application.Services
{
    public interface IAddressService
    {
        Task<PagedResult<AddressDto>> GetByCustomerId(GetAddressByCustomerId query);
        Task Add(AddAddressDto query);
        Task Delete(DeleteAddressDto command);
        Task Update(UpdateAddressDto command);
    }
}
