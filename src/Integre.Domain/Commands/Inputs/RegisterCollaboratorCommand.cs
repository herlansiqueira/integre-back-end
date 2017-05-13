using Integre.Shared.Commands;
using System.Collections.Generic;

namespace Integre.Domain.Commands.Inputs
{
    public class RegisterCollaboratorCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public IEnumerable<RegisterUserRolesCommand> UserRoles { get; set; }
    }
}
