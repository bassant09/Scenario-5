using AppNest_Project.DTOS.AuthDto;
using AppNest_Project.Models;
using AppNest_Project.Services.AuthServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppNest_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;

        }
        [HttpPost("Register")]
        public async Task<ActionResult<ServicesRespone<int>>> Register(UserRegisterDto request)
        {
            var respone = await _authServices.Registeration(new User { UserName = request.UserName, Email = request.Email, Age = request.Age }, request.Password);
            if (!respone.Success)
            {
                return BadRequest(respone.Message);
            }
            return Ok(respone);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<ServicesRespone<int>>> Login(UserLoginDto request)
        {
            var respone = await _authServices.Login(request.Email, request.Password);
            if (!respone.Success)
            {
                return BadRequest(respone.Message);
            }
            return Ok(respone);
        }
    }
}
