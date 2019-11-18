using capredv2.backend.domain.DomainEntities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace capredv2.backend.domain.Repositories.Interfaces
{
    public interface IDropdownRepository
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
