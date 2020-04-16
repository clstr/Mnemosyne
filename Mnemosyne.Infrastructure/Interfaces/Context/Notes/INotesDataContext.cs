using Mnemosyne.Domain.Entities;

namespace Mnemosyne.Infrastructure.Interfaces.Context.Notes
{
    public interface INotesDataContext : IDataContext
    {
        IRepositoryBase<Roles, int> Roles { get; }
    }
}