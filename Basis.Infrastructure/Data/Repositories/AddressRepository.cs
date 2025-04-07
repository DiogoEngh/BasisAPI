using Basis.Domain.Aggregates.CustomerAggregate;
using Basis.Domain.Interfaces;
using Basis.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Basis.Infrastructure.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public AddressRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Address>> GetByCustomerId(long id, int page = 1, int limit = 10)
        {
            var query = _dbContext.Addresses.AsQueryable();

            query = query
                .Where(a => a.CustomerId == id)
                .OrderByDescending(a => a.CreatedAt);

            var offset = page > 1 ? (page - 1) * limit : 0;
            var addresses = await query.Skip(offset).Take(limit).ToListAsync();

            return addresses;
        }

        public async Task<int> Count(long id)
        {
            var query = _dbContext.Addresses.AsQueryable();

            query = query
                .Where(a => a.CustomerId == id);

            return await query.CountAsync();
        }

        public Task<Address?> GetByIdAndCustomerId(long id, long customerId)
        {
            return _dbContext.Addresses
                .AsQueryable()
                .FirstOrDefaultAsync(a => a.CustomerId == customerId && a.Id == id);
        }
    }
}
