﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Mnemosyne.Domain.Entities;

namespace Mnemosyne.Infrastructure.Interfaces.Services
{
    public interface ICategoriesQueryService
    {
        Task<IEnumerable<Categories>> AllAsync();
    }
}
