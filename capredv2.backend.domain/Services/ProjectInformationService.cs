using System;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.Exceptions;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services.Interfaces;

namespace capredv2.backend.domain.Services
{
    public class ProjectInformationService : IProjectInformationService
    {
        private readonly IProjectInformationRepository _repository;

        public ProjectInformationService(IProjectInformationRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public object Get(Guid id)
        {
            return _repository.Get(id);
            //return ProjectInformationDTO.MapFromDatabaseEntity(_repository.Get(id));
        }

        public void Update(Guid id, ProjectInformationDTO projectInformationDTO)
        {
            if (id != projectInformationDTO.ProjectId)
                throw new BusinessValidationException("The Id informed does not match the Id in the Entity");

            _repository.Update(id, ProjectInformation.MapFromDomainEntity(projectInformationDTO));
        }
    }
}
