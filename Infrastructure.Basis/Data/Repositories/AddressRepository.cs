using Basis.Domain.Interfaces;
using Infrastructure.Basis.Data.Context;

namespace Infrastructure.Basis.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public AddressRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
