using Basis.Application.DTOs.Address;

namespace Basis.Application.DTOs.Customer
{
    public class CustomerDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<AddressDto> Addresses { get; set; } = [];
    }
}
