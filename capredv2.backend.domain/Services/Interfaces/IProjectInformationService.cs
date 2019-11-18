using System;
using capredv2.backend.domain.DomainEntities.Projects;

namespace capredv2.backend.domain.Services.Interfaces
{
    public interface IProjectInformationService
    {
        object Get(Guid id);
        void Update(Guid id, ProjectInformationDTO projectInformationDTO);
    }
}
