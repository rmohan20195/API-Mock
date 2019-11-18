using System;
using System.Collections.Generic;
using System.Linq;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DataContexts.CapRedV2SQLContext;
using capredv2.backend.domain.ExtensionMethods;
using capredv2.backend.domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace capredv2.backend.domain.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly CapRedV2Context _context;

        public ProjectRepository(CapRedV2Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Project Add(Project project)
        {
            //TODO: Add TimeStamp for Last Updated and Created DateTime
            return _context.Projects.Add(project).Entity;
        }

        public int CountForGetPaged(int pageNumber, int pageSize, string facility, string region)
        {
            var projects = _context.Projects.AsQueryable();

            if (!string.IsNullOrEmpty(facility))
                projects = _context.Projects.Where(p => p.ProjectInformation.FacilityType.Contains(facility));

            if (!string.IsNullOrEmpty(region))
                projects = _context.Projects.Where(p => p.ProjectInformation.Region.Contains(region));

            return projects.Count();
        }

        public IQueryable<object> GetPaged(int pageNumber, int pageSize, string facility, string region)
        {
            var projectList = _context.Projects
               .OrderBy(o => o.ProjectInformation.ProjectName).
                Select(p => new
                {
                    p.Id,
                    p.ProjectInformation.ProjectName,
                    FacilityType = _context.FacilityTypes.Where(r => r.Id.ToString() == p.ProjectInformation.FacilityType).FirstOrDefault().Value,
                    p.ProjectInformation.LeasedOrOwned,
                    Region = _context.Regions.Where(r => r.Id.ToString() == p.ProjectInformation.Region).FirstOrDefault().Value,
                    p.ProjectInformation.ApprovedBudget,
                    p.ProjectInformation.ProjectStatus,
                    p.ProjectInformation.LastUpdated,
                    ProjectType = _context.ProjectTypes.Where(pt => pt.Id.ToString() == p.ProjectInformation.ProjectType).FirstOrDefault().Value
                });

            if (!string.IsNullOrEmpty(facility))
            {
                projectList = projectList.Where(x => x.FacilityType.Contains(facility));
            }

            if (!string.IsNullOrEmpty(region))
            {
                projectList = projectList.Where(x => x.Region.Contains(region));
            }

            return projectList
                        .Skip(pageSize * (pageNumber - 1))
                        .Take(pageSize);
        }

        public Project Get(Guid id)
        {
            return _context.Projects
                .Include(i => i.ProjectInformation)
                .Include(i => i.CapitalPlan)
                .Include(i => i.InvoiceHeaders)
                .Include(i => i.POHeaders)
                .Include(i => i.RequisitionHeaders)
                .FirstOrDefault(p => p.Id == id);
        }


        public int CountForGetTransaction(Guid projectId, int pageNumber, int pageSize)
        {
            return GetTransactions(projectId, pageNumber, pageSize).Count();
        }

        public IQueryable<object> GetTransaction(Guid projectId, int pageNumber, int pageSize)
        {
            return GetTransactions(projectId, pageNumber, pageSize)
                            .Skip(pageSize * (pageNumber - 1))
                            .Take(pageSize); 

        }

        // Common Private Method to access the transaction list
        private IQueryable<object> GetTransactions(Guid projectId, int pageNumber, int pageSize)
        {
            var reqHeaders = (from reqs in _context.RequisitionHeaders
                              join pos in _context.PurchaseOrderHeaders on reqs.PurchaseOrderNumber.ToString() equals pos.PurchaseOrderNumber into list
                              from newPOs in list.DefaultIfEmpty()
                              select new
                              {
                                  Id = reqs.ProjectId,
                                  RequisitionId = reqs.Id.ToString(),
                                  POHeaderId = newPOs == null ? "-" : newPOs.Id.ToString(),
                                  RequisitionNumber = reqs.RequisitionNumber.ToString(),
                                  PurchaseOrderNumber = string.IsNullOrEmpty(newPOs.PurchaseOrderNumber) ? "-": newPOs.PurchaseOrderNumber,
                                  Status = reqs.Status,
                                  OrderDate = newPOs.OrderDate,
                                  Supplier = reqs.Supplier,
                                  Currency = reqs.Currency,
                                  CreatedDate = reqs.CreatedDate
                              });


            var poHeaders = (from pos in _context.PurchaseOrderHeaders
                             join reqs in _context.RequisitionHeaders on pos.PurchaseOrderNumber equals reqs.PurchaseOrderNumber.ToString() into list
                             from newReqs in list.DefaultIfEmpty()
                             select new
                             {
                                 Id = pos.ProjectId,
                                 RequisitionId = newReqs == null ? "-" : newReqs.Id.ToString(),
                                 POHeaderId = pos.Id.ToString(),
                                 RequisitionNumber = string.IsNullOrEmpty(newReqs.RequisitionNumber.ToString())? "-" : newReqs.RequisitionNumber.ToString(),
                                 PurchaseOrderNumber = pos.PurchaseOrderNumber,
                                 Status = newReqs.Status,
                                 OrderDate = pos.OrderDate,
                                 Supplier = newReqs.Supplier,
                                 Currency = newReqs.Currency,
                                 CreatedDate = newReqs.CreatedDate == null ? null : newReqs.CreatedDate
                             });


            var combineList = reqHeaders.Union(poHeaders)
                                            .Where(m => m.CreatedDate != null)
                                            .OrderByDescending(o => o.CreatedDate)
                                            .Concat(reqHeaders.Union(poHeaders).Where(m => m.CreatedDate == null));

            return combineList;
        }
    }
}
