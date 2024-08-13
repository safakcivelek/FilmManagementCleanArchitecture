using FilmManagement.Application.Common.Responses;
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

        [HttpPost]
        //[Authorize(Roles ="user")]
        //[Authorize]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            ApiResponse<RegisterResponseDto> response = await _mediator.Send(request);
            return Created(uri: "", response);
        }
    }
}
