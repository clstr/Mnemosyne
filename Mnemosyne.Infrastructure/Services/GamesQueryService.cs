using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;

namespace Mnemosyne.Infrastructure.EF.Services
{
    public class GamesQueryService : IGamesQueryService
    {
        public readonly IApplicationContext _applicationContext;

        public GamesQueryService(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<IEnumerable<Games>> All()
        {
            return await _applicationContext.Games
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
