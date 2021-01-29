using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.EF.Mappings;

namespace Mnemosyne.Infrastructure.EF.Mappings.ApplicationContext
{
    public class UsersMap : IEntityMap<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");

            builder.Property(p => p.FirstName)
                .HasColumnName("Firstname");

            builder.Property(p => p.LastName)
                .HasColumnName("Lastname");

            builder.Property(p => p.Email)
                .HasColumnName("Email");

            builder.Property(p => p.Created)
                .HasColumnName("Created");

            builder.Property(p => p.Modified)
                .HasColumnName("Modified");

            builder.HasOne(d => d.Role)
                .WithMany()
                .HasForeignKey(p => p.RoleId);
        }
    }
}
