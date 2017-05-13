using Integre.Domain.Commands.Results;
using Integre.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Integre.Domain.Repositories
{
    public interface IRolesRepository
    {
        Roles Get(Guid id);
        Roles GetByCode(string code);
        IEnumerable<GetRolesCommandResult> Get();
        GetRolesCommandResult Get(string code);
        void Save(Roles roles);
        void Update(Roles roles);
        bool RolesExists(string codigo);
    }
}
