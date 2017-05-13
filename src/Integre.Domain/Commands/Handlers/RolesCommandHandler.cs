using FluentValidator;
using Integre.Domain.Commands.Inputs;
using Integre.Domain.Commands.Results;
using Integre.Domain.Entities;
using Integre.Domain.Repositories;
using Integre.Shared.Commands;

namespace Integre.Domain.Commands.Handlers
{
    public class RolesCommandHandler : Notifiable,
        ICommandHandler<RegisterRolesCommand>
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesCommandHandler(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public ICommandResult Handle(RegisterRolesCommand command)
        {
            // Passo 1. Verificar se o codigo já existe
            if (_rolesRepository.RolesExists(command.Code))
            {
                AddNotification("Code", "Esta permissão já existe!");
                return null;
            }

            // Passo 2. Gerar o novo roles
            var roles = new Roles(command.Code, command.Description);

            // Passo 3. Adicionar as notificação
            AddNotifications(roles.Notifications);

            if (!IsValid())
                return null;

            // Passo 4. Inserir no banco
            _rolesRepository.Save(roles);

            return new AnyMessageCommandResult($"Permissão {command.Code} Inserida com sucesso!");
        }
    }
}
