using Integre.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Integre.Infra.Mappings
{
    public class CollaboratorMapping : EntityTypeConfiguration<Collaborator>
    {
        public CollaboratorMapping()
        {
            ToTable("Collaborator");
            HasKey(x => x.Id);
            Property(x => x.Document.Number).IsRequired().HasMaxLength(11).IsFixedLength();
            Property(x => x.Email.Address).IsRequired().HasMaxLength(160);
            Property(x => x.Name.FirstName).IsRequired().HasMaxLength(60);
            Property(x => x.Name.LastName).IsRequired().HasMaxLength(60);
            HasRequired(x => x.User);
        }
    }
}
