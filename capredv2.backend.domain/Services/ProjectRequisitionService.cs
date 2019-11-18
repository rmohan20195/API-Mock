using System;
using System.Collections.Generic;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.Exceptions;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services.Interfaces;

namespace capredv2.backend.domain.Services
{
    public class ProjectRequisitionService : IProjectRequisitionService
    {
        private readonly IProjectRequisitionRepository _projectRequisitionRepository;

        public ProjectRequisitionService(IProjectRequisitionRepository projectRequisitionRepository)
        {
            _projectRequisitionRepository = projectRequisitionRepository ?? throw new ArgumentNullException(nameof(projectRequisitionRepository));
        }

        public RequisitionHeaderDTO Add(RequisitionHeaderDTO reqHeaderDTO)
        {
            var response = _projectRequisitionRepository.Add(RequisitionHeader.MapFromDomainEntity(reqHeaderDTO));

            return RequisitionHeaderDTO.MapFromDatabaseEntity(response);
        }

        public RequisitionLineItemDTO AddLineItem(RequisitionLineItemDTO reqLineItemDTO)
        {
            var response = _projectRequisitionRepository.AddLineItem(RequisitionLineItem.MapFromDomainEntity(reqLineItemDTO));

            return RequisitionLineItemDTO.MapFromDatabaseEntity(response);
        }

        public GenericPagedCollection<object> GetHeaders(Guid projectId, int pageNumber, int pageSize)
        {
            var data = _projectRequisitionRepository.GetHeaders(projectId, pageNumber, pageSize);

            return new GenericPagedCollection<object>
            {
                Count = 0,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Data = data 
            };
        }

        public GenericPagedCollection<object> GetLineItems(Guid reqHeaderId)
        {
            var data = _projectRequisitionRepository.GetLineItems(reqHeaderId);

            return new GenericPagedCollection<object>
            {
                Count = 0,
                CurrentPage = 0,
                PageSize = 0,
                Data = data
            };
        }
    }
}
