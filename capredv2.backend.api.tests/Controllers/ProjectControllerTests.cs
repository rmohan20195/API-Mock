using System;
using capredv2.backend.api.Controllers;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;
using capredv2.backend.domain.DomainEntities;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace capredv2.backend.api.tests.Controllers
{
    [TestFixture]
    public class ProjectControllerTests
    {
        private IProjectService _service;
        private ProjectsController _controller;
        private IUnitOfWork _unitOfWork;

	    [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IProjectService>();
	        _unitOfWork = Substitute.For<IUnitOfWork>();
            _controller = new ProjectsController(_service, _unitOfWork);
        }

        [Test]
        public void CreateController_OmittingProjectService_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectsController(null, _unitOfWork));

            //Assert
            StringAssert.Contains("projectService", ex.Message);
        }

        [Test]
        public void CreateController_OmittingUnitOfWork_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectsController(_service, null));

            //Assert
            StringAssert.Contains("unitOfWork", ex.Message);
        }

        //TODO: create unit tests and fix all these Unit Tests

        [Test]
        public void PagedGet_PagingInformation_ReturnsPagedCollectionOfAnonymousEntity()
        {
            //Arrange
            const int pageNumber = 1;
            const int pageSize = 10;

            _service.GetPaged(pageSize, pageNumber, "facility", "region")
                .Returns(new GenericPagedCollection<object>());

            //Act
            var response = _controller.PagedGet(pageSize, pageNumber, "facility", "region");
            var negotiatedResult = response as ObjectResult;

            //Assert
            Assert.IsNotNull(negotiatedResult);
            Assert.AreEqual(200, negotiatedResult.StatusCode);
            Assert.IsNotNull(negotiatedResult.Value);
        }

        [Test]
        public void Get_ExistingProjectId_ReturnProjectDTO()
        {
            //Arrange
            var id = new Guid("2509d0dc-fa61-48a5-8650-684592539742");

            var projectDTO = new ProjectDTO
            {
                Id = id
            };

            _service.Get(id)
                .Returns(projectDTO);

            //Act
            var response = _controller.Get(id) as ObjectResult;

            //Assert
            Assert.IsNotNull(response);
            var resultAsDTO = (ProjectDTO)response.Value;

            Assert.IsNotNull(resultAsDTO);
            Assert.AreEqual(id, resultAsDTO.Id);
        }

        [Test]
        public void Get_NonExistingProjectId_ReturnNotFound()
        {
            //Arrange
            var id = new Guid("2509d0dc-fa61-48a5-8650-684592539742");

            _service.Get(id)
                .Returns((ProjectDTO)null);

            //Act
            var response = _controller.Get(id) as NotFoundResult;

            //Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public void Post_ValidProject_CallServiceAndReturnOkWithProjectDTOResponse()
        {
            //Arrange
            var project = new ProjectDTO
            {
                Id = new Guid("b58b6a58-2064-4c71-9b3d-c8c4514159a9")
            };

            _service.Add(project).Returns(project);

            //Act
            var objectResult = _controller.Post(project).Result as ObjectResult;

            //Assert
            Assert.IsNotNull(objectResult);
            var resultAsDTO = (ProjectDTO)objectResult.Value;

            Assert.IsNotNull(resultAsDTO);
            Assert.AreEqual(project.Id, resultAsDTO.Id);
        }

        [Test]
        public void Post_ValidProject_CallUnitOfWorkToSaveChanges()
        {
            //Arrange
            var project = new ProjectDTO
            {
                Id = new Guid("b58b6a58-2064-4c71-9b3d-c8c4514159a9")
            };

            _service.Add(project).Returns(project);

            //Act
            var objectResult = _controller.Post(project).Result as ObjectResult;

            //Assert
            _unitOfWork.Received(1).SaveChangesAsync();
            Assert.IsNotNull(objectResult);
        }
    }
}
