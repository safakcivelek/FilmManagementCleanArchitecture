using AutoMapper;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Purchases.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FilmManagement.Application.Features.Purchases.Queries.GetList
{
    public class GetListPurchaseQuerHandler : IRequestHandler<GetListPurchaseQuerRequest, ApiPagedResponse<GetListPurchaseResponseDto>>
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetListPurchaseQuerHandler(IMapper mapper, IPurchaseService purchaseService, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _purchaseService = purchaseService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiPagedResponse<GetListPurchaseResponseDto>> Handle(GetListPurchaseQuerRequest request, CancellationToken cancellationToken)
        {
            string? userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("Kullanıcı kimliği bulunamadı.");
            }
           
            int count = await _purchaseService.CountAsync(
                predicate: null,
                withDeleted: false,
                enableTracking: false
                );         
        
            ApiPagedResponse<Purchase> getPurchasesResponse = await _purchaseService.GetListAsync(
                predicate: p => p.UserId == Guid.Parse(userId),
                include: purchase => purchase.Include(p => p.Film),

                withDeleted:false,
                enableTracking:false,
                take: request.Limit,
                skip: request.Start
                );

            Guid nextLastPurchaseId = getPurchasesResponse.Data.LastOrDefault().Id;

            IList<GetListPurchaseResponseDto> responseDto = _mapper.Map<IList<GetListPurchaseResponseDto>>(getPurchasesResponse.Data);
            return new ApiPagedResponse<GetListPurchaseResponseDto>(
                 data:responseDto,
                 totalCount: count,
                 skip: request.Start,
                 take: request.Limit,
                 message:"Kullanıcının satın aldığı filmler başarıyla getirildi.",
                 200
                );
        }
    }
}
