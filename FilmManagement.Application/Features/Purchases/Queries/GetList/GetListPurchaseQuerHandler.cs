using AutoMapper;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Abstracts.Services;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Purchases.Dtos;
using FilmManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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

            //Bu alanı ortak bir servise alınmalı Mı?
            int count = await _purchaseService.CountAsync(
                predicate: null,
                withDeleted: false,
                enableTracking: false
                );

            int skip = request.Start ?? 0;
            int take = request.Limit ?? 10;
        
            ApiPagedResponse<Purchase> purchases = await _purchaseService.GetListAsync(
                predicate: p => p.UserId == Guid.Parse(userId),
                include: purchase => purchase.Include(p => p.Film),

                withDeleted:false,
                enableTracking:false,
                skip:skip,
                take:take
                );

            var responseDto = _mapper.Map<IList<GetListPurchaseResponseDto>>(purchases.Data);
            return new ApiPagedResponse<GetListPurchaseResponseDto>(
                 data:responseDto,
                 totalCount: count,
                 skip: skip,
                 take:take,
                 message:"Kullanıcının filmleri başarıyla getirildi.",
                 200
                );
        }
    }
}
