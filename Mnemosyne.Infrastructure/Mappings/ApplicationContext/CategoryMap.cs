using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mnemosyne.Domain.Entities;

namespace Mnemosyne.Infrastructure.EF.Mappings.ApplicationContext
{
    public class CategoryMap : IEntityMap<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.ToTable("Categories");

            builder.Property(p => p.Category)
                .HasColumnName("Category");
        }
    }
}
