using Integre.Domain.Entities;
using System.Data.Entity;

namespace Integre.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("connection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Collaborator> collaborators { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
