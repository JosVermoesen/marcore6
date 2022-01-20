using marcore.Interfaces;
using marcore.Services;
using marcore.api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace marcore.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(x =>
            {
                x.UseLazyLoadingProxies();
                // "marDB": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=vbeheer_rv-services;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"    
                x.UseSqlServer(config.GetConnectionString("marDB"));

                // Using Sqlite for testen (limited functionality on migrations!!)
                // ** only usefull when dev on linux **
                // x.UseSqlite(Configuration.GetConnectionString("marDB"));        
                // "marDB": "Data Source=mar31.db"                
            });

            return services;
        }
    }
}