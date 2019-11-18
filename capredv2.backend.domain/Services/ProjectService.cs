using System;
using System.Collections.Generic;
using System.Linq;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services.Interfaces;

namespace capredv2.backend.domain.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public ProjectDTO Add(ProjectDTO projectDTO)
        {
            var response = _repository.Add(Project.MapFromDomainEntity(projectDTO));

            return ProjectDTO.MapFromDatabaseEntity(response);
        }

        public GenericPagedCollection<object> GetPaged(int pageNumber, int pageSize, string facility, string region)
        {
            var count = _repository.CountForGetPaged(pageNumber, pageSize, facility, region);

            var data = _repository.GetPaged(pageNumber, pageSize, facility, region);

            return new GenericPagedCollection<object>
            {
                Count = count,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Data = data?.ToList() ?? new List<object>()
            };
        }

        public ProjectDTO Get(Guid id)
        {
            return ProjectDTO.MapFromDatabaseEntity(_repository.Get(id));
        }

        public GenericPagedCollection<object> GetTransaction(Guid projectId, int pageNumber, int pageSize)
        {
            var count = _repository.CountForGetTransaction(projectId, pageNumber, pageSize);

            var data = _repository.GetTransaction(projectId, pageNumber, pageSize);

            return new GenericPagedCollection<object>
            {
                Count = count,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Data = data?.ToList() ?? new List<object>()
            };
        }

    }
}
