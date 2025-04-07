using Basis.Domain.Aggregates.CustomerAggregate;
using Basis.Domain.Interfaces;
using Basis.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Basis.Infrastructure.Data.Repositories
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

        public async Task<Customer?> GetByEmail(string email)
        {
            return await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<List<Customer>> Get(DateTime startDate, DateTime endDate, string? name, string? email, int page = 1, int limit = 10)
        {
            var query = _dbContext.Customers
                .Where(c => !c.DeletedAt.HasValue)
                .Include(c => c.Addresses)
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.ToLower().Contains(name.ToLower()));

            if (!string.IsNullOrEmpty(email))
                query = query.Where(c => c.Email.ToLower().Contains(email.ToLower()));

            query = query.Where(c => c.CreatedAt >= startDate.Date && c.CreatedAt < endDate.Date.AddDays(1));

            query = query.OrderByDescending(c => c.CreatedAt);

            var offset = page > 1 ? (page - 1) * limit : 0;
            var customers = await query.Skip(offset).Take(limit).ToListAsync();

            return customers;
        }

        public async Task<int> Count(DateTime startDate, DateTime endDate, string? name, string? email)
        {
            var query = _dbContext.Customers
                .Where(c => !c.DeletedAt.HasValue)
                .Include(c => c.Addresses)
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.ToLower().Contains(name.ToLower()));

            if (!string.IsNullOrEmpty(email))
                query = query.Where(c => c.Email.ToLower().Contains(email.ToLower()));

            query = query.Where(c => c.CreatedAt >= startDate.Date && c.CreatedAt < endDate.Date.AddDays(1));

            return await query.CountAsync();
        }

        public async Task<Customer?> GetById(long id)
        {
            return await _dbContext.Customers
                .AsQueryable()
                .Include(c => c.Addresses)
                .FirstOrDefaultAsync(c => c.Id == id && !c.DeletedAt.HasValue);
        }
    }
}
