using AnchorSystem.EntityFrameworkCore.AnchorSystemAuthDb;

namespace AnchorSystem.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly AnchorSystemAuthDbContext _context;

        public InitialHostDbBuilder(AnchorSystemAuthDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new HostRoleAndUserCreator(_context).Create();
            _context.SaveChanges();
        }
    }
}
