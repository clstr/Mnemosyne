using System.Collections.Generic;
using System.Threading.Tasks;
using Mnemosyne.Domain.Entities;

namespace Mnemosyne.Infrastructure.Interfaces.Services
{
    public interface IRolesQueryService
    {
        Task<IEnumerable<Roles>> AllAsync();
    }
}
