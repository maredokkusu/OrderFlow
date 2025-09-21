using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderFlow.API.DTOs;
using OrderFlow.API.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(CustomRegisterRequestDto request)
        {
            var token = await _authService.RegisterAsync(
                request.Email, request.Password, request.UserName);
            if (token == null)
            {
                return BadRequest("This email is already in use");
            }
            return Ok(
            new {token});
        }
        

        [HttpPost("login")]
        public async Task<IActionResult> Login(CustomLoginRequest request)
        {
            var token = await _authService.LoginAsync(request.Email, request.Password);
            if (token == null) { return Unauthorized("Invalid Credentials"); }
            return Ok(new {token });
        }
        [Authorize]
        [HttpGet("profile")]
        public IActionResult Profile() {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value.ToString();
            return Ok(new {message="Valid Token",userId,userName, email, role});
                }
        //[Authorize]
        //[HttpDelete("delete")]
        //public async Task<IActionResult> Delete([FromBody] DeleteUserDto request) {
        //var user = await _usermanager}
    }
}