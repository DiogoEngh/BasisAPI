using Basis.Domain.Aggregates.CustomerAggregate;
using Basis.Domain.Interfaces;
using Infrastructure.Basis.Data.Context;

namespace Infrastructure.Basis.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
        }
    }
}
