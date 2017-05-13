using Integre.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Integre.Infra.Mappings
{
    public class RolesMapping : EntityTypeConfiguration<Roles>
    {
        public RolesMapping()
        {
            ToTable("Roles");
            HasKey(x => x.Id);
            Property(x => x.Code).IsRequired().HasMaxLength(10);
            Property(x => x.Description).IsRequired().HasMaxLength(100);
        }
    }
}
