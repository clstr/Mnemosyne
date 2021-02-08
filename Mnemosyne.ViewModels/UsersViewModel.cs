using System;

namespace Mnemosyne.ViewModels
{
    public record UsersViewModel
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public int RoleId { get; init; }
        public DateTime Created { get; init; }
        public DateTime Modified { get; init; }
    }
}
