using System.Collections.Generic;
using System.Threading.Tasks;
using Mnemosyne.Domain.Entities;

namespace Mnemosyne.Infrastructure.Interfaces.Services
{
    public interface INotesQueryService
    {
        Task<IEnumerable<Notes>> AllAsync();
    }
}
