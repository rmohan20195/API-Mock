using System;
using System.Collections.Generic;
using System.IO;
using capredv2.backend.api.Controllers;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;
using capredv2.backend.domain.DomainEntities.CoupaImporter;
using capredv2.backend.domain.Services.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using NUnit.Framework;

namespace capredv2.backend.api.tests.Controllers
{
    [TestFixture]
    public class CoupaImporterControllerTests
    {
        private ICoupaImporterService _service;
        private IUnitOfWork _unitOfWork;
        private CoupaImporterController _controller;
        private IBackgroundJobClient _backgroundJobClient;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<ICoupaImporterService>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _backgroundJobClient = Substitute.For<IBackgroundJobClient>();

            _controller = new CoupaImporterController(_service, _unitOfWork, _backgroundJobClient);
        }

        [Test]
        public void CreateController_OmittingService_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new CoupaImporterController(null, _unitOfWork, _backgroundJobClient));

            //Assert
            StringAssert.Contains("coupaImporterService", ex.Message);
        }

        [Test]
        public void CreateController_OmittingUnitOfWork_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new CoupaImporterController(_service, null, _backgroundJobClient));

            //Assert
            StringAssert.Contains("unitOfWork", ex.Message);
        }

        [Test]
        public void CreateController_OmittingBackgroundJobClient_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new CoupaImporterController(_service, _unitOfWork, null));

            //Assert
            StringAssert.Contains("backgroundJobClient", ex.Message);
        }

        [Test]
        public void UploadFile_NoFilePresentInTheRequest_ThrowsUnsupportedMediaTypeResult()
        {
            //Arrange
            _controller.ControllerContext = new ControllerContext(ContextWithEmptyRequest());

            //Act
            var invoiceResponseMessageResult = _controller.UploadInvoice(Guid.NewGuid()).Result as UnsupportedMediaTypeResult;
            var purchaseOrderResponseMessageResult = _controller.UploadPurchaseOrder(Guid.NewGuid()).Result as UnsupportedMediaTypeResult;
            var requisitionResponseMessageResult = _controller.UploadRequisition(Guid.NewGuid()).Result as UnsupportedMediaTypeResult;

            //Assert
            Assert.IsNotNull(invoiceResponseMessageResult);
            Assert.AreEqual(415, invoiceResponseMessageResult.StatusCode);

            Assert.IsNotNull(purchaseOrderResponseMessageResult);
            Assert.AreEqual(415, purchaseOrderResponseMessageResult.StatusCode);

            Assert.IsNotNull(requisitionResponseMessageResult);
            Assert.AreEqual(415, requisitionResponseMessageResult.StatusCode);
        }

        [Test]
        public void UploadFile_AnyOtherFileType_ThrowsUnsupportedMediaTypeResult()
        {
            //Arrange
            _controller.ControllerContext = new ControllerContext(ContextWithRequestWithOtherFileTypeThatNotCsv());

            //Act
            var invoiceResponseMessageResult = _controller.UploadInvoice(Guid.NewGuid()).Result as UnsupportedMediaTypeResult;
            var purchaseOrderResponseMessageResult = _controller.UploadPurchaseOrder(Guid.NewGuid()).Result as UnsupportedMediaTypeResult;
            var requisitionResponseMessageResult = _controller.UploadRequisition(Guid.NewGuid()).Result as UnsupportedMediaTypeResult;


            //Assert
            Assert.IsNotNull(invoiceResponseMessageResult);
            Assert.AreEqual(415, invoiceResponseMessageResult.StatusCode);

            Assert.IsNotNull(purchaseOrderResponseMessageResult);
            Assert.AreEqual(415, purchaseOrderResponseMessageResult.StatusCode);

            Assert.IsNotNull(requisitionResponseMessageResult);
            Assert.AreEqual(415, requisitionResponseMessageResult.StatusCode);
        }

        [Test]
        public void UploadFile_EmptyCSVFile_ThrowsUnsupportedMediaTypeResult()
        {
            //Arrange
            _controller.ControllerContext = new ControllerContext(ContextWithEmptyCsvFile());

            //Act
            var invoiceResponseMessageResult = _controller.UploadInvoice(Guid.NewGuid()).Result as UnsupportedMediaTypeResult;
            var purchaseOrderResponseMessageResult = _controller.UploadPurchaseOrder(Guid.NewGuid()).Result as UnsupportedMediaTypeResult;
            var requisitionResponseMessageResult = _controller.UploadRequisition(Guid.NewGuid()).Result as UnsupportedMediaTypeResult;

            //Assert
            Assert.IsNotNull(invoiceResponseMessageResult);
            Assert.AreEqual(415, invoiceResponseMessageResult.StatusCode);

            Assert.IsNotNull(purchaseOrderResponseMessageResult);
            Assert.AreEqual(415, purchaseOrderResponseMessageResult.StatusCode);

            Assert.IsNotNull(requisitionResponseMessageResult);
            Assert.AreEqual(415, requisitionResponseMessageResult.StatusCode);
        }

        [Test]
        public void UploadFile_CsvFileAndProjectId_CallServiceToSaveFileCorrectly()
        {
            //Arrange
            var projectId = new Guid("4d75753e-618d-4067-9019-f91a64407bca");
            var coupaHeaderDTO = new CoupaImporterJobDefinitionDTO
            {
                Id = new Guid("93281c6c-8e96-429c-bb8a-d838b6abe621"),
                FileName = "Test"
            };

            _controller.ControllerContext = new ControllerContext(ContextWithValidRequest());
            _service.CreateInvoiceImportJobDefinition(projectId, Arg.Any<MemoryStream>(), Arg.Any<string>())
                .Returns(coupaHeaderDTO);

            _service.CreatePurchaseOrderImportJobDefinition(projectId, Arg.Any<MemoryStream>(), Arg.Any<string>())
                .Returns(coupaHeaderDTO);

            _service.CreateRequisitionImportJobDefinition(projectId, Arg.Any<MemoryStream>(), Arg.Any<string>())
                .Returns(coupaHeaderDTO);

            //Act
            var invoiceResult = _controller.UploadInvoice(projectId).Result as OkObjectResult;
            var purchaseOrderResult = _controller.UploadPurchaseOrder(projectId).Result as OkObjectResult;
            var requisitionResult = _controller.UploadRequisition(projectId).Result as OkObjectResult;

            //Assert
            Assert.IsNotNull(invoiceResult);
            Assert.AreEqual(200, invoiceResult.StatusCode);

            Assert.IsNotNull(purchaseOrderResult);
            Assert.AreEqual(200, purchaseOrderResult.StatusCode);

            Assert.IsNotNull(requisitionResult);
            Assert.AreEqual(200, requisitionResult.StatusCode);
            _unitOfWork.Received(3).SaveChangesAsync();
        }

        [Test]
        public void UploadFile_CsvFileButServiceReturnsNull_ReturnBadRequestWithMessage()
        {
            var projectId = new Guid("4d75753e-618d-4067-9019-f91a64407bca");
            //Arrange
            _controller.ControllerContext = new ControllerContext(ContextWithValidRequest());

            _service.CreateInvoiceImportJobDefinition(projectId, Arg.Any<MemoryStream>(), Arg.Any<string>())
              .Returns((CoupaImporterJobDefinitionDTO)null);

            _service.CreatePurchaseOrderImportJobDefinition(projectId, Arg.Any<MemoryStream>(), Arg.Any<string>())
                .Returns((CoupaImporterJobDefinitionDTO)null);

            _service.CreateRequisitionImportJobDefinition(projectId, Arg.Any<MemoryStream>(), Arg.Any<string>())
                .Returns((CoupaImporterJobDefinitionDTO)null);

            //Act
            var invoiceResult = _controller.UploadInvoice(projectId).Result as BadRequestObjectResult;
            var purchaseOrderResult = _controller.UploadPurchaseOrder(projectId).Result as BadRequestObjectResult;
            var requisitionResult = _controller.UploadRequisition(projectId).Result as BadRequestObjectResult;

            //Assert
            Assert.IsNotNull(invoiceResult);
            Assert.AreEqual(400, invoiceResult.StatusCode);
            StringAssert.Contains("An error occurred while uploading the file, please try again or contact the system administrator.",
                invoiceResult.Value.ToString());

            Assert.IsNotNull(purchaseOrderResult);
            Assert.AreEqual(400, purchaseOrderResult.StatusCode);
            StringAssert.Contains("An error occurred while uploading the file, please try again or contact the system administrator.",
                purchaseOrderResult.Value.ToString());

            Assert.IsNotNull(requisitionResult);
            Assert.AreEqual(400, requisitionResult.StatusCode);
            StringAssert.Contains("An error occurred while uploading the file, please try again or contact the system administrator.",
                requisitionResult.Value.ToString());
        }

        [Test]
        public void UploadFile_CsvFile_CallHangfireToEnqueueJobDefinition()
        {
            var projectId = new Guid("4d75753e-618d-4067-9019-f91a64407bca");
            //Arrange
            var coupaHeaderDTO = new CoupaImporterJobDefinitionDTO
            {
                Id = new Guid("93281c6c-8e96-429c-bb8a-d838b6abe621"),
                FileName = "Test"
            };

            _controller.ControllerContext = new ControllerContext(ContextWithValidRequest());

            _service.CreateInvoiceImportJobDefinition(projectId, Arg.Any<MemoryStream>(), Arg.Any<string>())
         .Returns(coupaHeaderDTO);

            _service.CreatePurchaseOrderImportJobDefinition(projectId, Arg.Any<MemoryStream>(), Arg.Any<string>())
                .Returns(coupaHeaderDTO);

            _service.CreateRequisitionImportJobDefinition(projectId, Arg.Any<MemoryStream>(), Arg.Any<string>())
                .Returns(coupaHeaderDTO);

            //Act
            var invoiceResult = _controller.UploadInvoice(projectId).Result as OkObjectResult;
            var purchaseOrderResult = _controller.UploadPurchaseOrder(projectId).Result as OkObjectResult;
            var requisitionResult = _controller.UploadRequisition(projectId).Result as OkObjectResult;

            //TODO: test this
            //Assert
            //_backgroundJobClient.ReceivedWithAnyArgs(1)
            //    .Enqueue(() => { });
        }

        private static ActionContext ContextWithEmptyRequest()
        {
            var request = Substitute.For<HttpRequest>();
            request.GetMultipartBoundary().Returns("requestTest");

            var httpContext = Substitute.For<HttpContext>();

            var actionContext = Substitute.For<ActionContext>();
            actionContext.HttpContext = httpContext;
            actionContext.HttpContext.Request.Returns(request);

            actionContext.RouteData = new RouteData();
            actionContext.ActionDescriptor = new ControllerActionDescriptor();

            return actionContext;
        }

        private static ActionContext ContextWithValidRequest()
        {
            var stubbedStream = Substitute.For<Stream>();
            var formFile = new FormFile(stubbedStream, long.MinValue, 255, "TestFile.csv", "TestFile.csv")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/csv"
            };
            var formFileCollection = new FormFileCollection { formFile };

            var request = Substitute.For<HttpRequest>();
            request.Form = new FormCollection(new Dictionary<string, StringValues>(), formFileCollection);
            request.GetMultipartBoundary().Returns("requestTest");

            var httpContext = Substitute.For<HttpContext>();

            var actionContext = Substitute.For<ActionContext>();
            actionContext.HttpContext = httpContext;
            actionContext.HttpContext.Request.Returns(request);

            actionContext.RouteData = new RouteData();
            actionContext.ActionDescriptor = new ControllerActionDescriptor();

            return actionContext;
        }

        private static ActionContext ContextWithRequestWithOtherFileTypeThatNotCsv()
        {
            var formFile = new FormFile(Stream.Null, long.MinValue, 255, "TestFile.doc", "TestFile.doc")
            {
                Headers = new HeaderDictionary(),
                ContentType = "SomeOtherFileType"
            };
            var formFileCollection = new FormFileCollection { formFile };

            var request = Substitute.For<HttpRequest>();
            request.Form = new FormCollection(new Dictionary<string, StringValues>(), formFileCollection);
            request.GetMultipartBoundary().Returns("requestTest");

            var httpContext = Substitute.For<HttpContext>();

            var actionContext = Substitute.For<ActionContext>();
            actionContext.HttpContext = httpContext;
            actionContext.HttpContext.Request.Returns(request);

            actionContext.RouteData = new RouteData();
            actionContext.ActionDescriptor = new ControllerActionDescriptor();

            return actionContext;
        }

        private static ActionContext ContextWithEmptyCsvFile()
        {
            var formFile = new FormFile(Stream.Null, long.MinValue, 0, "TestFile.csv", "TestFile.csv")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/csv"
            };
            var formFileCollection = new FormFileCollection { formFile };

            var request = Substitute.For<HttpRequest>();
            request.Form = new FormCollection(new Dictionary<string, StringValues>(), formFileCollection);
            request.GetMultipartBoundary().Returns("requestTest");

            var httpContext = Substitute.For<HttpContext>();

            var actionContext = Substitute.For<ActionContext>();
            actionContext.HttpContext = httpContext;
            actionContext.HttpContext.Request.Returns(request);

            actionContext.RouteData = new RouteData();
            actionContext.ActionDescriptor = new ControllerActionDescriptor();

            return actionContext;
        }
    }
}
