using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Purchases.Commands.Create;
using FilmManagement.Application.Features.Purchases.Dtos;
using FilmManagement.Application.Features.Purchases.Queries.CheckIfPurchased;
using FilmManagement.Application.Features.Purchases.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FilmManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PurchasesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] CreatePurchaseCommandRequest request)
        {
            ApiResponse<CreatePurchaseResponseDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListPurchaseQuerRequest request)
        {
            ApiPagedResponse<GetListPurchaseResponseDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("check/{filmId}")]
        public async Task<IActionResult> CheckIfPurchased([FromRoute] Guid filmId)
        {
            CheckIfPurchasedQueryRequest request = new CheckIfPurchasedQueryRequest { FilmId = filmId };
            ApiResponse<bool> response = await _mediator.Send(request);
            return Ok(response);
        }
    }

}
