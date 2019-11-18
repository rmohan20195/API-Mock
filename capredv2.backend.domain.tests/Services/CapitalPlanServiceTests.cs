using System;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.Exceptions;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services;
using capredv2.backend.domain.Services.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.Services
{
    [TestFixture]
    public class CapitalPlanServiceTests
    {
        private ICapitalPlanRepository _repository;
        private ICapitalPlanService _service;

        [SetUp]
        public void Setup()
        {
            _repository = Substitute.For<ICapitalPlanRepository>();
            _service = new CapitalPlanService(_repository);
        }

        [Test]
        public void CreateInstance_OmittingCapitalPlanRepositoryParameter_ThrowArgumentNullException()
        {
            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new CapitalPlanService(null));

            //Assert
            StringAssert.Contains("repository", ex.Message);
        }

        [Test]
        public void Get_ProjectId_ReturnsProjectDTO()
        {
            //Arrange
            var id = new Guid("2509d0dc-fa61-48a5-8650-684592539742");

            var project = new CapitalPlan
            {
                ProjectId = id
            };

            _repository.Get(id).Returns(project);

            //Act
            var response = _service.Get(id);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(id, response.ProjectId);
        }

        [Test]
        public void Update_ProjectIdAndCapitalPlanDTO_CallRepositoryToUpdateContent()
        {
            //Arrange
            var id = new Guid("2509d0dc-fa61-48a5-8650-684592539742");

            var capitalPlanDTO = new CapitalPlanDTO
            {
                ProjectId = id
            };

            //Act
            _service.Update(id, capitalPlanDTO);

            //Assert
            _repository.Received(1).Update(id, Arg.Is<CapitalPlan>(c => c.ProjectId == id));
        }

        [Test]
        public void Update_CapitalPlanIdDoesNotMatchProjectIdInEntity_ThrowBusinessValidationException()
        {
            //Arrange
            var id = new Guid("2509d0dc-fa61-48a5-8650-684592539742");
            var anotherId = new Guid("b80d67ad-112d-4368-9074-d5bf0e3c0fa0");

            var capitalPlanDTO = new CapitalPlanDTO
            {
                ProjectId = id
            };

            //Act
            var ex = Assert.Throws<BusinessValidationException>(() =>
            {
                _service.Update(anotherId, capitalPlanDTO);
            });

            //Assert
            Assert.IsNotNull(ex);
            StringAssert.Contains("The Id informed does not match the Id in the Entity", ex.Message);
        }
    }
}
