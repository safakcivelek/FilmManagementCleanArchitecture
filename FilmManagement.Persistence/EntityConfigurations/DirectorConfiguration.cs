using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmManagement.Persistence.EntityConfigurations
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable("Directors").HasKey(d => d.Id);

            builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
            builder.Property(d => d.FirstName).HasColumnName("FirstName").HasMaxLength(50);
            builder.Property(d => d.LastName).HasColumnName("LastName").HasMaxLength(50);

            builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");
        }
    }
}
