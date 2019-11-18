using System;
using System.Linq;
using System.Threading.Tasks;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DataContexts.CapRedV2SQLContext;
using capredv2.backend.domain.Repositories.Interfaces;

namespace capredv2.backend.domain.Repositories
{
    public class ProjectRequisitionRepository : IProjectRequisitionRepository
    {
        private readonly CapRedV2Context _context;

        public ProjectRequisitionRepository(CapRedV2Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public RequisitionHeader Add(RequisitionHeader reqHeader)
        {
            return _context.RequisitionHeaders.Add(reqHeader).Entity;
        }

        public RequisitionLineItem AddLineItem(RequisitionLineItem reqLineItem)
        {
            return _context.RequisitionLineItems.Add(reqLineItem).Entity;
        }

        public IQueryable<object> GetHeaders(Guid projectId, int pageNumber, int pageSize)
        {
            return _context.RequisitionHeaders
                    .Where(p => p.ProjectId == projectId)
                    .OrderBy(o => o.RequisitionNumber)
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize).Select(r => r);
        }

        public IQueryable<object> GetLineItems(Guid requisitionHeaderId)
        {
            return _context.RequisitionLineItems
                    .Where(l => l.RequisitionHeaderId == requisitionHeaderId);
        }
    }
}
