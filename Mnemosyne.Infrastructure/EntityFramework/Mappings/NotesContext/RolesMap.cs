using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mnemosyne.Domain.Entities;

namespace Mnemosyne.Infrastructure.EntityFramework.Mappings.NotesContext
{
    public class RolesMap : IEntityMap<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("Roles");

            builder.Property(x => x.Role)
                .HasColumnName("Role");
        }
    }
}