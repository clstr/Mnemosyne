using System.Threading.Tasks;

namespace Mnemosyne.Infrastructure.Interfaces.Context
{
    public interface IDataContext
    {
        int Commit();
        Task<int> CommitAsync();
        void Dispose();
    }
}