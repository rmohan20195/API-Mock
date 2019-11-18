using System;
using System.Linq;
using capredv2.backend.domain.DomainEntities;
using capredv2.backend.domain.DomainEntities.Projects;

namespace capredv2.backend.domain.Services.Interfaces
{
    public interface IDropdownService
    {
        IQueryable<object> GetAssetCategories();
        IQueryable<object> GetBudgetItemTypes();
        IQueryable<object> GetBusinessDrivers();
        IQueryable<object> GetBusinessJustifications();
        IQueryable<object> GetBusinessRisks();
        IQueryable<object> GetCapitalOrExpenses();
        IQueryable<object> GetChangeOrderReasons();
        IQueryable<object> GetCipOrNonCips();
        IQueryable<object> GetCostCodeLevel1s();
        IQueryable<object> GetCostCodeLevel2s();
        IQueryable<object> GetFacilityTypes();
        IQueryable<object> GetFiscalYears();
        IQueryable<object> GetItemCategories();
        IQueryable<object> GetItemStatus();
        IQueryable<object> GetLeasedOrOwned();
        IQueryable<object> GetMilestones();
        IQueryable<object> GetPlanProjectOrEmergings();
        IQueryable<object> GetProjectThemes();
        IQueryable<object> GetProjectTypes();
        IQueryable<object> GetRealEstateOrBaus();
        IQueryable<object> GetRegions();
        IQueryable<object> GetReportingMilestones();
        IQueryable<object> GetRequiredOrDiscretionaries();
        IQueryable<object> GetRestorationRequirements();
        IQueryable<object> GetRolloverCategories();
        IQueryable<object> GetWorkPackageLevel1s();
    }
}
