using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;
using Mnemosyne.ViewModels;

namespace Mnemosyne.Web.Controllers
{
    public class NotesController : ApiControllerBase
    {
        private readonly IApplicationContext _applicationContext;
        private readonly INotesQueryService _notesQueryService;

        public NotesController(IApplicationContext applicationContext,
                               INotesQueryService notesQueryService)
        {
            _applicationContext = applicationContext;
            _notesQueryService = notesQueryService;
        }

        [HttpGet]
        public IEnumerable<Notes> GetAllNotes() =>
            _applicationContext.Notes.All();

        #region CRUD Operations
        [HttpPost]
        public async Task<ActionResult<Notes>> CreateNote(NotesViewModel notesViewModel)
        {
            var note = new Notes(
                notesViewModel.Title,
                notesViewModel.Body,
                notesViewModel.GameId,
                notesViewModel.ByUser,
                notesViewModel.CategoryId);

            _applicationContext.Notes.Add(note);
            await _applicationContext.CommitAsync();

            return CreatedAtAction(nameof(note), note);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notes>> ReadNote(int id)
        {
            var note = await _applicationContext.Notes.GetAsync(id);

            if (note is null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Notes>> UpdateNote(int id, NotesViewModel notesViewModel)
        {
            if (id != notesViewModel.Id)
            {
                return BadRequest(id);
            }

            var note = await _applicationContext.Notes.GetAsync(id);

            if (note is null)
            {
                return NotFound();
            }

            // Update our entity model
            note.Update(notesViewModel.Title,
                notesViewModel.Body,
                notesViewModel.GameId,
                notesViewModel.ByUser,
                notesViewModel.CategoryId);

            // Stage our entity
            _applicationContext.Notes.Update(note);

            // Commit changes to Db
            await _applicationContext.CommitAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Notes>> DeleteNote(int id)
        {
            var note = await _applicationContext.Notes.GetAsync(id);

            if (note is null)
            {
                return NotFound();
            }

            _applicationContext.Notes.Delete(note);
            await _applicationContext.CommitAsync();

            return NoContent();
        }
        #endregion
    }
}
