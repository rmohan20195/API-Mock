using capredv2.backend.api.Controllers;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System;

namespace capredv2.backend.api.tests.Controllers
{
    [TestFixture]
    public class EnumTablesControllerTests
    {
        private IDropdownService _dropdownService;
        private IUnitOfWork _unitOfWork;
        private EnumTablesController _controller;

		//TODO: Fix these Unit Tests

        [SetUp]

        public void Setup()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _dropdownService = Substitute.For<IDropdownService>();
            _controller = new EnumTablesController(_unitOfWork, _dropdownService);
        }

        [Test]
        public void CreateController_OmittingUnitOfWork__ThrowArgumentNullException()
        {
            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new EnumTablesController(null, _dropdownService));

            //Assert
            StringAssert.Contains("unitOfWork", ex.Message);
        }

        [Test]
        public void CreateController_OmittingService_ThrowArgumentNullException()
        {
            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new EnumTablesController(_unitOfWork, null));

            //Assert
            StringAssert.Contains("dropdownService", ex.Message);
        }

        [Test]
        public void GetAssetCategories_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetAssetCategories() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetBudgetItemTypes_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetBudgetItemTypes() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetBusinessDrivers_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetBusinessDrivers() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetBusinessJustifications_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetBusinessJustifications() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetBusinessRisks_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetBusinessRisks() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetCapitalOrExpense_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetCapitalOrExpense() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetChangeOrderReasons_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetChangeOrderReasons() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetCipOrNonCip_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetCipOrNonCip() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetCostCodesLevel1_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetCostCodesLevel1() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetCostCodesLevel2_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetCostCodesLevel2() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetFacilityTypes_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetFacilityTypes() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetItemCategories_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetItemCategories() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetLeasedOrOwned_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetLeasedOrOwned() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetMileStones_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetMilestones() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetPlanProjectOrEmerging_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetPlanProjectOrEmerging() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetProjectThemes_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetProjectThemes() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetProjectTypes_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetProjectTypes() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetRealStateOrBau_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetRealStateOrBau() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetRegions_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetRegions() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetReportingMilestones_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetReportingMilestones() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetRequiredOrDiscretionary_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetRequiredOrDiscretionary() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetRolloverCategory_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetRolloverCategory() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public void GetWorkPackagesLevel1_NoParameters_ReturnListFromEnumValues()
        {
            //Arrange


            //Act
            var response = _controller.GetWorkPackagesLevel1() as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }
    }
}
