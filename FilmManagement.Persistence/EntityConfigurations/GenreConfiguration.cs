using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmManagement.Persistence.EntityConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres").HasKey(g => g.Id);

            builder.Property(g => g.Id).HasColumnName("Id").IsRequired();
            builder.Property(g => g.Name).HasColumnName("Name").HasMaxLength(50);
            builder.Property(g => g.Description).HasColumnName("Description").HasMaxLength(500);

            builder.Property(g => g.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(g => g.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(g => g.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(g => !g.DeletedDate.HasValue);

            // Seed Data
            builder.HasData(GetGenreSeeds());
        }

        private IEnumerable<Genre> GetGenreSeeds()
        {
            List<Genre> genres = new()
            {
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Aksiyon",
                    Description = "Aksiyon filmleri, hızlı tempolu sahneleri ve sürekli hareket içeren maceralar sunar.",
                    CreatedDate = DateTime.UtcNow
                },
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Dram",
                    Description = "Dram filmleri, insan doğasını ve kişisel ilişkileri derinlemesine ele alır.",
                    CreatedDate = DateTime.UtcNow
                },
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Bilim Kurgu",
                    Description = "Bilim kurgu filmleri, teknolojinin ve bilimin sınırlarını zorlayan, gelecekte geçen hikayeler sunar.",
                    CreatedDate = DateTime.UtcNow
                },
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Fantastik",
                    Description = "Fantastik filmler, sihir, mitoloji ve doğaüstü olaylar içeren fantastik evrenlerde geçer.",
                    CreatedDate = DateTime.UtcNow
                }
            };

            return genres;
        }
    }
}
