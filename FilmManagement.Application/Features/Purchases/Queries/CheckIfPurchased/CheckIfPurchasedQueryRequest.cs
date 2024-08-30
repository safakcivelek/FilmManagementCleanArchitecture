using FilmManagement.Application.Common.Responses;
using MediatR;


namespace FilmManagement.Application.Features.Purchases.Queries.CheckIfPurchased
{
    public class CheckIfPurchasedQueryRequest : IRequest<ApiResponse<bool>>
    {
        public Guid FilmId { get; set; }     
    }
}
