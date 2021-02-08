using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;

namespace Mnemosyne.Infrastructure.EF.Services
{
    public class UsersQueryService : IUsersQueryService
    {
        private readonly IApplicationContext _applicationContext;

        public UsersQueryService(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<IEnumerable<Users>> AllAsync()
        {
            return await _applicationContext.Users
                .AsNoTracking()
                .Include(p=>p.Role)
                .ToListAsync();
        }
    }
}
