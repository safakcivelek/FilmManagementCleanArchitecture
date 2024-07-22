using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmManagement.Persistence.EntityConfigurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("Films").HasKey(f => f.Id);

            builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
            builder.Property(f => f.Name).HasColumnName("Name").HasMaxLength(100);
            builder.Property(f => f.Price).HasColumnName("Price").HasColumnType("decimal(18,2)");
            builder.Property(f => f.Description).HasColumnName("Description").HasMaxLength(500);
            builder.Property(f => f.Year).HasColumnName("Year");

            builder.Property(f => f.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(f => f.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(f => f.DeletedDate).HasColumnName("DeletedDate");          
        }
    }
}
