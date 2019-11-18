using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using capredv2.backend.domain.DatabaseEntities;
using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Exceptions;
using capredv2.backend.domain.Identity.Interfaces;
using capredv2.backend.domain.Services;
using capredv2.backend.domain.Validators;
using capredv2.backend.domain.Validators.DomainEntities.Interfaces;
using Microsoft.AspNetCore.Identity;
using NSubstitute;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private UserService _service;
        private ICapRedV2UserManager<CapRedV2User> _userManager;
        private ICapRedV2SignInManager<CapRedV2User> _signInManager;

        [SetUp]
        public void CreateInstances()
        {
            IList<string> roles = new List<string> { "role1", "role2" };

            _userManager = Substitute.For<ICapRedV2UserManager<CapRedV2User>>();
            _userManager.CreateAsync(ValidUser, Arg.Any<string>())
                .Returns(Task.FromResult(new IdentityResult()));

            _userManager.FindByNameAsync(InvalidUser.UserName)
                .Returns((CapRedV2User)null);

            _userManager.FindByNameAsync(ValidUser.UserName)
                .Returns(Task.FromResult(ValidUser));

            _userManager.CheckPasswordAsync(ValidUser, ValidPassword)
                .Returns(Task.FromResult(true));

            _userManager.CheckPasswordAsync(InvalidUser, Arg.Any<string>())
                .Returns(Task.FromResult(false));

            _userManager.CheckPasswordAsync(ValidUser, InvalidPassword)
                .Returns(Task.FromResult(false));

            _userManager.GetRolesAsync(ValidUser)
                .Returns(Task.FromResult(roles));

            _signInManager = Substitute.For<ICapRedV2SignInManager<CapRedV2User>>();

            _signInManager.PasswordSignInAsync(ValidUser, ValidPassword, Arg.Any<bool>(), Arg.Any<bool>())
                .Returns(Task.FromResult(SignInResult.Success));

            _service = new UserService(_userManager, _signInManager, GenerateValidatorEngine<CapRedV2UserSignUpDTO>(),
                GenerateValidatorEngine<CapRedV2UserLoginDTO>());
        }

        [Test]
        public void CreatingInstance_NullUserManager_ThrowArgumentNullException()
        {
            //Arrange
            //Arrange & Act
            var ex = Assert.Throws<ArgumentNullException>(() =>
                // ReSharper disable once ObjectCreationAsStatement
                new UserService(null, _signInManager, GenerateValidatorEngine<CapRedV2UserSignUpDTO>(), GenerateValidatorEngine<CapRedV2UserLoginDTO>()));

            //Assert
            StringAssert.Contains("userManager", ex.Message);
        }

        [Test]
        public void CreatingInstance_NullSignInManager_ThrowArgumentNullException()
        {
            //Arrange
            //Arrange & Act
            var ex = Assert.Throws<ArgumentNullException>(() =>
                // ReSharper disable once ObjectCreationAsStatement
                new UserService(_userManager, null, GenerateValidatorEngine<CapRedV2UserSignUpDTO>(), GenerateValidatorEngine<CapRedV2UserLoginDTO>()));

            //Assert
            StringAssert.Contains("signInManager", ex.Message);
        }

        [Test]
        public void CreatingInstance_signUpValidatorEngine_ThrowArgumentNullException()
        {
            //Arrange
            //Arrange & Act
            var ex = Assert.Throws<ArgumentNullException>(() =>
                // ReSharper disable once ObjectCreationAsStatement
                new UserService(_userManager, _signInManager, null, GenerateValidatorEngine<CapRedV2UserLoginDTO>()));

            //Assert
            StringAssert.Contains("signUpValidatorEngine", ex.Message);
        }

        [Test]
        public void CreatingInstance_LoginValidatorEngine_ThrowArgumentNullException()
        {
            //Arrange
            //Arrange & Act
            var ex = Assert.Throws<ArgumentNullException>(() =>
                // ReSharper disable once ObjectCreationAsStatement
                new UserService(_userManager, _signInManager, GenerateValidatorEngine<CapRedV2UserSignUpDTO>(), null));

            //Assert
            StringAssert.Contains("loginValidatorEngine", ex.Message);
        }

        [Test]
        public void RegisterAsync_ValidEmailAndPassword_ReturnIdentityResult()
        {
            //Arrange
            var capRedV2SignUpDTO = new CapRedV2UserSignUpDTO
            {
                Email = ValidUser.UserName,
                Password = "123",
                ConfirmPassword = "123"
            };

            

            //Act
            var result = _service.RegisterAsync(capRedV2SignUpDTO);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void LoginAsync_ValidEmailAndPassword_ReturnSignInResult()
        {
            //Arrange
            var capRedV2LoginDTO = new CapRedV2UserLoginDTO
            {
                Email = ValidUser.Email,
                Password = ValidPassword
            };

            //Act
            var response = _service.LoginAsync(capRedV2LoginDTO).Result;

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(ValidUser, response.Item1);
            Assert.AreEqual(SignInResult.Success, response.Item2);
        }

        [Test]
        public void LoginAsync_InvalidEmailAndPassword_ThrowBusinessValidationException()
        {
            //Arrange
            var capRedV2LoginDTO = new CapRedV2UserLoginDTO
            {
                Email = InvalidUser.Email,
                Password = InvalidPassword
            };

            //Act
            var ex = Assert.Throws<AggregateException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var result = _service.LoginAsync(capRedV2LoginDTO).Result;
            });

            //Assert
            Assert.IsNotNull(ex);
            Assert.IsNotNull(ex.InnerException);
            Assert.IsInstanceOf<BusinessValidationException>(ex.InnerException);
            StringAssert.Contains("Invalid Login and/or password", ex.InnerException.Message);
        }

        [Test]
        public void GetRolesAsync_ValidUser_ReturnListOfRoles()
        {
            //Act
            var response = _service.GetRolesAsync(ValidUser).Result;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotEmpty(response);
        }

        private const string InvalidPassword = "1234";
        private const string ValidPassword = "Password123!";

        private static readonly CapRedV2User ValidUser = new CapRedV2User { Email = "test@test.com", UserName = "test@test.com" };
        private static readonly CapRedV2User InvalidUser = new CapRedV2User { Email = "invalid@test.com", UserName = "invalid@test.com" };

        private static ValidatorEngine<T> GenerateValidatorEngine<T>()
        {
            return new ValidatorEngine<T>(new List<IDomainEntitiesValidator<T>>());
        }
    }
}
