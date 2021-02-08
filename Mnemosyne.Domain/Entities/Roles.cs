namespace Mnemosyne.Domain.Entities
{
    public class Roles : Entity<int>
    {
        public string Role { get; private set; }

        public Roles(string role)
        {
            Role = role;
        }

        public void Update(string role)
        {
            Role = role;
        }
    }
}
