using capredv2.backend.domain.DatabaseEntities.Projects;

namespace capredv2.backend.domain.Repositories.Interfaces
{
    public interface IProjectInvoiceHeaderRepository
    {
        InvoiceHeader Add(InvoiceHeader invoice);
    }
}
