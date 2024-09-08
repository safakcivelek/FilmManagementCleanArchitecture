using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmManagement.Persistence.EntityConfigurations
{
    public class FilmGenreConfiguration : IEntityTypeConfiguration<FilmGenre>
    {
        public void Configure(EntityTypeBuilder<FilmGenre> builder)
        {
            builder.ToTable("FilmGenres").HasKey(fg => fg.Id);

            builder.Property(fg => fg.Id).HasColumnName("Id").IsRequired();

            builder.Property(fg => fg.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(fg => fg.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(fg => fg.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(fg => !fg.DeletedDate.HasValue);
        }
    }
}
