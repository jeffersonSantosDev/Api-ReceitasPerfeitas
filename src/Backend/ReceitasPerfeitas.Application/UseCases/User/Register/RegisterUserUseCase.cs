using ReceitasPerfeitas.Application.Services.AutoMapper;
using ReceitasPerfeitas.Application.Services.Cryptography;
using ReceitasPerfeitas.Communication.Request;
using ReceitasPerfeitas.Communication.Response;
using ReceitasPerfeitas.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasPerfeitas.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisterUserJson Execute(RequestRegisterUserJson request)
        {
            //Validar a request
            Validate(request);

            //Mapear a request en uma entidade 
            var autoMapper = new AutoMapper.MapperConfiguration(opstions =>
            {
                opstions.AddProfile(new AutoMappingr());
            }).CreateMapper();

            var use = autoMapper.Map<Domain.Entities.User>(request);


            //Criptografia da senha 
            var passwordEncripted = new PasswordEncripter();
            use.Password = passwordEncripted.Encript(request.Password);


            //Salvar no Banco de dados
            return new ResponseRegisterUserJson { Name =  request.Name};
        }

        private void Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var erroMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErroOnValidationException(erroMessages);

            }
        }
    }
} 
