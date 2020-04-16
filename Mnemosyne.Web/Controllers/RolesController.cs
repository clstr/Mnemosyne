using Microsoft.AspNetCore.Mvc;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Services.Notes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mnemosyne.Web.Controllers
{
    public class RolesController : ApiControllerBase
    {
        private readonly IRolesQueryService _rolesUnitOfWork;

        public RolesController(IRolesQueryService rolesUnitOfWork)
        {
            _rolesUnitOfWork = rolesUnitOfWork;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<Roles>> GetAllRoles()
        {
            return await _rolesUnitOfWork.All();
        }
    }
}