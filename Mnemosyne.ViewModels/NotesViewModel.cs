using System;

namespace Mnemosyne.ViewModels
{
    public record NotesViewModel
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Body { get; init; }
        public int GameId { get; init; }
        public int ByUser { get; init; }
        public int CategoryId { get; init; }
        public DateTime Created { get; init; }
        public DateTime Modified { get; init; }
    }
}
