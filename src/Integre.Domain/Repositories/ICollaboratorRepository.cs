using System;
using Integre.Domain.Commands.Results;
using Integre.Domain.Entities;
using System.Collections.Generic;

namespace Integre.Domain.Repositories
{
    public interface ICollaboratorRepository
    {
        Collaborator Get(Guid id);
        Collaborator GetByUsername(string username);
        IEnumerable<GetCollaboratorCommandResult> Get();
        GetCollaboratorCommandResult Get(string username);
        void Save(Collaborator collaborator);
        void Update(Collaborator collaborator);
        bool DocumentExists(string document);
    }
}
