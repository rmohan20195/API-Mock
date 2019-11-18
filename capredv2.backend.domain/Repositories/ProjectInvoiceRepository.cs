using System;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DataContexts.CapRedV2SQLContext;
using capredv2.backend.domain.Repositories.Interfaces;

namespace capredv2.backend.domain.Repositories
{
    public class ProjectInvoiceRepository : IProjectInvoiceRepository
    {
        private readonly CapRedV2Context _context;

        public ProjectInvoiceRepository(CapRedV2Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public InvoiceHeader Add(InvoiceHeader invoiceHeader)
        {
            return _context.InvoiceHeaders.Add(invoiceHeader).Entity;
        }
    }
}
