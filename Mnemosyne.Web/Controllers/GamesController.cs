using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;

namespace Mnemosyne.Web.Controllers
{
    public class GamesController : ApiControllerBase
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IGamesQueryService _gamesQueryService;

        public GamesController(IApplicationContext applicationContext,
                                    IGamesQueryService gamesQueryService)
        {
            _applicationContext = applicationContext;
            _gamesQueryService = gamesQueryService;
        }

        [HttpGet("all")]
        public IEnumerable<Games> GetAllRoles() =>
            _applicationContext.Games.All();
    }
}
