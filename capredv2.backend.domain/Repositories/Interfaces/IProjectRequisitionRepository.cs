using capredv2.backend.domain.DatabaseEntities.Projects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace capredv2.backend.domain.Repositories.Interfaces
{
    public interface IProjectRequisitionRepository
    {
        IQueryable<object> GetHeaders(Guid projectId, int pageNumber, int pageSize);
        IQueryable<object> GetLineItems(Guid requisitionHeaderId);

        RequisitionHeader Add(RequisitionHeader reqHeader);
        RequisitionLineItem AddLineItem(RequisitionLineItem reqLineItem);
    }
}
