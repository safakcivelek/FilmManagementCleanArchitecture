using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagement.Application.Features.Purchases.Commands.Create
{
    public class CreatePurchaseCommandValidator : AbstractValidator<CreatePurchaseCommandRequest>
    {
        public CreatePurchaseCommandValidator()
        {
            RuleFor(x => x.FilmId).NotEmpty().WithMessage("Film ID boş olamaz.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı ID boş olamaz.");
        }
    }
}
