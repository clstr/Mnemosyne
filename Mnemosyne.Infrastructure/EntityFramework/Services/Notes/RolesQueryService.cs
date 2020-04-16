using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context.Notes;
using Mnemosyne.Infrastructure.Interfaces.Services.Notes;

namespace Mnemosyne.Infrastructure.EntityFramework.Services.Notes
{
    public class RolesQueryService : IRolesQueryService
    {
        private readonly INotesDataContext _notesUnitOfWork;

        public RolesQueryService(INotesDataContext notesUnitOfWork)
        {
            _notesUnitOfWork = notesUnitOfWork;
        }

        public async Task<IEnumerable<Roles>> All()
        {
            return await _notesUnitOfWork.Roles.AsNoTracking().ToListAsync();
        }
    }
}