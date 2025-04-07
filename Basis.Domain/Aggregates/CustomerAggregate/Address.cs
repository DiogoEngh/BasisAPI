using Basis.Domain.Common.Exceptions;

namespace Basis.Domain.Aggregates.CustomerAggregate
{
    public class Address
    {
        public long Id { get; private set; }
        public long CustomerId { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Zipcode { get; private set; }
        public string Country { get; private set; }
        public string? Complement { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public Customer Customer { get; private set; }

        public Address() { }

        public Address(
            long customerId,
            string street,
            string number,
            string neighborhood,
            string city,
            string state,
            string zipCode,
            string country,
            string? complement)
        {
            CustomerId = customerId;
            Street = street.Trim();
            Number = number.Trim();
            Neighborhood = neighborhood.Trim();
            City = city.Trim();
            State = state.Trim();
            Zipcode = new Zipcode(zipCode).Value;
            Country = country.Trim();
            Complement = complement?.Trim();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            DeletedAt = null;
        }

        public void Update(
            string? street,
            string? number,
            string? neighborhood,
            string? city,
            string? state,
            string? zipCode,
            string? country,
            string? complement)
        {
            if (DeletedAt.HasValue)
                throw new NotFoundException("Endereço informado não encontrado.");

            Street = string.IsNullOrWhiteSpace(street) ? Street : street.Trim();
            Number = string.IsNullOrWhiteSpace(number) ? Number : number.Trim();
            Neighborhood = string.IsNullOrWhiteSpace(neighborhood) ? Neighborhood : neighborhood.Trim();
            City = string.IsNullOrWhiteSpace(city) ? City : city.Trim();
            State = string.IsNullOrWhiteSpace(state) ? State : state.Trim();
            Country = string.IsNullOrWhiteSpace(country) ? Country : country.Trim();
            Complement = string.IsNullOrWhiteSpace(complement) ? Complement : complement.Trim();
            Zipcode = new Zipcode(zipCode).Value;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Delete()
        {
            if (DeletedAt.HasValue)
                return;

            UpdatedAt = DateTime.UtcNow;
            DeletedAt = DateTime.UtcNow;
        }
    }
}
