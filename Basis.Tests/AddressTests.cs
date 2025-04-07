using Basis.Domain.Aggregates.CustomerAggregate;

namespace Basis.Tests
{
    public class AddressTests
    {
        [Fact]
        public void Should_Create_Valid_Address()
        {
            var customerId = 1;
            var street = "Rua das Flores";
            var number = "123";
            var neighborhood = "Jardim das Rosas";
            var city = "São Paulo";
            var state = "SP";
            var zipCode = "01234567";
            var country = "Brazil";
            var complement = "blabla";
            
            var address = new Address(customerId, street, number, neighborhood, city, state, zipCode, country, complement);
            
            Assert.Equal(street, address.Street);
            Assert.Equal(number, address.Number);
            Assert.Equal(neighborhood, address.Neighborhood);
            Assert.Equal(city, address.City);
            Assert.Equal(state, address.State);
            Assert.Equal(zipCode, address.Zipcode);
            Assert.Equal(country, address.Country);
            Assert.Equal(complement, address.Complement);
        }
    }
}