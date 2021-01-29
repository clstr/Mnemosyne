using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;

namespace Mnemosyne.Infrastructure.EF.Services
{
    public class CategoriesQueryService : ICategoriesQueryService
    {
        public readonly IApplicationContext _applicationContext;

        public CategoriesQueryService(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<IEnumerable<Categories>> All()
        {
            return await _applicationContext.Categories
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
