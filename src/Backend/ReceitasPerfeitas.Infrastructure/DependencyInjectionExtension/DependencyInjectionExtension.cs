using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReceitasPerfeitas.Domain.Repositories;
using ReceitasPerfeitas.Infrastructure.Context;
using ReceitasPerfeitas.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasPerfeitas.Infrastructure.DependencyInjectionExtension
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddDbContext_SqlServer(services);
            AddRepositories(services);
        }
         

        private static void AddDbContext_SqlServer(IServiceCollection services)
        {
            var connetionString = "Server=AR-PDBITP2-0006;Database=ReceitasPerfeitas;User Id=dev415;Password=dev415;TrustServerCertificate=True;";

            services.AddDbContext<ReceitasPerfeitasDbContext>(dbContextOptions => 
            {
                dbContextOptions.UseSqlServer(connetionString);
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {             
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
