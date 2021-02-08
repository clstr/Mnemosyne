namespace Mnemosyne.Domain.Entities
{
    public class Categories : Entity<int>
    {
        public string Category { get; private set; }

        public Categories(string category)
        {
            Category = category;
        }

        public void Update(string category)
        {
            Category = category;
        }
    }
}
