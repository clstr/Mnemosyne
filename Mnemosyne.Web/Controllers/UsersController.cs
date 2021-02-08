using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;
using Mnemosyne.ViewModels;

namespace Mnemosyne.Web.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IUsersQueryService _usersQueryService;

        public UsersController(IApplicationContext applicationContext,
                               IUsersQueryService usersQueryService)
        {
            _applicationContext = applicationContext;
            _usersQueryService = usersQueryService;
        }

        [HttpGet]
        public IEnumerable<Users> GetAllUsers() =>
            _applicationContext.Users.All();

        #region CRUD Operations
        [HttpPost]
        public async Task<ActionResult<Users>> CreateUser(UsersViewModel usersViewModel)
        {
            var user = new Users(
                usersViewModel.FirstName,
                usersViewModel.LastName,
                usersViewModel.Email,
                usersViewModel.RoleId);

            _applicationContext.Users.Add(user);
            await _applicationContext.CommitAsync();

            return CreatedAtAction(nameof(user), user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> ReadUser(int id)
        {
            var user = await _applicationContext.Users.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Users>> UpdateUser(int id, UsersViewModel usersViewModel)
        {
            if (id != usersViewModel.Id)
            {
                return BadRequest(id);
            }

            var user = await _applicationContext.Users.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            // Update our entity model
            user.Update(
                usersViewModel.FirstName,
                usersViewModel.LastName,
                usersViewModel.Email,
                usersViewModel.RoleId);

            // Stage our entity
            _applicationContext.Users.Update(user);

            // Commit changes to Db
            await _applicationContext.CommitAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUser(int id)
        {
            var user = await _applicationContext.Users.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            _applicationContext.Users.Delete(user);
            await _applicationContext.CommitAsync();

            return NoContent();
        }
        #endregion
    }
}
