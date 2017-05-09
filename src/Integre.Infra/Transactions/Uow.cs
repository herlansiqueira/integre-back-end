using Integre.Infra.Contexts;

namespace Integre.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly DataContext _context;

        public Uow(DataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Do nothing :)
        }
    }
}
