using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Validators.DomainEntities.CapRedV2LoginDTOValidators;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.Validators.DomainEntities.CapRedV2UsersLoginDTOValidators
{
    [TestFixture]
    public class LoginPasswordValidatorTests
    {
        private LoginPasswordValidator _validator;

        [SetUp]
        public void CreateInstances()
        {
            _validator = new LoginPasswordValidator();
        }

        [Test]
        public void Validate_ValidPassword_ReturnTrue()
        {
            //Arrange
            var userSignUpDTO = new CapRedV2UserLoginDTO
            {
                Password = "123"
            };

            //Act
            var result = _validator.Validate(userSignUpDTO);

            //Assert
            Assert.IsTrue(result.Item1);
            Assert.IsEmpty(result.Item2);
        }

        [Test]
        public void Validate_EmptyPassword_ReturnFalse()
        {
            //Arrange
            var userSignUpDTO = new CapRedV2UserLoginDTO
            {
                Password = string.Empty
            };

            //Act
            var result = _validator.Validate(userSignUpDTO);

            //Assert
            Assert.IsFalse(result.Item1);
            StringAssert.Contains("Password is null or empty", result.Item2);
        }
    }
}
