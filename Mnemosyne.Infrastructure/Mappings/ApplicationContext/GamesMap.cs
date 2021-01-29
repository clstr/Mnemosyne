using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mnemosyne.Domain.Entities;

namespace Mnemosyne.Infrastructure.EF.Mappings.ApplicationContext
{
    public class GamesMap : IEntityMap<Games>
    {
        public void Configure(EntityTypeBuilder<Games> builder)
        {
            builder.ToTable("Games");

            builder.Property(p => p.Name)
                .HasColumnName("Name");
        }
    }
}
