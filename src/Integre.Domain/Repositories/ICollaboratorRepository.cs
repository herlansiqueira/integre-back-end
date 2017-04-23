using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integre.Domain.Commands.Results;
using Integre.Domain.Entities;

namespace Integre.Domain.Repositories
{
    public interface ICollaboratorRepository
    {
        Collaborator Get(Guid id);
        Collaborator GetByUsername(string username);
        GetCollaboratorCommandResult Get(string username);
        void Save(Collaborator customer);
        void Update(Collaborator customer);
        bool DocumentExists(string document);
    }
}
