using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;

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

        [HttpGet("all")]
        public async Task<IEnumerable<Notes>> GetAllRoles() =>
            await _notesQueryService.AllAsync();
    }
}
