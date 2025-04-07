using System.Text.Json.Serialization;

namespace Basis.Application.DTOs.Address
{
    public class AddAddressDto
    {
        [JsonIgnore]
        public long CustomerId { get; set; }
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string? Complement { get; set; } = string.Empty;
    }
}
