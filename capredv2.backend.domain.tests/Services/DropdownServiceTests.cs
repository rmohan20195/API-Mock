using System;
using System.Collections.Generic;
using System.Linq;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services;
using NSubstitute;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.Services
{
    [TestFixture]
    public class DropdownServiceTests
    {
        private IDropdownRepository _dropdownRepository;
        private DropdownService _dropdownService;

        [SetUp]
        public void Setup()
        {
            _dropdownRepository = Substitute.For<IDropdownRepository>();
            _dropdownService = new DropdownService(_dropdownRepository);
        }

        [Test]
        public void CreateInstance_OmittingDropdownRepositoryParameter_ThrowArgumentNullException()
        {
            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new DropdownService(null));

            //Assert
            StringAssert.Contains("dropdownRepository", ex.Message);
        }


        [Test]
        public void GetAssetCategories_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Assests 1",
                    Position = 0
                },
                new
                {
                    Id = new Guid("5466519b-d08c-40e7-9602-0188f607a673"),
                    Value = "Assests 2",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetAssetCategories()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetAssetCategories();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }


        [Test]
        public void GetBudgetItemTypes_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Budget 1",
                    Position = 0
                },
                new
                {
                    Id = new Guid("5466519b-d08c-40e7-9602-0188f607a673"),
                    Value = "Budget 2",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetBudgetItemTypes()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetBudgetItemTypes();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetBusinessDrivers_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Business 1",
                    Position = 0
                },
                new
                {
                    Id = new Guid("5466519b-d08c-40e7-9602-0188f607a673"),
                    Value = "Business 2",
                    Position = 1
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Business 3",
                    Position = 2
                }
            }.AsQueryable();

            _dropdownRepository.GetBusinessDrivers()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetBusinessDrivers();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetBusinessJustifications_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Business Justifications 1",
                    Position = 0
                }
            }.AsQueryable();

            _dropdownRepository.GetBusinessJustifications()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetBusinessJustifications();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetBusinessRisks_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Business Risk 1",
                    Position = 0
                },
                new
                {
                    Id = new Guid("5466519b-d08c-40e7-9602-0188f607a673"),
                    Value = "Business Risk 2",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetBusinessRisks()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetBusinessRisks();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetCapitalOrExpenses_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "CapitalOrExpenses 1",
                    Position = 0
                },
                new
                {
                    Id = new Guid("5466519b-d08c-40e7-9602-0188f607a673"),
                    Value = "CapitalOrExpenses 2",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetCapitalOrExpenses()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetCapitalOrExpenses();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetChangeOrderReasons_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Change Order Reasons 1",
                    Position = 0
                },
                new
                {
                    Id = new Guid("5466519b-d08c-40e7-9602-0188f607a673"),
                    Value = "Change Order Reasons 2",
                    Position = 1
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Change Order Reasons 3",
                    Position = 2
                }
            }.AsQueryable();

            _dropdownRepository.GetChangeOrderReasons()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetChangeOrderReasons();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetCipOrNonCips_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Cip Or NonCips 1",
                    Position = 0
                },
                new
                {
                    Id = new Guid("5466519b-d08c-40e7-9602-0188f607a673"),
                    Value = "Cip Or NonCips 2",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetCipOrNonCips()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetCipOrNonCips();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetCostCodeLevel1s_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Cost CodeLevel 1s",
                    Position = 0
                }
            }.AsQueryable();

            _dropdownRepository.GetCostCodeLevel1s()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetCostCodeLevel1s();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetCostCodeLevel2s_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Cost Code Level2s",
                    Position = 0
                }
            }.AsQueryable();

            _dropdownRepository.GetCostCodeLevel2s()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetCostCodeLevel2s();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetFacilityTypes_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Facility Type 1",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Facility Type 2",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetFacilityTypes()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetFacilityTypes();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetFiscalYears_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Fiscal Years 1",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Fiscal Years 2",
                    Position = 1
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Fiscal Years 3",
                    Position = 2
                }
            }.AsQueryable();

            _dropdownRepository.GetFiscalYears()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetFiscalYears();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetItemCategories_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Item Categories 1",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Item Categories 2",
                    Position = 1
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Item Categories 13",
                    Position = 2
                }
            }.AsQueryable();

            _dropdownRepository.GetItemCategories()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetItemCategories();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetItemStatus_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Item Status 1",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Item Status 2",
                    Position = 1
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Item Status 3",
                    Position = 2
                }
            }.AsQueryable();

            _dropdownRepository.GetItemStatus()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetItemStatus();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetLeasedOrOwned_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Leased Or Owned 1",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Leased Or Owned 2",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetLeasedOrOwned()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetLeasedOrOwned();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetMilestones_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Milestones 1",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Milestones 2",
                    Position = 1
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Milestones 3",
                    Position = 2
                }
            }.AsQueryable();

            _dropdownRepository.GetMilestones()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetMilestones();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }


        [Test]
        public void GetPlanProjectOrEmergings_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Emergings",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Plan Project",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetPlanProjectOrEmergings()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetPlanProjectOrEmergings();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetProjectThemes_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Project Themes 1",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Project Themes 1",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetProjectThemes()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetProjectThemes();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetProjectTypes_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Project Type 1",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Project Type 2",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetProjectTypes()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetProjectTypes();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetRealEstateOrBaus_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Real Estate",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Baus",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetRealEstateOrBaus()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetRealEstateOrBaus();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetRegions_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Region 1",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Region 2",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetRegions()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetRegions();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetReportingMilestones_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Reporting Milestone  1",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Reporting Milestone 2",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetReportingMilestones()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetReportingMilestones();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }


        [Test]
        public void GetRequiredOrDiscretionaries_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Required",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Discretionaries",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetRequiredOrDiscretionaries()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetRequiredOrDiscretionaries();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetRestorationRequirements_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Restoration Requirements 1",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Restoration Requirements 2",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetRestorationRequirements()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetRestorationRequirements();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetRolloverCategories_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Rollover Categories 1",
                    Position = 0
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Value = "Rollover Categories 2",
                    Position = 1
                }
            }.AsQueryable();

            _dropdownRepository.GetRolloverCategories()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetRolloverCategories();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

        [Test]
        public void GetWorkPackageLevel1s_ReturnPagedAnonymousObject()
        {
            //Arrange
            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    Value = "Work Package Level 1s",
                    Position = 0
                },
            }.AsQueryable();

            _dropdownRepository.GetWorkPackageLevel1s()
                .Returns(anonymousQueryable);

            //Act
            var response = _dropdownService.GetWorkPackageLevel1s();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(anonymousQueryable.Count(), response.Count());
        }

    }
}
