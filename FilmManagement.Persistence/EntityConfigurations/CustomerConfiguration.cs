using FilmManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmManagement.Persistence.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers").HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.FirstName).HasColumnName("FirstName").HasMaxLength(50);
            builder.Property(c => c.LastName).HasColumnName("LastName").HasMaxLength(50);
            builder.Property(c => c.Email).HasColumnName("Email");

            builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");
        }
    }
}
