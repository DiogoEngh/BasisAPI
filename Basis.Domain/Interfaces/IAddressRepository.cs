using Basis.Domain.Aggregates.CustomerAggregate;

namespace Basis.Domain.Interfaces
{
    public interface IAddressRepository : IRepository
    {
        Task<List<Address>> GetByCustomerId(long id, int page = 1, int limit = 10);
        Task<Address?> GetByIdAndCustomerId(long id, long customerId);
        Task<int> Count(long id);
    }
}
