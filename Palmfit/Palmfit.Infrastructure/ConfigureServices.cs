

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Palmfit.Domain.Repository;
using Palmfit.Infrastructure.Data.Context;
//using Palmfit.Infrastructure.Repository;

namespace Palmfit.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)

        {
            services.AddDbContext<PalmfitDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Connection") ?? throw new InvalidOperationException("connection string not found"));
            });

            //services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
