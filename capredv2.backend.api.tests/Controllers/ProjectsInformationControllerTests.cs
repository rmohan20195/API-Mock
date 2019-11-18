using System;
using System.Threading.Tasks;
using capredv2.backend.api.Controllers;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace capredv2.backend.api.tests.Controllers
{
    [TestFixture]
    public class ProjectsInformationControllerTests
    {
        private IProjectInformationService _service;
        private ProjectsInformationController _controller;
        private IUnitOfWork _unitOfWork;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IProjectInformationService>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _controller = new ProjectsInformationController(_service, _unitOfWork);
        }

        [Test]
        public void CreateController_OmittingProjectService_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectsInformationController(null, _unitOfWork));

            //Assert
            StringAssert.Contains("projectInformationService", ex.Message);
        }

        [Test]
        public void CreateController_OmittingUnitOfWork_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectsInformationController(_service, null));

            //Assert
            StringAssert.Contains("unitOfWork", ex.Message);
        }

        [Test]
        public void Get_ExistingProjectId_ReturnProjectDTO()
        {
            //Arrange
            var id = new Guid("2509d0dc-fa61-48a5-8650-684592539742");

            var projectDTO = new ProjectInformationDTO
            {
                ProjectId = id
            };

            _service.Get(id)
                .Returns(projectDTO);

            //Act
            var response = _controller.Get(id) as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            var resultAsDTO = (ProjectInformationDTO)response.Value;

            Assert.IsNotNull(resultAsDTO);
            Assert.AreEqual(id, resultAsDTO.ProjectId);
        }

        [Test]
        public void Get_NonExistingProjectId_ReturnNotFound()
        {
            //Arrange
            var id = new Guid("2509d0dc-fa61-48a5-8650-684592539742");

            _service.Get(id)
                .Returns((ProjectInformationDTO)null);

            //Act
            var response = _controller.Get(id) as NotFoundResult;

            //Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public void Put_ProjectIdProjectInformationDTO_ReturnsNoContent()
        {
            //Arrange
            var id = new Guid("8e1e1161-d83d-4962-8094-4cee0a9dc210");

            var projectInformationDTO = new ProjectInformationDTO
            {
                ProjectId = id
            };

            _unitOfWork.SaveChangesAsync()
                .Returns(Task.FromResult(1));

            //Act
            var response = _controller.Put(id, projectInformationDTO).Result;
            var contentResult = response as NoContentResult;

            //Assert
            Assert.IsNotNull(contentResult);
            _service.Received(1).Update(id, projectInformationDTO);
        }

        [Test]
        public void Put_NullInformationDTO_ThrowsBadRequest()
        {
            //Arrange
            var id = new Guid("8e1e1161-d83d-4962-8094-4cee0a9dc210");

            _unitOfWork.SaveChangesAsync()
                .Returns(Task.FromResult(1));

            //Act
            var response = _controller.Put(id, null).Result;
            var contentResult = response as BadRequestObjectResult;

            //Assert
            Assert.IsNotNull(contentResult);
        }

        [Test]
        public void Put_NonExistentProjectIdProjectInformationDTO_ReturnsNoContent()
        {
            //Arrange
            var id = new Guid("8e1e1161-d83d-4962-8094-4cee0a9dc210");

            var projectInformationDTO = new ProjectInformationDTO
            {
                ProjectId = id
            };

            _unitOfWork.SaveChangesAsync()
                .Returns(Task.FromResult(0));

            //Act
            var response = _controller.Put(id, projectInformationDTO).Result;
            var contentResult = response as NotFoundResult;

            //Assert
            Assert.IsNotNull(contentResult);
            _service.Received(1).Update(id, projectInformationDTO);
        }
    }
}
