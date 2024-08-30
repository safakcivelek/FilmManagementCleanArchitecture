using AutoMapper;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace FilmManagement.Application.Features.Purchases.Queries.CheckIfPurchased
{
    public class CheckIfPurchasedQueryHandler : IRequestHandler<CheckIfPurchasedQueryRequest, ApiResponse<bool>>
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CheckIfPurchasedQueryHandler(IPurchaseRepository purchaseRepository, IHttpContextAccessor httpContextAccessor)
        {
            _purchaseRepository = purchaseRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<bool>> Handle(CheckIfPurchasedQueryRequest request, CancellationToken cancellationToken)
        {
            string? userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))            
                throw new UnauthorizedAccessException("Kullanıcı kimliği bulunamadı.");
            

            Purchase? purchase = await _purchaseRepository.GetAsync(p => p.FilmId == request.FilmId && p.UserId == Guid.Parse(userId));

            bool isPurchased = purchase != null;  // Eğer satın alım mevcutsa true, değilse false

            return new ApiResponse<bool>(isPurchased, isPurchased ? "Film satın alınmış." : "Film satın alınmamış.");
        }
    }
}
