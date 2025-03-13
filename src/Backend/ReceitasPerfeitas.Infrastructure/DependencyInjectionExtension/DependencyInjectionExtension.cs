using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReceitasPerfeitas.Domain.Enums;
using ReceitasPerfeitas.Domain.Repositories;
using ReceitasPerfeitas.Infrastructure.Context;
using ReceitasPerfeitas.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasPerfeitas.Infrastructure.DependencyInjectionExtension
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configurantion )
        {
            var databaseType = configurantion.GetConnectionString("DatabaseType");

            var databaseTypeEnum = (DatabaseType) Enum.Parse(typeof(DatabaseType),  databaseType!);

            if (databaseTypeEnum == DatabaseType.SqlServe)
                AddDbContext_SqlServer(services, configurantion);
            else
                AddDbContext_PostgreSQL(services, configurantion);

            AddRepositories(services);
        }


        private static void AddDbContext_SqlServer(IServiceCollection services, IConfiguration configurantion)
        {
            var connetionString = configurantion.GetConnectionString("ConnectionSQLServer");

            services.AddDbContext<ReceitasPerfeitasDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connetionString);
            });
        }
        private static void AddDbContext_PostgreSQL(IServiceCollection services, IConfiguration configurantion)
        {

        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserRepository, UserRepository>();
            
        }
    }
}
