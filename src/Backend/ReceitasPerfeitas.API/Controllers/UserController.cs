using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReceitasPerfeitas.Communication.Request;
using ReceitasPerfeitas.Communication.Response;

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
            return Created();
        }
    }
}
