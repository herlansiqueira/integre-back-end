using FluentValidator;
using Integre.Domain.Commands.Inputs;
using Integre.Domain.Commands.Results;
using Integre.Domain.Entities;
using Integre.Domain.Repositories;
using Integre.Domain.Resources;
using Integre.Domain.Services;
using Integre.Domain.ValueObjects;
using Integre.Shared.Commands;

namespace Integre.Domain.Commands.Handlers
{
    public class CollaboratorCommandHandler : Notifiable,
        ICommandHandler<RegisterCollaboratorCommand>
    {

        private readonly ICollaboratorRepository _collaboratorRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly IEmailService _emailService;

        public CollaboratorCommandHandler(ICollaboratorRepository collaboratorRepository,
            IEmailService emailService, IRolesRepository rolesRepository)
        {
            _collaboratorRepository = collaboratorRepository;
            _rolesRepository = rolesRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(RegisterCollaboratorCommand command)
        {
            // Passo 1. Verificar se o CPF já existe
            if (_collaboratorRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso!");
                return null;
            }

            // Passo 2. Gerar o novo colaborador
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var user = new User(command.Username, command.Password, command.ConfirmPassword);
            var customer = new Collaborator(name, email, document, user);

            // Passo 3. Adicionar as notificação
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);

            // Adiciona roles do usuário
            foreach (var item in command.UserRoles)
            {
                var roles = _rolesRepository.Get(item.RolesCode);
                user.AddRoles(new UserRoles(roles.Code));
            }

            if (!IsValid())
                return null;

            // Passo 4. Inserir no banco
            _collaboratorRepository.Save(customer);

            // Passo 5. Enviar E-mail de boas vindas     
            _emailService.Send(
                customer.Name.ToString(),
                customer.Email.Address,
                string.Format(EmailTemplates.WelcomeEmailTitle, customer.Name),
                string.Format(EmailTemplates.WelcomeEmailBody, customer.Name));

            // Passo 6. Retornar algo
            return new RegisterCollaboratorCommandResult(customer.Id, customer.Name.ToString());
        }
    }
}
