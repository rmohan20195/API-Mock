using System;
using capredv2.backend.domain.DomainEntities;
using capredv2.backend.domain.DomainEntities.Projects;

namespace capredv2.backend.domain.Services.Interfaces
{
    public interface IProjectPurchaseOrderService
    {
        POHeaderDTO Add(POHeaderDTO poHeaderDTO);
        POLineItemDTO AddLineItem(POLineItemDTO poLineItemDTO);

        GenericPagedCollection<object> GetHeaders(Guid projectId, int pageSize, int pageNumber);
        GenericPagedCollection<object> GetLineItems(Guid reqHeaderId);
    }
}
