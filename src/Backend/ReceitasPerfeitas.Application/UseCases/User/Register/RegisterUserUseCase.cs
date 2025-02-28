using AutoMapper;
using ReceitasPerfeitas.Application.Services.AutoMapper;
using ReceitasPerfeitas.Application.Services.Cryptography;
using ReceitasPerfeitas.Communication.Request;
using ReceitasPerfeitas.Communication.Response;
using ReceitasPerfeitas.Domain.Repositories;
using ReceitasPerfeitas.Exceptions.ExceptionsBase; 
namespace ReceitasPerfeitas.Application.UseCases.User.Register
{
    public class RegisterUserUseCase: IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserUseCase(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
        {
            //Validar a request
            Validate(request);
             

            var use = _mapper.Map<Domain.Entities.User>(request);


            //Criptografia da senha 
            var passwordEncripted = new PasswordEncripter();
            use.Password = passwordEncripted.Encript(request.Password);

            await _userRepository.Add(use);

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
