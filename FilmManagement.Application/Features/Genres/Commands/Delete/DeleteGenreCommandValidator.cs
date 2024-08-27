using FilmManagement.Application.Features.Actors.Commands.Delete;
using FluentValidation;

namespace FilmManagement.Application.Features.Genres.Commands.Delete
{
    internal class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommandRequest>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(g => g.Id)
                .NotEmpty().WithMessage("Tür ID'si boş olamaz.");
        }
    }
}