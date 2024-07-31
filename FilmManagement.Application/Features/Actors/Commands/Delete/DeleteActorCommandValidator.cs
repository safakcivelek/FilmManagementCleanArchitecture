using FluentValidation;

namespace FilmManagement.Application.Features.Actors.Commands.Delete
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommandRequest>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("Oyuncunun ID'si boş olamaz.");
        }
    }
}
