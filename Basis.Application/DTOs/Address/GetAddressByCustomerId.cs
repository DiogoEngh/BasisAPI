namespace Basis.Application.DTOs.Address
{
    public class GetAddressByCustomerId
    {
        public long CustomerId { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
