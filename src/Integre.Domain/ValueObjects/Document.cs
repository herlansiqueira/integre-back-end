using FluentValidator;

namespace Integre.Domain.ValueObjects
{
    public class Document : Notifiable
    {
        protected Document() { }

        public Document(string number)
        {
            Number = number;

            new ValidationContract<Document>(this)
                .IsRequired(x => x.Number, "Mátricula é obrigatória");
        }

        public string Number { get; private set; }
    }
}
