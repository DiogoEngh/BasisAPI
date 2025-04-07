namespace Basis.Application.DTOs.Customer
{
    public class GetCustomerDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
