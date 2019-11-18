using System;
using System.Linq;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;
using capredv2.backend.domain.DomainEntities.Enums;
using capredv2.backend.domain.ExtensionMethods;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace capredv2.backend.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class EnumTablesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDropdownService _dropdownService;
        public EnumTablesController(IUnitOfWork unitOfWork, IDropdownService dropdownService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _dropdownService = dropdownService ?? throw new ArgumentNullException(nameof(dropdownService));
        }

        // GET /api/EnumTables/AssetCategories
        [HttpGet]
        [Route("AssetCategories")]
        public IActionResult GetAssetCategories()
        {
            var assetCategories = _dropdownService.GetAssetCategories();
            return Ok(assetCategories);
        }

        // GET /api/EnumTables/BudgetItemTypes
        [HttpGet]
        [Route("BudgetItemTypes")]
        public IActionResult GetBudgetItemTypes()
        {
            var budgetItemTypes = _dropdownService.GetBudgetItemTypes();
            return Ok(budgetItemTypes);
        }

        // GET /api/EnumTables/BusinessDrivers
        [HttpGet]
        [Route("BusinessDrivers")]
        public IActionResult GetBusinessDrivers()
        {
            var businessDrivers = _dropdownService.GetBusinessDrivers();
            return Ok(businessDrivers);
        }

        // GET /api/EnumTables/BusinessJustifications
        [HttpGet]
        [Route("BusinessJustifications")]
        public IActionResult GetBusinessJustifications()
        {
            var businessJustifications = _dropdownService.GetBusinessJustifications();
            return Ok(businessJustifications);
        }

        // GET /api/EnumTables/BusinessRisks
        [HttpGet]
        [Route("BusinessRisks")]
        public IActionResult GetBusinessRisks()
        {
            var businessRisks = _dropdownService.GetBusinessRisks();
            return Ok(businessRisks);
        }

        // GET /api/EnumTables/CapitalOrExpense
        [HttpGet]
        [Route("CapitalOrExpense")]
        public IActionResult GetCapitalOrExpense()
        {
            var capitalOrExpenses = _dropdownService.GetCapitalOrExpenses();
            return Ok(capitalOrExpenses);
        }

        // GET /api/EnumTables/ChangeOrderReasons
        [HttpGet]
        [Route("ChangeOrderReasons")]
        public IActionResult GetChangeOrderReasons()
        {
            var changeOrderReasons = _dropdownService.GetChangeOrderReasons();
            return Ok(changeOrderReasons);
        }

        // GET /api/EnumTables/CipOrNonCip
        [HttpGet]
        [Route("CipOrNonCip")]
        public IActionResult GetCipOrNonCip()
        {
            var cipOrNonCips = _dropdownService.GetCipOrNonCips();
            return Ok(cipOrNonCips);
        }

        // GET /api/EnumTables/CostCodesLevel1
        [HttpGet]
        [Route("CostCodesLevel1")]
        public IActionResult GetCostCodesLevel1()
        {
            var costCodesLevel1s = _dropdownService.GetCostCodeLevel1s();
            return Ok(costCodesLevel1s);
        }

        // GET /api/EnumTables/CostCodesLevel2
        [HttpGet]
        [Route("CostCodesLevel2")]
        public IActionResult GetCostCodesLevel2()
        {
            var costCodesLevel2s = _dropdownService.GetCostCodeLevel2s();
            return Ok(costCodesLevel2s);
        }

        // GET /api/EnumTables/FacilityTypes
        [HttpGet]
        [Route("FacilityTypes")]
        public IActionResult GetFacilityTypes()
        {
            var facilityTypes = _dropdownService.GetFacilityTypes();
            return Ok(facilityTypes);
        }

        // GET /api/EnumTables/ItemCategories
        [HttpGet]
        [Route("ItemCategories")]
        public IActionResult GetItemCategories()
        {
            var itemCategories = _dropdownService.GetItemCategories();
            return Ok(itemCategories);
        }

        // GET /api/EnumTables/LeasedOrOwned
        [HttpGet]
        [Route("LeasedOrOwned")]
        public IActionResult GetLeasedOrOwned()
        {
            var leasedOrOwned = _dropdownService.GetLeasedOrOwned();
            return Ok(leasedOrOwned);
        }

        // GET /api/EnumTables/Milestones
        [HttpGet]
        [Route("Milestones")]
        public IActionResult GetMilestones()
        {
            var milestones = _dropdownService.GetMilestones();
            return Ok(milestones);
        }

        // GET /api/EnumTables/PlanProjectOrEmerging
        [HttpGet]
        [Route("PlanProjectOrEmerging")]
        public IActionResult GetPlanProjectOrEmerging()
        {
            var planProjectOrEmergings = _dropdownService.GetPlanProjectOrEmergings();
            return Ok(planProjectOrEmergings);
        }

        // GET /api/EnumTables/ProjectThemes
        [HttpGet]
        [Route("ProjectThemes")]
        public IActionResult GetProjectThemes()
        {
            var projectThemes = _dropdownService.GetProjectThemes();
            return Ok(projectThemes);
        }

        // GET /api/EnumTables/ProjectTypes
        [HttpGet]
        [Route("ProjectTypes")]
        public IActionResult GetProjectTypes()
        {
            var projectTypes = _dropdownService.GetProjectTypes();
            return Ok(projectTypes);
        }

        // GET /api/EnumTables/RealEstateOrBau
        [HttpGet]
        [Route("RealEstateOrBau")]
        public IActionResult GetRealStateOrBau()
        {
            var realEstateOrBaus = _dropdownService.GetRealEstateOrBaus();
            return Ok(realEstateOrBaus);
        }

        // GET /api/EnumTables/Regions
        [HttpGet]
        [Route("Regions")]
        public IActionResult GetRegions()
        {
            var regions = _dropdownService.GetRegions();
            return Ok(regions);
        }

        // GET /api/EnumTables/ReportingMilestones
        [HttpGet]
        [Route("ReportingMilestones")]
        public IActionResult GetReportingMilestones()
        {
            var reportingMilestones = _dropdownService.GetReportingMilestones();
            return Ok(reportingMilestones);
        }

        // GET /api/EnumTables/RequiredOrDiscretionary
        [HttpGet]
        [Route("RequiredOrDiscretionary")]
        public IActionResult GetRequiredOrDiscretionary()
        {
            var requiredOrDiscretionaries = _dropdownService.GetRequiredOrDiscretionaries();
            return Ok(requiredOrDiscretionaries);
        }

        // GET /api/EnumTables/RolloverCategory
        [HttpGet]
        [Route("RolloverCategory")]
        public IActionResult GetRolloverCategory()
        {
            var rolloverCategories = _dropdownService.GetRolloverCategories();
            return Ok(rolloverCategories);
        }

        // GET /api/EnumTables/WorkPackagesLevel1
        [HttpGet]
        [Route("WorkPackagesLevel1")]
        public IActionResult GetWorkPackagesLevel1()
        {
            var workPackageLevel1s = _dropdownService.GetWorkPackageLevel1s();
            return Ok(workPackageLevel1s);
        }
    }
}
