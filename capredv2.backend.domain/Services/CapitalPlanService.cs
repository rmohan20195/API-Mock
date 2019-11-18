using System;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.Exceptions;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services.Interfaces;

namespace capredv2.backend.domain.Services
{
    public class CapitalPlanService : ICapitalPlanService
    {
        private readonly ICapitalPlanRepository _repository;

        public CapitalPlanService(ICapitalPlanRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public CapitalPlanDTO Get(Guid id)
        {
            return CapitalPlanDTO.MapFromDatabaseEntity(_repository.Get(id));
        }

        public void Update(Guid id, CapitalPlanDTO capitalPlanDTO)
        {
            if(id != capitalPlanDTO.ProjectId)
                throw new BusinessValidationException("The Id informed does not match the Id in the Entity");

            _repository.Update(id, CapitalPlan.MapFromDomainEntity(capitalPlanDTO));
        }
    }
}
