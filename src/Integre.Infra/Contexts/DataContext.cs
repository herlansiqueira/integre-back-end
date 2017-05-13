using Integre.Domain.Entities;
using Integre.Infra.Mappings;
using Integre.Shared;
using System.Data.Entity;

namespace Integre.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(Runtime.ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Collaborator> collaborators { get; set; }
        public DbSet<Roles> roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CollaboratorMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new RolesMapping());
        }
    }
}
