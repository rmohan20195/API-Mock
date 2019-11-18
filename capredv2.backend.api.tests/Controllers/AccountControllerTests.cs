using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using capredv2.backend.api.Controllers;
using capredv2.backend.domain.DatabaseEntities;
using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace capredv2.backend.api.tests.Controllers
{
    [TestFixture]
    public class AccountControllerTests
    {
        private AccountController _controller;

        [SetUp]
        public void CreateInstances()
        {
            _controller = new AccountController(CreateUserService(), CreateConfiguration());
        }

        [Test]
        public void Register_ValidValuesAndSuccessResultFromService_ReturnOk()
        {
            //Act
            var result = _controller.Register(GoodUserSignUpDTO).Result as OkResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Register_ValidValuesAndFailureFromService_ReturnOk()
        {
            //Act
            var result = _controller.Register(FailureUserSignUpDTO).Result as BadRequestObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            StringAssert.Contains("An error occurred when creating the user, see nested errors", result.Value.ToString());
        }

        [Test]
        public void Token_ValidValuesAndFailureFromService_ReturnBadRequestWithMessageFromException()
        {
            //Act
            var result =
                _controller.Token(FailureUserLoginDTO).Result as BadRequestObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            StringAssert.Contains("Invalid Login and/or password", result.Value.ToString());
        }

        [Test]
        public void Token_ValidValues_ReturnTokenObjectAsResult()
        {
            //Act
            var result = _controller.Token(GoodUserLoginDTO).Result as ObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);

        }

        private const string GoodEmail = "goodemail@domain.com";
        private const string GoodPassword = "Password123!";
        private const string GoodConfirmPassword = "Password123!";

        private static readonly CapRedV2UserSignUpDTO GoodUserSignUpDTO = new CapRedV2UserSignUpDTO
        {
            Email = GoodEmail,
            Password = GoodPassword,
            ConfirmPassword = GoodConfirmPassword
        };

        private static readonly CapRedV2UserLoginDTO GoodUserLoginDTO = new CapRedV2UserLoginDTO
        {
            Email = GoodEmail,
            Password = GoodPassword
        };

        private const string FailureEmail = "failureemail@domain.com";
        private const string FailurePassword = "Failed123!";
        private const string FailureConfirmPassword = "Failed123!";

        private static readonly CapRedV2UserSignUpDTO FailureUserSignUpDTO = new CapRedV2UserSignUpDTO
        {
            Email = FailureEmail,
            Password = FailurePassword,
            ConfirmPassword = FailureConfirmPassword
        };

        private static readonly CapRedV2UserLoginDTO FailureUserLoginDTO = new CapRedV2UserLoginDTO
        {
            Email = FailureEmail,
            Password = FailurePassword
        };

        private static readonly CapRedV2User ValidUser = new CapRedV2User { Email = "test@test.com", UserName = "test@test.com" };

        private static IUserService CreateUserService()
        {
            IList<string> roles = new List<string> { "role1", "role2" };

            var userService = Substitute.For<IUserService>();

            userService.RegisterAsync(GoodUserSignUpDTO)
                .Returns(Task.FromResult(IdentityResult.Success));

            userService.RegisterAsync(FailureUserSignUpDTO)
                .Returns(Task.FromResult(IdentityResult.Failed()));

            userService.LoginAsync(FailureUserLoginDTO)
                .Returns(Task.FromResult(new Tuple<CapRedV2User, SignInResult>(null, SignInResult.Failed)));

            userService.LoginAsync(GoodUserLoginDTO)
                .Returns(Task.FromResult(new Tuple<CapRedV2User, SignInResult>(ValidUser, SignInResult.Success)));

            userService.GetRolesAsync(ValidUser)
                .Returns(Task.FromResult(roles));

            return userService;
        }

        private static IConfiguration CreateConfiguration()
        {
            var configuration = Substitute.For<IConfiguration>();

            return configuration;
        }
    }
}
