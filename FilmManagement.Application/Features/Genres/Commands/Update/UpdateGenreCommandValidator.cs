using FilmManagement.Application.Features.Genres.Commands.Update;
using FluentValidation;

namespace FilmManagement.Application.Features.Genres.Commands.Update
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommandRequest>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(g => g.Id)
                .NotEmpty().WithMessage("Tür ID'si boş olamaz.");

            RuleFor(g => g.Name)
                .NotEmpty().WithMessage("Tür adı boş olamaz.")
                .MaximumLength(50).WithMessage("Tür adı en fazla 50 karakter olabilir.");

            RuleFor(a => a.Description)            
                .MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olabilir.");
        }
    }
}
