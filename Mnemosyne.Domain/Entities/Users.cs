using System;

namespace Mnemosyne.Domain.Entities
{
    public class Users : Entity<int>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public int RoleId { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Modified { get; private set; }

        public virtual Roles Role { get; private set; }

        public Users(string firstName, string lastName, string email, int roleId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            RoleId = roleId;
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }

        public void Update(string firstName, string lastName, string email, int roleId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            RoleId = roleId;
            Modified = DateTime.Now;
        }
    }
}
