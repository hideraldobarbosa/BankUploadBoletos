using Bank.Domain.Validation;
using Bank.Domain.Interfaces;
using Bank.Infra.Data.Repositories;
using Bank.InfraData.Context;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Infra.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddIoC(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddScoped<ICarteiraAtivosClienteRepository, CarteiraAtivosClienteRepository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
                                                                                             services.AddValidatorsFromAssemblyContaining
                <CreateCarteiraAtivosClientesValidation>();

            return services;
        }

    }
}
