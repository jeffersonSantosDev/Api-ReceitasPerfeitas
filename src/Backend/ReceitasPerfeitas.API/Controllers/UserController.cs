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
        private readonly IRegisterUserUseCase _registerUserUseCase;
        public UserController(IRegisterUserUseCase registerUserUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
        }


        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson),StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(RequestRegisterUserJson request)
        { 
            var result = await _registerUserUseCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
     
}
