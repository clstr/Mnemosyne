using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;

namespace Mnemosyne.Infrastructure.EF.Services
{
    public class RolesQueryService : IRolesQueryService
    {
        private readonly IApplicationContext _applicationContext;

        public RolesQueryService(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<IEnumerable<Roles>> All()
        {
            return await _applicationContext.Roles
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
