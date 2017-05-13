using Integre.Domain.Commands.Inputs;
using Integre.Shared.Commands;
using System.Collections.Generic;

namespace Integre.Domain.Commands.Results
{
    public class GetCollaboratorCommandResult : ICommandResult
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public IEnumerable<RegisterUserRolesCommand> Roles { get; set; }
    }
}
