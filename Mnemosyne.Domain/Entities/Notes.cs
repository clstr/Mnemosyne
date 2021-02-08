using System;

namespace Mnemosyne.Domain.Entities
{
    public class Notes : Entity<int>
    {
        public string Title { get; private set; }
        public string Body { get; private set; }
        public int GameId { get; private set; }
        public int ByUser { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Modified { get; private set; }

        public virtual Games Game { get; private set; }
        public virtual Categories Category { get; private set; }
        public virtual Users User { get; private set; }

        public Notes(string title, string body, int gameId, int byUser, int categoryId)
        {
            Title = title;
            Body = body;
            GameId = gameId;
            ByUser = byUser;
            CategoryId = categoryId;
            Created = DateTime.Now;
        }

        public void Update(string title, string body, int gameId, int byUser, int categoryId)
        {
            Title = title;
            Body = body;
            GameId = gameId;
            ByUser = byUser;
            CategoryId = categoryId;
            Modified = DateTime.Now;
        }
    }
}
