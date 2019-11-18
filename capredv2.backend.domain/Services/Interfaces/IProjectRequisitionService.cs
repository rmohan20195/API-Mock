using System;
using capredv2.backend.domain.DomainEntities;
using capredv2.backend.domain.DomainEntities.Projects;

namespace capredv2.backend.domain.Services.Interfaces
{
    public interface IProjectRequisitionService
    {
        RequisitionHeaderDTO Add(RequisitionHeaderDTO reqHeaderDTO);
        RequisitionLineItemDTO AddLineItem(RequisitionLineItemDTO reqLineItemDTO);

        GenericPagedCollection<object> GetHeaders(Guid projectId, int pageSize, int pageNumber);
        GenericPagedCollection<object> GetLineItems(Guid reqHeaderId);
    }
}
