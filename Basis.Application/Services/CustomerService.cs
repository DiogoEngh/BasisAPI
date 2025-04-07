using Basis.Domain.Interfaces;
using Basis.Domain.Aggregates.CustomerAggregate;
using Basis.Domain.Common;
using AutoMapper;
using Basis.Application.DTOs.Customer;
using Basis.Domain.Common.Exceptions;

namespace Basis.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateCustomerDto customerDto)
        {
            var email = new Email(customerDto.Email);
            var customer = new Customer(customerDto.Name, email);

            if (await _customerRepository.GetByEmail(customer.Email) is not null)
                throw new ConflictException("Falha ao cadastrar, já existe um usuário com o e-mail informado.");

            await _customerRepository.Create(customer);
            await _customerRepository.UnitOfWork.SaveEntitiesAsync();
        }

        public async Task Delete(long id)
        {
            _customerRepository.UnitOfWork.BeginTransaction();

            try
            {
                var customer = await _customerRepository.GetById(id)
                    ?? throw new NotFoundException("Cliente informado não encontrado.");

                foreach (var address in customer.Addresses)
                {
                    address.Delete();
                }

                customer.Delete();

                await _customerRepository.UnitOfWork.CommitAsync();
            }
            catch
            {
                await _customerRepository.UnitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<PagedResult<CustomerDto>> Get(GetCustomerDto query)
        {
            var customers = await _customerRepository.Get(query.StartDate, query.EndDate, query.Name, query.Email, query.Page, query.Limit);
            var count = await _customerRepository.Count(query.StartDate, query.EndDate, query.Name, query.Email);
            var result = _mapper.Map<List<CustomerDto>>(customers);
            return new PagedResult<CustomerDto>(result, count, query.Limit);
        }

        public async Task Update(UpdateCustomerDto command)
        {
            var customer = await _customerRepository.GetById(command.Id) 
                ?? throw new NotFoundException("Cliente informado não encontrado.");
            
            customer.Update(command.Name);
            await _customerRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
