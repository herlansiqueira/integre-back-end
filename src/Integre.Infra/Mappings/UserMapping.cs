using Integre.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Integre.Infra.Mappings
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("User");
            HasKey(x => x.Id);
            Property(x => x.Username).IsRequired().HasMaxLength(20);
            Property(x => x.Password).IsRequired().HasMaxLength(32).IsFixedLength();
            Property(x => x.Active);
        }
    }
}
