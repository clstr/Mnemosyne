using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;
using Mnemosyne.ViewModels;

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

        [HttpGet]
        public IEnumerable<Games> GetAllGames() =>
            _applicationContext.Games.All();

        #region CRUD Operations
        [HttpPost]
        public async Task<ActionResult<Games>> CreateGame(GamesViewModel gamesViewModel)
        {
            var game = new Games(gamesViewModel.Name);
            _applicationContext.Games.Add(game);
            await _applicationContext.CommitAsync();

            return CreatedAtAction(nameof(game), game);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Games>> ReadGame(int id)
        {
            var game = await _applicationContext.Games.GetAsync(id);

            if (game is null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Games>> UpdateGame(int id, GamesViewModel gamesViewModel)
        {
            if (id != gamesViewModel.Id)
            {
                return BadRequest(id);
            }

            var game = await _applicationContext.Games.GetAsync(id);

            if (game is null)
            {
                return NotFound();
            }

            // Update our entity model
            game.Update(gamesViewModel.Name);

            // Stage our entity
            _applicationContext.Games.Update(game);

            // Commit changes to Db
            await _applicationContext.CommitAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Games>> DeleteGame(int id)
        {
            var game = await _applicationContext.Games.GetAsync(id);

            if (game is null)
            {
                return NotFound();
            }

            _applicationContext.Games.Delete(game);
            await _applicationContext.CommitAsync();

            return NoContent();
        }
        #endregion
    }
}
