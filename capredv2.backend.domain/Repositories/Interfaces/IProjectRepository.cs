using System;
using System.Linq;
using capredv2.backend.domain.DatabaseEntities.Projects;

namespace capredv2.backend.domain.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Project Add(Project project);
        int CountForGetPaged(int pageNumber, int pageSize, string facility, string region);
        IQueryable<object> GetPaged(int pageNumber, int pageSize, string facility, string region);
        Project Get(Guid id);

        int CountForGetTransaction(Guid projectId, int pageNumber, int pageSize);
        IQueryable<object> GetTransaction(Guid projectId, int pageNumber, int pageSize);
    }
}
