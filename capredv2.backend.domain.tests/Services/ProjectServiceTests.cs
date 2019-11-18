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
    public class ProjectServiceTests
    {
        private IProjectRepository _repository;
        private ProjectService _service;

        [SetUp]
        public void Setup()
        {
            _repository = Substitute.For<IProjectRepository>();
            _service = new ProjectService(_repository);
        }

        [Test]
        public void CreateInstance_OmittingProjectRepositoryParameter_ThrowArgumentNullException()
        {
            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectService(null));

            //Assert
            StringAssert.Contains("repository", ex.Message);
        }

        [Test]
        public void GetPaged_PagingInformation_ReturnPagedAnonymousObject()
        {
            //Arrange
            const int pageNumber = 1;
            const int pageSize = 10;

            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    ProjectName = "Project 1",
                    FacilityType = "Facility Type 1",
                    LeasedOrOwned = "Owned",
                    Region = "AMER",
                    ApprovedBudget  = 42000D,
                    ProjectStatus = "Open",
                    LastUpdated = "Mark",
                    ProjectType = "Project Type 1",
                },
                new
                {
                    Id = new Guid("5466519b-d08c-40e7-9602-0188f607a673"),
                    ProjectName = "Project 2",
                    FacilityType  = "Facility Type 2",
                    LeasedOrOwned = "Owned",
                    Region = "AMER",
                    ApprovedBudget = 88000D,
                    ProjectStatus = "Open",
                    LastUpdated = "Mark",
                    ProjectType = "New Location"
                }
            }.AsQueryable();

            _repository.CountForGetPaged(pageNumber, pageSize, "facility", "region")
                .Returns(anonymousQueryable.Count());
            _repository.GetPaged(pageNumber, pageSize, "facility", "region")
                .Returns(anonymousQueryable);

            //Act
            var response = _service.GetPaged(pageNumber, pageSize, "facility","region");

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.CurrentPage);
            Assert.AreEqual(1, response.TotalPages);
            Assert.AreEqual(10, response.PageSize);
            Assert.AreEqual(2, response.Count);
        }

        [Test]
        public void Get_ProjectId_ReturnsProjectDTO()
        {
            //Arrange
            var id = new Guid("2509d0dc-fa61-48a5-8650-684592539742");

            var project = new Project
            {
                Id = id
            };

            _repository.Get(id).Returns(project);

            //Act
            var response = _service.Get(id);

            //Assert
            Assert.IsNotNull(response);
            //Assert.AreEqual(id, response.Id);
        }

        [Test]
        public void Add_Project_CallRepositoryAndReturnProjectDTO()
        {
            //Arrange
            var projectDTO = new ProjectDTO
            {
                Id = new Guid("b58b6a58-2064-4c71-9b3d-c8c4514159a9")
            };

            _repository.Add(Arg.Is<Project>(p => p.Id == projectDTO.Id))
                .Returns(Project.MapFromDomainEntity(projectDTO));

            //Act
            var response = _service.Add(projectDTO);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(projectDTO.Id, response.Id);
        }

        [Test]
        public void GetPaged_PagingInformation_ReturnTransactionListPagedAnonymousObject()
        {
            //Arrange
            const int pageNumber = 1;
            const int pageSize = 10;
            var projectId = Guid.NewGuid();

            var anonymousQueryable = new List<object>
            {
                new
                {
                    Id = new Guid("01fab7d5-c8e9-4934-9adf-0ae25bd94b00"),
                    RequisitionId = "123",
                    POHeaderId = "456",
                    RequisitionNumber = "12563",
                    PurchaseOrderNumber = "12",
                    Status = "Ordered",
                    OrderDate = new DateTime(2019, 11,01),
                    Supplier = "Supplier01",
                    Currency = "USD",
                    CreatedDate = new DateTime(2019, 11,05)
                },
                new
                {
                    Id = new Guid("5466519b-d08c-40e7-9602-0188f607a673"),
                    RequisitionId = "123",
                    POHeaderId = "456",
                    RequisitionNumber = "12563",
                    PurchaseOrderNumber = "13",
                    Status = "Ordered",
                    OrderDate = new DateTime(2019, 11,01),
                    Supplier = "Supplier02",
                    Currency = "USD",
                    CreatedDate = new DateTime(2019, 11,05)
                }
            }.AsQueryable();

            _repository.CountForGetTransaction(projectId, pageNumber, pageSize)
                .Returns(anonymousQueryable.Count());
            _repository.GetTransaction(projectId, pageNumber, pageSize)
                .Returns(anonymousQueryable);

            //Act

            var response = _service.GetTransaction(projectId, pageNumber, pageSize);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.CurrentPage);
            Assert.AreEqual(1, response.TotalPages);
            Assert.AreEqual(10, response.PageSize);
            Assert.AreEqual(2, response.Count);
        }
    }
}
