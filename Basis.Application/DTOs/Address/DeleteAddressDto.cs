using System.Text.Json.Serialization;

namespace Basis.Application.DTOs.Address
{
    public class DeleteAddressDto
    {
        [JsonIgnore]
        public long CustomerId { get; set; }
        [JsonIgnore]
        public long AddressId { get; set; }
    }
}
