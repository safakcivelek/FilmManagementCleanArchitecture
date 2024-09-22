using FluentValidation;

namespace FilmManagement.Application.Features.Films.Commands.Create
{
    public class CreateFilmCommandValidator : AbstractValidator<CreateFilmCommandRequest>
    {
        public CreateFilmCommandValidator()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("Film adı boş olamaz.")
                .MaximumLength(100).WithMessage("Film adı en fazla 100 karakter olabilir.");

            RuleFor(f => f.Year)
                .NotEmpty().InclusiveBetween(1900, DateTime.Now.Year).WithMessage($"Film yılı {DateTime.Now.Year} ve 1900 arasında olmalıdır.");

            RuleFor(f => f.Price)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");

            RuleFor(f => f.DirectorId)
                .NotEmpty().WithMessage("Yönetmen ID boş olamaz.");

            RuleFor(f => f.GenreIds)
                .Must(g => g != null && g.Any()).WithMessage("En az bir film türü seçilmelidir.") // Null olamaz!
                .ForEach(g => g.NotEmpty().WithMessage("Tür ID boş olamaz.")); // örneğin, boş bir string ("") veya sıfır değeri gibi olamaz!

            RuleFor(x => x.ActorIds)
                .Must(a => a != null && a.Any()).WithMessage("En az bir oyuncu seçilmelidir.")
                .ForEach(a => a.NotEmpty().WithMessage("Oyuncu ID boş olamaz."));

            RuleFor(f => f.Duration)
            .NotEmpty().GreaterThan(0).WithMessage("Süre 0'dan büyük olmalıdır.")
            .LessThanOrEqualTo(600).WithMessage("Süre en fazla 600 dakika olabilir.");

            RuleFor(f => f.Image)
                .Must(i => string.IsNullOrEmpty(i) || Uri.IsWellFormedUriString(i, UriKind.Absolute))
                .WithMessage("Geçerli bir URL formatı sağlanmalıdır."); // Zorunlu değil ama varsa geçerli URL olmalı

            RuleFor(f => f.Video)
                .Must(v => string.IsNullOrEmpty(v) || Uri.IsWellFormedUriString(v, UriKind.Absolute))
                .WithMessage("Geçerli bir URL formatı sağlanmalıdır.");
        }
    }
}
