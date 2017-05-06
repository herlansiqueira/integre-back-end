using Integre.Shared.Commands;
using System;

namespace Integre.Domain.Commands.Results
{
    public class RegisterCollaboratorCommandResult : ICommandResult
    {
        public RegisterCollaboratorCommandResult()
        {

        }
        public RegisterCollaboratorCommandResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
