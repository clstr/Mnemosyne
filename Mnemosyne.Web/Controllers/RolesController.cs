using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;
using Mnemosyne.ViewModels;

namespace Mnemosyne.Web.Controllers
{
    public class RolesController : ApiControllerBase
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IRolesQueryService _rolesQueryService;

        public RolesController(IApplicationContext applicationContext,
                               IRolesQueryService rolesQueryService)
        {
            _applicationContext = applicationContext;
            _rolesQueryService = rolesQueryService;
        }

        [HttpGet]
        public IEnumerable<Roles> GetAllRoles() =>
            _applicationContext.Roles.All();

        #region CRUD Operations
        [HttpPost]
        public async Task<ActionResult<Roles>> CreateRole(RolesViewModel rolesViewModel)
        {
            var role = new Roles(rolesViewModel.Role);

            _applicationContext.Roles.Add(role);
            await _applicationContext.CommitAsync();

            return CreatedAtAction(nameof(role), role);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> ReadRole(int id)
        {
            var role = await _applicationContext.Roles.GetAsync(id);

            if (role is null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Notes>> UpdateRole(int id, RolesViewModel rolesViewModel)
        {
            if (id != rolesViewModel.Id)
            {
                return BadRequest(id);
            }

            var role = await _applicationContext.Roles.GetAsync(id);

            if (role is null)
            {
                return NotFound();
            }

            // Update our entity model
            role.Update(rolesViewModel.Role);

            // Stage our entity
            _applicationContext.Roles.Update(role);

            // Commit changes to Db
            await _applicationContext.CommitAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Roles>> DeleteRole(int id)
        {
            var role = await _applicationContext.Roles.GetAsync(id);

            if (role is null)
            {
                return NotFound();
            }

            _applicationContext.Roles.Delete(role);
            await _applicationContext.CommitAsync();

            return NoContent();
        }
        #endregion
    }
}
