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

            RuleFor(f => f.GenreIds)
                .Must(g => g != null && g.Any()).WithMessage("En az bir film türü seçilmelidir.")
                .ForEach(g => g.NotEmpty().WithMessage("Tür ID boş olamaz."));

            RuleFor(f => f.ActorIds)
                .Must(a => a != null && a.Any()).WithMessage("En az bir oyuncu seçilmelidir.")
                .ForEach(a => a.NotEmpty().WithMessage("Oyuncu ID boş olamaz."));
        }
    }
}
