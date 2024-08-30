using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Purchases.Dtos;
using MediatR;

namespace FilmManagement.Application.Features.Purchases.Commands.Create
{
    public class CreatePurchaseCommandRequest : IRequest<ApiResponse<CreatePurchaseResponseDto>>
    {
        public Guid FilmId { get; set; }      
    }
}
