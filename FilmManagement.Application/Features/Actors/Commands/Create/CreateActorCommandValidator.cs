using FluentValidation;

namespace FilmManagement.Application.Features.Actors.Commands.Create
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommandRequest>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty().WithMessage("Oyuncunun adı boş olamaz.")
                .MaximumLength(50).WithMessage("Oyuncunun adı en fazla 50 karakter olabilir.");

            RuleFor(a => a.LastName)
                .NotEmpty().WithMessage("Oyuncunun soyadı boş olamaz.")
                .MaximumLength(50).WithMessage("Oyuncunun soyadı en fazla 50 karakter olabilir.");
        }
    }
}
