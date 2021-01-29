using Microsoft.EntityFrameworkCore;

namespace Mnemosyne.Infrastructure.EF.Mappings
{
    public interface IEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {
    }
}
