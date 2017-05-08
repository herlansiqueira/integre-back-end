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
    }
}
