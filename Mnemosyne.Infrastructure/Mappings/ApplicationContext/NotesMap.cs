using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.EF.Mappings;

namespace Mnemosyne.Infrastructure.EF.Mappings.ApplicationContext
{
    public class NotesMap : IEntityMap<Notes>
    {
        public void Configure(EntityTypeBuilder<Notes> builder)
        {
            builder.ToTable("Notes");

            builder.Property(p => p.Title)
                .HasColumnName("Title");

            builder.Property(p => p.Body)
                .HasColumnName("Body");

            builder.Property(p => p.Created)
                .HasColumnName("Created");

            builder.Property(p => p.Modified)
                .HasColumnName("Modified");


            builder.HasOne(d => d.Game)
                .WithMany()
                .HasForeignKey(p => p.GameId);

            builder.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey("ByUser");

            builder.HasOne(d => d.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
