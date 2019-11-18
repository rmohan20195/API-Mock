using capredv2.backend.domain.DataContexts.CapRedV2SQLContext;
using capredv2.backend.domain.DomainEntities.Enums;
using capredv2.backend.domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace capredv2.backend.domain.Repositories
{
    public class DropdownRepository : IDropdownRepository
    {
        private readonly CapRedV2Context _context;

        public DropdownRepository(CapRedV2Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<object> GetAssetCategories()
        {
            return _context.AssetCategorys.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetBudgetItemTypes()
        {
            return _context.BudgetItemTypes.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetBusinessDrivers()
        {
            return _context.BusinessDrivers.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetBusinessJustifications()
        {
            return _context.BusinessJustifications.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetBusinessRisks()
        {
            return _context.BusinessRisks.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetCapitalOrExpenses()
        {
            return _context.CapitalOrExpenses.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetChangeOrderReasons()
        {
            return _context.ChangeOrderReasons.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetCipOrNonCips()
        {
            return _context.CipOrNonCips.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetCostCodeLevel1s()
        {
            return _context.CostCodeLevel1s.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetCostCodeLevel2s()
        {
            return _context.CostCodeLevel2s.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetFacilityTypes()
        {
            return _context.FacilityTypes.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetFiscalYears()
        {
            return _context.FiscalYears.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetItemCategories()
        {
            return _context.ItemCategories.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetItemStatus()
        {
            return _context.ItemStatuses.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetLeasedOrOwned()
        {
            return _context.LeasedOrOwneds.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetMilestones()
        {
            return _context.Milestones.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetPlanProjectOrEmergings()
        {
            return _context.PlanProjectOrEmergings.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetProjectThemes()
        {
            return _context.ProjectThemes.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetProjectTypes()
        {
            return _context.ProjectTypes.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetRealEstateOrBaus()
        {
            return _context.RealEstateOrBaus.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetRegions()
        {
            return _context.Regions.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetReportingMilestones()
        {
            return _context.ReportingMilestones.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetRequiredOrDiscretionaries()
        {
            return _context.RequiredOrDiscretionaries.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetRestorationRequirements()
        {
            return _context.RestorationRequirements.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetRolloverCategories()
        {
            return _context.RolloverCategories.OrderBy(x => x.Position);
        }

        public IQueryable<object> GetWorkPackageLevel1s()
        {
            return _context.WorkPackagesLevel1s.OrderBy(x => x.Position);
        }
    }
}
