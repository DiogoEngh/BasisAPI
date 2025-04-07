using Basis.Domain.Aggregates.CustomerAggregate;

namespace Basis.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void Should_Create_Valid_Customer()
        {
            var name = "João da Silva";
            var email = "joao@email.com";
            
            var customer = new Customer(name, email);

            Assert.Equal(name, customer.Name);
            Assert.Equal(email, customer.Email);
        }
    }
}
