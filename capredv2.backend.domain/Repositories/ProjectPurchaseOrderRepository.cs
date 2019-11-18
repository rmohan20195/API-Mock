using System;
using System.Linq;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DataContexts.CapRedV2SQLContext;
using capredv2.backend.domain.Repositories.Interfaces;

namespace capredv2.backend.domain.Repositories
{
    public class ProjectPurchaseOrderRepository : IProjectPurchaseOrderRepository
    {
        private readonly CapRedV2Context _context;

        public ProjectPurchaseOrderRepository(CapRedV2Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public POHeader Add(POHeader poHeader)
        {
            return _context.PurchaseOrderHeaders.Add(poHeader).Entity;
        }

        public POLineItem AddLineItem(POLineItem poLineItem)
        {
            return _context.PurchaseOrderLineItems.Add(poLineItem).Entity;
        }

        public IQueryable<object> GetHeaders(Guid projectId, int pageNumber, int pageSize)
        {
            return _context.PurchaseOrderHeaders
                     .Where(p => p.ProjectId  == projectId)
                     .OrderBy(o => o.PurchaseOrderNumber)
                     .Skip(pageSize * (pageNumber - 1))
                     .Take(pageSize)
                     .Select(po => po);
        }

        public IQueryable<object> GetLineItems(Guid purchaseOrderHeaderId)
        {
            return _context.PurchaseOrderLineItems
                    .Where(l => l.POHeaderId == purchaseOrderHeaderId)
                    .Select(po => po);
        }
    }
}
