using Integre.Shared.Commands;

namespace Integre.Domain.Commands.Results
{
    public class AnyMessageCommandResult : ICommandResult
    {
        public AnyMessageCommandResult() { }

        public AnyMessageCommandResult(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
