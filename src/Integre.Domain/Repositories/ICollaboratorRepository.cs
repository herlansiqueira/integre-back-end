using System;
using Integre.Domain.Commands.Results;
using Integre.Domain.Entities;

namespace Integre.Domain.Repositories
{
    public interface ICollaboratorRepository
    {
        Collaborator Get(Guid id);
        Collaborator GetByUsername(string username);
        GetCollaboratorCommandResult Get(string username);
        void Save(Collaborator collaborator);
        void Update(Collaborator collaborator);
        bool DocumentExists(string document);
    }
}
