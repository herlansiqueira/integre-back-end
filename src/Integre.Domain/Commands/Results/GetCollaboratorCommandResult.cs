using Integre.Shared.Commands;

namespace Integre.Domain.Commands.Results
{
    public class GetCollaboratorCommandResult : ICommandResult
    {
        public string Name_FirstName { get; set; }
        public string Document_Number { get; set; }
        public string Email_Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
