using Basis.Application.Interfaces;
using Basis.Application.Services;
using Basis.Domain.Interfaces;
using Infrastructure.Basis.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Basis.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork>();
            services.AddScoped<IRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}
