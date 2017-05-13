using Integre.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Integre.Infra.Mappings
{
    public class UserRolesMapping : EntityTypeConfiguration<UserRoles>
    {
        public UserRolesMapping()
        {
            ToTable("UserRoles");
            HasKey(x => x.Id);
            Property(x => x.RolesCode).IsRequired().HasMaxLength(10);
        }
    }
}
