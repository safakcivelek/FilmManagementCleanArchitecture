using FluentValidation;

namespace FilmManagement.Application.Features.Directors.Commands.Update
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommandRequest>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Yönetmen ID boş olamaz.");

            RuleFor(d => d.FirstName)
                .NotEmpty().WithMessage("Yönetmenin adı boş olamaz.")
                .MaximumLength(50).WithMessage("Yönetmenin adı en fazla 50 karakter olabilir.");

            RuleFor(d => d.LastName)
                .NotEmpty().WithMessage("Yönetmenin soyadı boş olamaz.")
                .MaximumLength(50).WithMessage("Yönetmenin soyadı en fazla 50 karakter olabilir.");
        }
    }
}
