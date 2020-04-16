using Microsoft.EntityFrameworkCore;

namespace Mnemosyne.Infrastructure.EntityFramework.Mappings
{
    public interface IEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {
    }
}
