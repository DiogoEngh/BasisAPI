using Basis.Domain.Common;
using Basis.Application.DTOs.Address;
using Basis.Application.DTOs.Customer;
using Basis.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Basis.API.Controllers
{
    [Tags("Customers")]
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IAddressService _addressService;
        public CustomersController(ICustomerService customerService, IAddressService addressService)
        {
            _customerService = customerService;
            _addressService = addressService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto request)
        {
            await _customerService.Create(request);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<CustomerDto>>> Get(string? name, string? email, DateTime? startDate = null, DateTime? endDate = null, int Page = 1, int Limit = 10)
        {
            var query = new GetCustomerDto
            {
                Name = name,
                Email = email,
                StartDate = startDate ?? DateTime.UtcNow.AddDays(-7),
                EndDate = endDate ?? DateTime.UtcNow,
                Page = Page,
                Limit = Limit
            };

            var customers = await _customerService.Get(query);
            return Ok(customers);
        }

        [HttpPatch("{id:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateCustomerDto request)
        {
            request.Id = id;
            await _customerService.Update(request);
            return NoContent();
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(long id)
        {
            await _customerService.Delete(id);
            return NoContent();
        }

        [HttpGet("{id:long}/addresses")]
        public async Task<ActionResult<PagedResult<AddressDto>>> GetAddress(long id, int page = 1, int limit = 10)
        {
            var query = new GetAddressByCustomerId
            {
                CustomerId = id,
                Page = page,
                Limit = limit
            };
            var addresses = await _addressService.GetByCustomerId(query);
            return Ok(addresses);
        }

        [HttpPost("{id:long}/addresses")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddAddress(long id, [FromBody] AddAddressDto request)
        {
            request.CustomerId = id;
            await _addressService.Add(request);
            return Ok();
        }

        [HttpPatch("{id:long}/addresses/{addressId:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAddress(long id, long addressId, [FromBody] UpdateAddressDto request)
        {
            request.AddressId = id;
            request.CustomerId = addressId;
            await _addressService.Update(request);
            return NoContent();
        }

        [HttpDelete("{id:long}/addresses/{addressId:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAddress(long id, long addressId)
        {
            var command = new DeleteAddressDto
            {
                CustomerId = id,
                AddressId = addressId
            };
            await _addressService.Delete(command);
            return NoContent();
        }
    }
}
