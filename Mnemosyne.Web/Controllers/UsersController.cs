using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;

namespace Mnemosyne.Web.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IUsersQueryService _usersQueryService;

        public UsersController(IApplicationContext applicationContext, IUsersQueryService usersQueryService)
        {
            _applicationContext = applicationContext;
            _usersQueryService = usersQueryService;
        }

        [HttpGet("all")]
        public IEnumerable<Users> GetAllUsers() =>
          _applicationContext.Users.All();
    }
}
