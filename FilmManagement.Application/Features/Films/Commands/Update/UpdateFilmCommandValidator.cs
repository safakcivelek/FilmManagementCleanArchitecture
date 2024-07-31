using FluentValidation;

namespace FilmManagement.Application.Features.Films.Commands.Update
{
    public class UpdateFilmCommandValidator : AbstractValidator<UpdateFilmCommandRequest>
    {
        public UpdateFilmCommandValidator()
        {
            RuleFor(f => f.Id)
            .NotEmpty().WithMessage("Film ID boş olamaz.");

            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("Film adı boş olamaz.")
                .MaximumLength(100).WithMessage("Film adı en fazla 100 karakter olabilir.");

            RuleFor(f => f.Year)
                .InclusiveBetween(1900, DateTime.Now.Year).WithMessage($"Film yılı {DateTime.Now.Year} ve 1900 arasında olmalıdır.");

            RuleFor(f => f.Price)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");

            RuleFor(f => f.Description)
                .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");

            RuleFor(f => f.DirectorId)
                .NotEmpty().WithMessage("Yönetmen ID boş olamaz.");
        }
    }
}
