using FluentValidation;

namespace FilmManagement.Application.Features.Directors.Commands.Delete
{
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommandRequest>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(d => d.Id)
            .NotEmpty().WithMessage("Director ID boş olamaz.")
            .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("Geçerli bir GUID formatında olmalıdır.");
        }
    }
}
