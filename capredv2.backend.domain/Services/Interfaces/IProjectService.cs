using System;
using capredv2.backend.domain.DomainEntities;
using capredv2.backend.domain.DomainEntities.Projects;

namespace capredv2.backend.domain.Services.Interfaces
{
    public interface IProjectService
    {
        ProjectDTO Add(ProjectDTO projectDTO);
        GenericPagedCollection<object> GetPaged(int pageSize, int pageNumber, string facility, string region);
        ProjectDTO Get(Guid id);

        GenericPagedCollection<object> GetTransaction(Guid projectId, int pageNumber, int pageSize);
    }
}
