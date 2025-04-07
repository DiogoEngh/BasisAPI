using Basis.Domain.Common.Exceptions;

namespace Basis.Domain.Aggregates.CustomerAggregate
{
    public class Customer
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public List<Address> Addresses { get; private set; } = [];
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        public Customer() { }

        public Customer(string name, string email)
        {
            Name = name.Trim();
            Email = new Email(email).Value;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            DeletedAt = null;
        }

        public void Delete()
        {
            if (DeletedAt.HasValue)
                return;

            UpdatedAt = DateTime.UtcNow;
            DeletedAt = DateTime.UtcNow;
        }

        public void Update(string name)
        {
            if (DeletedAt.HasValue)
                throw new NotFoundException("Cliente informado não encontrado.");

            Name = name.Trim();
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddAddress(Address address)
        {
            if (DeletedAt.HasValue)
                throw new NotFoundException("Cliente informado não encontrado.");

            Addresses.Add(address);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
