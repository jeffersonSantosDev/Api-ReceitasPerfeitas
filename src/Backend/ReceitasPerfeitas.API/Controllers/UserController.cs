using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReceitasPerfeitas.Application.UseCases.User.Register;
using ReceitasPerfeitas.Communication.Request;
using ReceitasPerfeitas.Communication.Response;
using ReceitasPerfeitas.Exceptions.ExceptionsBase;

namespace ReceitasPerfeitas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson),StatusCodes.Status201Created)]
        public IActionResult Register(RequestRegisterUserJson request)
        {
            var useCase = new RegisterUserUseCase();

            var result = useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
     
}
