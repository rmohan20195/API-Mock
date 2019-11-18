using System;
using System.Collections.Generic;
using System.Linq;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.Exceptions;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services.Interfaces;

namespace capredv2.backend.domain.Services
{
    public class DropdownService : IDropdownService
    {
        private readonly IDropdownRepository _dropdownRepository;
        public DropdownService(IDropdownRepository dropdownRepository)
        {
            _dropdownRepository = dropdownRepository ?? throw new ArgumentNullException(nameof(dropdownRepository));
        }
        public IQueryable<object> GetAssetCategories()
        {
            return _dropdownRepository.GetAssetCategories();
        }

        public IQueryable<object> GetBudgetItemTypes()
        {
            return _dropdownRepository.GetBudgetItemTypes();
        }

        public IQueryable<object> GetBusinessDrivers()
        {
            return _dropdownRepository.GetBusinessDrivers();
        }

        public IQueryable<object> GetBusinessJustifications()
        {
            return _dropdownRepository.GetBusinessJustifications();
        }

        public IQueryable<object> GetBusinessRisks()
        {
            return _dropdownRepository.GetBusinessRisks();
        }

        public IQueryable<object> GetCapitalOrExpenses()
        {
            return _dropdownRepository.GetCapitalOrExpenses();
        }

        public IQueryable<object> GetChangeOrderReasons()
        {
            return _dropdownRepository.GetChangeOrderReasons();
        }

        public IQueryable<object> GetCipOrNonCips()
        {
            return _dropdownRepository.GetCipOrNonCips();
        }

        public IQueryable<object> GetCostCodeLevel1s()
        {
            return _dropdownRepository.GetCostCodeLevel1s();
        }

        public IQueryable<object> GetCostCodeLevel2s()
        {
            return _dropdownRepository.GetCostCodeLevel2s();
        }

        public IQueryable<object> GetFacilityTypes()
        {
            return _dropdownRepository.GetFacilityTypes();
        }

        public IQueryable<object> GetFiscalYears()
        {
            return _dropdownRepository.GetFiscalYears();
        }

        public IQueryable<object> GetItemCategories()
        {
            return _dropdownRepository.GetItemCategories();
        }

        public IQueryable<object> GetItemStatus()
        {
            return _dropdownRepository.GetItemStatus();
        }

        public IQueryable<object> GetLeasedOrOwned()
        {
            return _dropdownRepository.GetLeasedOrOwned();
        }

        public IQueryable<object> GetMilestones()
        {
            return _dropdownRepository.GetMilestones();
        }

        public IQueryable<object> GetPlanProjectOrEmergings()
        {
            return _dropdownRepository.GetPlanProjectOrEmergings();
        }

        public IQueryable<object> GetProjectThemes()
        {
            return _dropdownRepository.GetProjectThemes();
        }

        public IQueryable<object> GetProjectTypes()
        {
            return _dropdownRepository.GetProjectTypes();
        }

        public IQueryable<object> GetRealEstateOrBaus()
        {
            return _dropdownRepository.GetRealEstateOrBaus();
        }

        public IQueryable<object> GetRegions()
        {
            return _dropdownRepository.GetRegions();
        }

        public IQueryable<object> GetReportingMilestones()
        {
            return _dropdownRepository.GetReportingMilestones();
        }

        public IQueryable<object> GetRequiredOrDiscretionaries()
        {
            return _dropdownRepository.GetRequiredOrDiscretionaries();
        }

        public IQueryable<object> GetRestorationRequirements()
        {
            return _dropdownRepository.GetRestorationRequirements();
        }

        public IQueryable<object> GetRolloverCategories()
        {
            return _dropdownRepository.GetRolloverCategories();
        }

        public IQueryable<object> GetWorkPackageLevel1s()
        {
            return _dropdownRepository.GetWorkPackageLevel1s();
        }
    }
}
