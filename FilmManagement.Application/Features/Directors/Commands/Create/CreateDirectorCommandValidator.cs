using FilmManagement.Application.Features.Directors.Commands.Create;
using FluentValidation;

namespace FilmManagement.Application.Features.Directors.Commands.Create
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommandRequest>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(d => d.FirstName)
            .NotEmpty().WithMessage("Yönetmenin adı boş olamaz.")
            .MaximumLength(50).WithMessage("Yönetmenin adı en fazla 50 karakter olabilir.");

            RuleFor(d => d.LastName)
                .NotEmpty().WithMessage("Yönetmenin soyadı boş olamaz.")
                .MaximumLength(50).WithMessage("Yönetmenin soyadı en fazla 50 karakter olabilir.");
        }
    }
}
