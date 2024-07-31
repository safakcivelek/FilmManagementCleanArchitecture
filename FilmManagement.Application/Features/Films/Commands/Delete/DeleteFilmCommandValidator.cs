using FluentValidation;

namespace FilmManagement.Application.Features.Films.Commands.Delete
{
    public class DeleteFilmCommandValidator :AbstractValidator<DeleteFilmCommandRequest>
    {
        public DeleteFilmCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Film ID boş olamaz.")
            .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("Geçerli bir GUID formatında olmalıdır.");
        }
    }
}
