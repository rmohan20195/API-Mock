using System;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DataContexts.CapRedV2SQLContext;
using capredv2.backend.domain.Repositories.Interfaces;

namespace capredv2.backend.domain.Repositories
{
    public class ProjectInvoiceLineItemRepository : IProjectInvoiceLineItemRepository
    {
        private readonly CapRedV2Context _context;

        public ProjectInvoiceLineItemRepository(CapRedV2Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public InvoiceLineItem Add(InvoiceLineItem invoiceLineItem)
        {
            return _context.InvoiceLineItems.Add(invoiceLineItem).Entity;
        }
    }
}
