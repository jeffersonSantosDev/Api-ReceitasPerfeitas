using AutoMapper; 
using ReceitasPerfeitas.Application.Services.Cryptography;
using ReceitasPerfeitas.Communication.Request;
using ReceitasPerfeitas.Communication.Response;
using ReceitasPerfeitas.Domain.Repositories;
using ReceitasPerfeitas.Exceptions;
using ReceitasPerfeitas.Exceptions.ExceptionsBase; 
namespace ReceitasPerfeitas.Application.UseCases.User.Register
{
    public class RegisterUserUseCase: IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly PasswordEncripter _passwordEncripter;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserUseCase(
            IUserRepository userRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            PasswordEncripter passwordEncripter)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
        {
            //Validar a request
            await Validate(request);
             
            //mapeando com Mapper
            var use = _mapper.Map<Domain.Entities.User>(request);

            //Criptografia da senha  
            use.Password = _passwordEncripter.Encript(request.Password);

            //Prepara os dados para se salvo no Banco de dados
            await _userRepository.Add(use);

            await _unitOfWork.Commit();

            return new ResponseRegisterUserJson { Name =  request.Name};
        }

        private async Task Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);


            var existemailUser = await _userRepository.ExistActiveUserWithEmail(request.Email);
            if (existemailUser)
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessageException.EMAIL_ALREDY_REGISTERED));


            if (result.IsValid == false)
            {
                var erroMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErroOnValidationException(erroMessages);
            }
        }
    }
} 
