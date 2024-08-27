using FilmManagement.Application.Features.Actors.Commands.Create;
using FluentValidation;

namespace FilmManagement.Application.Features.Genres.Commands.Create
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommandRequest>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(g => g.Name)
                .NotEmpty().WithMessage("Tür adı boş olamaz.")
                .MaximumLength(50).WithMessage("Tür adı en fazla 50 karakter olabilir.");

            RuleFor(g => g.Description)
                .MaximumLength(50).WithMessage("Açıklama alanı en fazla 500 karakter olabilir.");
        }
    }
}
