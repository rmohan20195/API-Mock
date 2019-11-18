using System;
using System.Linq;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DataContexts.CapRedV2SQLContext;
using capredv2.backend.domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace capredv2.backend.domain.Repositories
{
    public class CapitalPlanRepository : ICapitalPlanRepository
    {
        private readonly CapRedV2Context _context;

        public CapitalPlanRepository(CapRedV2Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public CapitalPlan Get(Guid id)
        {
            return _context.CapitalPlans.FirstOrDefault(i => i.ProjectId == id);
        }

        public void Update(Guid id, CapitalPlan capitalPlan)
        {
            var entityInContext = _context.CapitalPlans.FirstOrDefault(c => c.ProjectId == id);

            if (entityInContext == null)
                return;

            _context.Entry(entityInContext).CurrentValues.SetValues(capitalPlan);
            _context.Entry(entityInContext).State = EntityState.Modified;
        }
    }
}
