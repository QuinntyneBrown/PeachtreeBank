using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeachtreeBank.Core.Data;
using PeachtreeBank.Domain.Behaviours;
using PeachtreeBank.Domain.Features.Transactions;

namespace PeachtreeBank.Api
{
    public static class Dependencies
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PeachtreeBankDbContext>(options =>
            {
                options.UseSqlServer(configuration["Data:DefaultConnection:ConnectionString"], b => b.MigrationsAssembly("PeachtreeBank.Api"));
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(typeof(GetTransactions));

            services.AddControllers();
        }
    }
}
