using AutoMapper;
using ReceitasPerfeitas.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasPerfeitas.Application.Services.AutoMapper
{
    public class AutoMappingr: Profile
    {
        public AutoMappingr()
        {
            RequestToDomain();
        }
              
        private void RequestToDomain() {

            CreateMap<RequestRegisterUserJson, Domain.Entities.User>().
                ForMember(dest => dest.Password, opt => opt.Ignore());
        }

        private void DomainToResponse() { }
    }
}
