using Integre.Shared.Commands;

namespace Integre.Domain.Commands.Inputs
{
    public class AuthenticateUserCommand : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
