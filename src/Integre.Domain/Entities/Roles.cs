using FluentValidator;
using Integre.Shared.Entities;

namespace Integre.Domain.Entities
{
    public class Roles : Entity
    {
        protected Roles() { }

        public Roles(string code, string description)
        {
            Code = code;
            Description = description;

            new ValidationContract<Roles>(this)
                .IsRequired(x => x.Code, "Código de permissão é obrigatório")
                .HasMaxLenght(x => x.Code, 10)
                .HasMinLenght(x => x.Code, 3)
                .IsRequired(x => x.Description, "Descrição da permissão é obrigatória")
                .HasMaxLenght(x => x.Code, 100)
                .HasMinLenght(x => x.Code, 3);
        }

        public string Code { get; private set; }
        public string Description { get; private set; }
    }
}
