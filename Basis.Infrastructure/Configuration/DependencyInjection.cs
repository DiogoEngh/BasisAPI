using Basis.Domain.Interfaces;
using Basis.Application.Services;
using Basis.Infrastructure.Data.Context;
using Basis.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Basis.Application.Mapping;
using FluentValidation.AspNetCore;

namespace Basis.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, ApplicationDbContext>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            
            services.AddAutoMapper(typeof(CustomerProfile));

            services.AddFluentValidation(fv =>
            {
                var assemblyApplication = AppDomain.CurrentDomain.Load("Basis.Application");
                fv.RegisterValidatorsFromAssembly(assemblyApplication);
            });
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings__Default")));

            using (var context = services.BuildServiceProvider())
            {
                using var scope = context.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    try
                    {
                        dbContext.Database.Migrate();
                    } catch { }
                }
            }

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}