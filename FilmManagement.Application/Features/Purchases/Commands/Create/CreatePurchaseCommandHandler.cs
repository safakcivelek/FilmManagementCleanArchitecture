using AutoMapper;
using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Exceptions.Types;
using FilmManagement.Application.Features.Purchases.Constants;
using FilmManagement.Application.Features.Purchases.Dtos;
using FilmManagement.Application.Features.Purchases.Rules;
using FilmManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagement.Application.Features.Purchases.Commands.Create
{
    public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommandRequest, ApiResponse<CreatePurchaseResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly PurchaseBusinessRules _purchaseBusinessRules;



        public CreatePurchaseCommandHandler(IMapper mapper, IPurchaseRepository purchaseRepository, PurchaseBusinessRules purchaseBusinessRules)
        {
            _mapper = mapper;
            _purchaseRepository = purchaseRepository;
            _purchaseBusinessRules = purchaseBusinessRules;
        }

        public async Task<ApiResponse<CreatePurchaseResponseDto>> Handle(CreatePurchaseCommandRequest request, CancellationToken cancellationToken)
        {
            var film = await _purchaseBusinessRules.FilmShouldExistWhenPurchased(request.FilmId);
            await _purchaseBusinessRules.UserShouldExistWhenPurchased(request.UserId);
            await _purchaseBusinessRules.FilmShouldNotBeAlreadyPurchased(request.FilmId, request.UserId);

            Purchase purchase = _mapper.Map<Purchase>(request);
            purchase.Price = film.Price;

            await _purchaseRepository.AddAsync(purchase);

            CreatePurchaseResponseDto responseDto = _mapper.Map<CreatePurchaseResponseDto>(purchase);

            return new ApiResponse<CreatePurchaseResponseDto>(responseDto,"Film başarıyla satın alındı.");
        }
    }
}
