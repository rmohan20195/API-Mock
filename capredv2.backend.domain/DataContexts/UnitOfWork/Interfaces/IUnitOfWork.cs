using System.Threading.Tasks;

namespace capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
        void AutoDetectChanges(bool value);
    }
}
