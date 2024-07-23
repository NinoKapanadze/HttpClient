using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SQLConnector
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Configure properties
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Email).IsRequired();

            // Configure owned type (Address)
            builder.HasOne(u => u.Address)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.AddressId);


        }
    }
    public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(a => a.City).HasMaxLength(50);
            builder.Property(a => a.Region).HasMaxLength(50);


        }
    }
}
