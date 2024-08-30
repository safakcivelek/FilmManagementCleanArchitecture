using FilmManagement.Application.Abstracts.Repositories;
using FilmManagement.Application.Exceptions.Types;
using FilmManagement.Application.Features.Purchases.Constants;
using FilmManagement.Application.Rules;
using FilmManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagement.Application.Features.Purchases.Rules
{
    public class PurchaseBusinessRules : BaseBusinessRules
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly UserManager<User> _userManager;

        public PurchaseBusinessRules(IFilmRepository filmRepository, IPurchaseRepository purchaseRepository, UserManager<User> userManager)
        {
            _filmRepository = filmRepository;
            _purchaseRepository = purchaseRepository;
            _userManager = userManager;
        }

        public async Task<Film> FilmShouldExistWhenPurchased(Guid filmId)
        {
            Film? film = await _filmRepository.GetAsync(f => f.Id == filmId);
            if (film == null)
                throw new NotFoundException(PurchaseBusinessMessages.FilmNotFound);
            return film;
        }

        public async Task UserShouldExistWhenPurchased(Guid userId)
        {
            User? user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new NotFoundException(PurchaseBusinessMessages.UserNotFound);
        }

        public async Task FilmShouldNotBeAlreadyPurchased(Guid filmId, Guid userId)
        {
            bool existingPurchase = await _purchaseRepository.AnyAsync(p => p.FilmId == filmId && p.UserId == userId);
            if (existingPurchase)
                throw new BusinessException(PurchaseBusinessMessages.FilmAlreadyPurchased);
        }
    }
}
