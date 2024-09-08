using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmManagement.Persistence.EntityConfigurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.ToTable("Actors").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.FirstName).HasColumnName("FirstName").HasMaxLength(50);
            builder.Property(a => a.LastName).HasColumnName("LastName").HasMaxLength(50);
            builder.Property(a => a.Description).HasColumnName("Description").HasMaxLength(500);

            builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
