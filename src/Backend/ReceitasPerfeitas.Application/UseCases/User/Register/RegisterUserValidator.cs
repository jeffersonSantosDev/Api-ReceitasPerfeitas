using FluentValidation;
using ReceitasPerfeitas.Communication.Request;
using ReceitasPerfeitas.Exceptions;

namespace ReceitasPerfeitas.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator <RequestRegisterUserJson>
    { 
        public RegisterUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessageException.NAME_EMPTY);
            RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessageException.EMAIL_EMPTY);
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessageException.EMAIL_INVALID);
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessageException.PASSWORD_EMPTY);
        }
    }
}
