using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;

namespace Mnemosyne.Infrastructure.EF.Services
{
    public class NotesQueryService : INotesQueryService
    {
        public readonly IApplicationContext _applicationContext;

        public NotesQueryService(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<IEnumerable<Notes>> AllAsync()
        {
            return await _applicationContext.Notes
                .AsNoTracking()
                .Include(x => x.Category)
                .Include(x => x.User)
                .Include(x => x.Game)
                .ToListAsync();
        }
    }
}
