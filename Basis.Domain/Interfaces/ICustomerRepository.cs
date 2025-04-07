using Basis.Domain.Aggregates.CustomerAggregate;

namespace Basis.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository
    {
        Task Create(Customer customer);
        Task<Customer?> GetByEmail(string email);
        Task<Customer?> GetById(long id);
        Task<List<Customer>> Get(DateTime startDate, DateTime endDate, string? name, string? email, int page = 1, int limit = 10);
        Task<int> Count(DateTime startDate, DateTime endDate, string? name, string? email);
    }
}