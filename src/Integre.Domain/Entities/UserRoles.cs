using FluentValidator;
using Integre.Shared.Entities;

namespace Integre.Domain.Entities
{
    public class UserRoles : Entity
    {
        public UserRoles() { }

        public UserRoles(string rolesCode)
        {
            RolesCode = rolesCode;

            new ValidationContract<UserRoles>(this)
                .IsRequired(x => x.RolesCode, "Código de permissão é obrigatória");
        }
        public string RolesCode { get; private set; }
    }
}
