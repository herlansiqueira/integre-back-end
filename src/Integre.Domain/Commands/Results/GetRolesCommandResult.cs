using Integre.Shared.Commands;

namespace Integre.Domain.Commands.Results
{
    public class GetRolesCommandResult : ICommandResult
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
