using Amazon.Runtime.Internal;
using Auth.Application.Modules.Auth.Interfaces;
using Auth.Domain.Dtos.Auth;
using Auth.Domain.Models.Auth;
using Auth.Domain.Models.Auth.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Authenticator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IAuthService _authService;

        public UserController(ILogger<UserController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpGet("/Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponseDto))]
        public async Task<ObjectResult> GetAcessToken(string user, string pass)
        {
            try
            {
                var result = await _authService.GetToken(user, pass);

                if (result == null)
                    return BadRequest("Login Invalido");

                return Ok(new ApiResponseDto {Data = result.access_token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/Users")]
        [Authorize("Bearer")]
        public async Task<ObjectResult> GetUsers(UserDto userDto)
        {
            try
            {

                var result = await _authService.CreateUser(userDto);

                if (result == null)
                    return BadRequest("Login Invalido");

                return Ok(new ApiResponseDto { Data = result.ToString()});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}