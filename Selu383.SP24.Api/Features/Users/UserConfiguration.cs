using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Selu383.SP24.Api.Features.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Username).HasMaxLength(50).IsRequired();
        }
    }
}
