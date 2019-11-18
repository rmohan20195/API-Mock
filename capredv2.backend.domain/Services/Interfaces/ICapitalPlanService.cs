using System;
using capredv2.backend.domain.DomainEntities.Projects;

namespace capredv2.backend.domain.Services.Interfaces
{
    public interface ICapitalPlanService
    {
        CapitalPlanDTO Get(Guid id);
        void Update(Guid id, CapitalPlanDTO projectInformationDTO);
    }
}
