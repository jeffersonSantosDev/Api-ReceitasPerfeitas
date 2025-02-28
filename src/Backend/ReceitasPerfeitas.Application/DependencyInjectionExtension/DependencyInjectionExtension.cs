using Microsoft.Extensions.DependencyInjection;
using ReceitasPerfeitas.Application.Services.AutoMapper;
using ReceitasPerfeitas.Application.UseCases.User.Register;
using ReceitasPerfeitas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasPerfeitas.Application.DependencyInjectionExtension
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);           
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            var autoMapper = 
            services.AddScoped(option => new AutoMapper.MapperConfiguration(opstions =>
            {
                opstions.AddProfile(new AutoMappingr());
            }).CreateMapper());
        }
        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }
    }
}
