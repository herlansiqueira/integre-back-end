using Integre.Shared.Commands;

namespace Integre.Domain.Commands.Inputs
{
    public class RegisterRolesCommand : ICommand
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
