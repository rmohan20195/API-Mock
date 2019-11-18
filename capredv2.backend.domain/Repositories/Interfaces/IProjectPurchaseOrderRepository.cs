using capredv2.backend.domain.DatabaseEntities.Projects;
using System;
using System.Linq;

namespace capredv2.backend.domain.Repositories.Interfaces
{
    public interface IProjectPurchaseOrderRepository
    {
        IQueryable<object> GetHeaders(Guid projectId, int pageNumber, int pageSize);
        IQueryable<object> GetLineItems(Guid purchaseOrderHeaderId);

        POHeader Add(POHeader poHeader);
        POLineItem AddLineItem(POLineItem poLineItem);
    }
}
