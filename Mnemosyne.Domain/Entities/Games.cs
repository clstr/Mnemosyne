namespace Mnemosyne.Domain.Entities
{
    public class Games : Entity<int>
    {
        public string Name { get; private set; }
        
        public Games(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
