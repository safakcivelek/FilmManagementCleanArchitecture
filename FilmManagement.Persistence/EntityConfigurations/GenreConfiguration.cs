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
        }
    }
}
