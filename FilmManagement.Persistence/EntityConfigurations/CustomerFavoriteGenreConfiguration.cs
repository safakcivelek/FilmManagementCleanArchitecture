using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmManagement.Persistence.EntityConfigurations
{
    public class CustomerFavoriteGenreConfiguration : IEntityTypeConfiguration<CustomerFavoriteGenre>
    {
        public void Configure(EntityTypeBuilder<CustomerFavoriteGenre> builder)
        {
            builder.ToTable("CustomerFavoriteGenre").HasKey(cfg => cfg.Id);

            builder.Property(cfg => cfg.Id).HasColumnName("Id").IsRequired();

            builder.Property(cfg => cfg.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(cfg => cfg.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(cfg => cfg.DeletedDate).HasColumnName("DeletedDate");
        }
    }
}
