using Basis.Domain.Common;
using Basis.Application.DTOs.Customer;

namespace Basis.Application.Services
{
    public interface ICustomerService
    {
        Task Create(CreateCustomerDto command);
        Task<PagedResult<CustomerDto>> Get(GetCustomerDto query);
        Task Update(UpdateCustomerDto command);
        Task Delete(long id);
    }
}
