using System;
using System.IO;
using System.Threading.Tasks;
using capredv2.backend.api.Middlewares;
using capredv2.backend.domain.Exceptions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace capredv2.backend.api.tests.Middlewares
{
    [TestFixture]
    public class ErrorHandlingMiddlewareTests
    {
        private DefaultHttpContext _httpContext;

        [SetUp]
        public void CreateInstances()
        {
            _httpContext = new DefaultHttpContext();
            _httpContext.Request.Scheme = "http";
            _httpContext.Request.Host = HostString.FromUriComponent("unit test");
            _httpContext.Request.QueryString = QueryString.Create("querystring", "param");

            _httpContext.Response.Body = new MemoryStream();
        }

        [Test]
        public async Task HandleExceptions_BusinessValidationException_ReturnBadRequest()
        {
            //Arrange
            var errorHandlingMiddleware =
                new ErrorHandlingMiddleware(
                    innerHttpContext => throw new BusinessValidationException("unit test"));

            //Act
            await errorHandlingMiddleware.Invoke(_httpContext);

            _httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(_httpContext.Response.Body);
            var streamText = reader.ReadToEnd();

            //Assert
            Assert.AreEqual(400, _httpContext.Response.StatusCode);
            StringAssert.Contains("unit test", streamText);
        }

        [Test]
        public async Task HandleExceptions_Exception_ReturnInternalServerError()
        {
            //Arrange
            var errorHandlingMiddleware =
                new ErrorHandlingMiddleware(
                    innerHttpContext => throw new ArgumentException("unit test"));

            //Act
            await errorHandlingMiddleware.Invoke(_httpContext);

            _httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(_httpContext.Response.Body);
            var streamText = reader.ReadToEnd();

            //Assert
            Assert.AreEqual(500, _httpContext.Response.StatusCode);
            StringAssert.Contains("unit test", streamText);
        }
    }
}
