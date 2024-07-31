using FluentValidation;

namespace FilmManagement.Application.Features.Actors.Commands.Update
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommandRequest>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("Oyuncunun ID'si boş olamaz.");

            RuleFor(a => a.FirstName)
                .NotEmpty().WithMessage("Oyuncunun adı boş olamaz.")
                .MaximumLength(50).WithMessage("Oyuncunun adı en fazla 50 karakter olabilir.");

            RuleFor(a => a.LastName)
                .NotEmpty().WithMessage("Oyuncunun soyadı boş olamaz.")
                .MaximumLength(50).WithMessage("Oyuncunun soyadı en fazla 50 karakter olabilir.");
        }
    }
}
