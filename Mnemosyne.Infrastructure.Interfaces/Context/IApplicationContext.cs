using Mnemosyne.Domain.Entities;

namespace Mnemosyne.Infrastructure.Interfaces.Context
{
    public interface IApplicationContext : IDataContext
    {
        IRepositoryBase<Users, int> Users { get; }
        IRepositoryBase<Roles, int> Roles { get; }
        IRepositoryBase<Categories, int> Categories { get; }
        IRepositoryBase<Games, int> Games { get; }
        IRepositoryBase<Notes, int> Notes { get; }
    }
}
