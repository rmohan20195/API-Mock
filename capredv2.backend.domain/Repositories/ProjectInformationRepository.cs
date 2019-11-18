using System;
using System.Linq;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DataContexts.CapRedV2SQLContext;
using capredv2.backend.domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace capredv2.backend.domain.Repositories
{
    public class ProjectInformationRepository : IProjectInformationRepository
    {
        private readonly CapRedV2Context _context;

        public ProjectInformationRepository(CapRedV2Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public object Get(Guid id)
        {
            return _context.ProjectsInformation
                        .Where(i => i.ProjectId == id)
                        .Select(p => new
                        {
                            p.ProjectId,
                            p.ProjectName,
                            p.FacilityType,
                            FacilityTypeValue = _context.FacilityTypes.Where(r => r.Id.ToString() == p.FacilityType).FirstOrDefault().Value,
                            p.LeasedOrOwned,
                            p.Region,
                            RegionValue = _context.Regions.Where(r => r.Id.ToString() == p.Region).FirstOrDefault().Value,
                            p.ApprovedBudget,
                            p.ProjectStatus,
                            p.LastUpdated,
                            p.ProjectType,
                            ProjectTypeValue = _context.ProjectTypes.Where(pt => pt.Id.ToString() == p.ProjectType).FirstOrDefault().Value,
                            p.Location,
                            p.ProjectOwner,
                            p.ProjectSponsor
                        }).FirstOrDefault(); 
        }

        public void Update(Guid id, ProjectInformation projectInformation)
        {
            var entityInContext = _context.ProjectsInformation.FirstOrDefault(c => c.ProjectId == id);

            if (entityInContext == null)
                return;

            _context.Entry(entityInContext).CurrentValues.SetValues(projectInformation);
            _context.Entry(entityInContext).State = EntityState.Modified;
        }
    }
}
