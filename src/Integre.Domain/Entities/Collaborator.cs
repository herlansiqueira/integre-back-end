using System;
using Integre.Domain.ValueObjects;
using Integre.Shared.Entities;

namespace Integre.Domain.Entities
{
    public class Collaborator : Entity
    {
        protected Collaborator() { }

        public Collaborator(Name name, Email email, Document document, User user)
        {
            Name = name;
            Email = email;
            Document = document;
            User = user;

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(Document.Notifications);
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public User User { get; private set; }

        public void Update(Name name, DateTime birthDate)
        {
            AddNotifications(name.Notifications);

            Name = name;
        }
    }
}
