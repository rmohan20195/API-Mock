using capredv2.backend.api.Controllers;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;
using capredv2.backend.domain.DomainEntities;
using capredv2.backend.domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.api.tests.Controllers
{
    [TestFixture]
    public class TransactionViewControllerTests
    {
        private IProjectService _projectService;
        private IProjectPurchaseOrderService _projectPurchaseOrderService;
        private IProjectRequisitionService _projectRequistionService;
        private IUnitOfWork _unitOfWork;
        private TransactionViewController _controller;

        [SetUp]
        public void Setup()
        {
            _projectService = Substitute.For<IProjectService>();
            _projectPurchaseOrderService = Substitute.For<IProjectPurchaseOrderService>();
            _projectRequistionService = Substitute.For<IProjectRequisitionService>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _controller = new TransactionViewController(_projectService,_projectPurchaseOrderService,_projectRequistionService,_unitOfWork);
        }

        [Test]
        public void CreateController_OmittingProjectService_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new TransactionViewController(null, _projectPurchaseOrderService,_projectRequistionService, _unitOfWork));

            //Assert
            StringAssert.Contains("projectService", ex.Message);
        }

        [Test]
        public void CreateController_OmittingProjectPurchaseOrderService_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new TransactionViewController(_projectService, null, _projectRequistionService, _unitOfWork));

            //Assert
            StringAssert.Contains("projectPurchaseOrderService", ex.Message);
        }

        [Test]
        public void CreateController_OmittingProjectRequisitionService_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new TransactionViewController(_projectService, _projectPurchaseOrderService, null, _unitOfWork));

            //Assert
            StringAssert.Contains("projectRequistionService", ex.Message);
        }

        [Test]
        public void CreateController_OmittingUnitOfWork_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new TransactionViewController(_projectService , _projectPurchaseOrderService, _projectRequistionService, null));

            //Assert
            StringAssert.Contains("unitOfWork", ex.Message);
        }


        //[Test]
        //public void PagedGet_PagingInformation_ReturnsPagedCollectionOfAnonymousEntity()
        //{
        //    //Arrange
        //    const int pageNumber = 1;
        //    const int pageSize = 10;

        //    _projectService.GetPaged(pageSize, pageNumber, null)
        //        .Returns(new GenericPagedCollection<object>());

        //    //Act
        //    var response = _controller.TransactionCollection(Guid.NewGuid(), pageSize, pageNumber);
        //    var negotiatedResult = response as ObjectResult;

        //    //Assert
        //    Assert.IsNotNull(negotiatedResult);
        //    Assert.AreEqual(200, negotiatedResult.StatusCode);
        //    Assert.IsNotNull(negotiatedResult.Value);
        //}
    }
}
