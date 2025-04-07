using System.Text.Json.Serialization;

namespace Basis.Application.DTOs.Customer
{
    public class UpdateCustomerDto
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
