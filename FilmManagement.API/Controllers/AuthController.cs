using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Auth.Commands.Login;
using FilmManagement.Application.Features.Auth.Commands.RefreshToken;
using FilmManagement.Application.Features.Auth.Commands.Register;
using FilmManagement.Application.Features.Auth.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //simulasyon için.
        [Authorize]
        [HttpGet("test-authorize")]
        public IActionResult TestAuthorize()
        {
            return Ok("Bu mesaj sadece yetkili kullanıcılar içindir.");
        }

        [HttpPost("register")]
        //[Authorize(Roles ="user")]
        //[Authorize]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            ApiResponse<RegisterResponseDto> response = await _mediator.Send(request);
            return Created(uri: "", response);
        }

        /// <summary>
        /// Kullanıcı giriş işlemi.
        /// </summary>
        /// <param name="request">Giriş bilgileri.</param>
        /// <returns>Access ve Refresh token içeren yanıt.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommandRequest request)
        {
            ApiResponse<LoginResponseDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// Refresh token ile access token yenileme işlemi.
        /// </summary>
        /// <param name="request">Refresh token bilgileri.</param>
        /// <returns>Yeni access ve refresh token içeren yanıt.</returns>
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommandRequest request)
        {
            ApiResponse<RefreshTokenResponseDto> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
