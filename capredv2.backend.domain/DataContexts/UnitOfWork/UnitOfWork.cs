using System;
using System.Threading.Tasks;
using capredv2.backend.domain.DataContexts.CapRedV2SQLContext;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;

namespace capredv2.backend.domain.DataContexts.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CapRedV2Context _context;

        public UnitOfWork(CapRedV2Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void AutoDetectChanges(bool value)
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = value;
        }
    }
}
