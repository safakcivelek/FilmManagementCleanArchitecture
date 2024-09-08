using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmManagement.Persistence.EntityConfigurations
{
    public class FilmActorConfiguration : IEntityTypeConfiguration<FilmActor>
    {
        public void Configure(EntityTypeBuilder<FilmActor> builder)
        {
            builder.ToTable("FilmActors").HasKey(fa => fa.Id);

            builder.Property(fa => fa.Id).HasColumnName("Id").IsRequired();

            builder.Property(fa => fa.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(fa => fa.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(fa => fa.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(fa => !fa.DeletedDate.HasValue);
        }
    }
}
