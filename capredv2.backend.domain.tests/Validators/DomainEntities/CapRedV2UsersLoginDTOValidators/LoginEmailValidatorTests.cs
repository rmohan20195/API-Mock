using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Validators.DomainEntities.CapRedV2LoginDTOValidators;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.Validators.DomainEntities.CapRedV2UsersLoginDTOValidators
{
    [TestFixture]
    public class LoginEmailValidatorTests
    {
        private LoginEmailValidator _validator;

        [SetUp]
        public void CreateInstances()
        {
            _validator = new LoginEmailValidator();
        }

        [Test]
        public void Validate_ValidEmail_ReturnsTrue()
        {
            //Arrange
            var userSignUpDTO = new CapRedV2UserLoginDTO
            {
                Email = "test@test.com"
            };

            //Act
            var result = _validator.Validate(userSignUpDTO);

            //Assert
            Assert.IsTrue(result.Item1);
            Assert.IsEmpty(result.Item2);
        }

        [Test]
        public void Validate_InvalidEmail_ReturnsFalse()
        {
            //Arrange
            var userSignUpDTO = new CapRedV2UserLoginDTO
            {
                Email = "test@test"
            };

            //Act
            var result = _validator.Validate(userSignUpDTO);

            //Assert
            Assert.IsFalse(result.Item1);
            StringAssert.Contains(result.Item2, "The email has an invalid format");
        }

        [Test]
        public void Validate_Empty_ReturnsFalse()
        {
            //Arrange
            var userSignUpDTO = new CapRedV2UserLoginDTO
            {
                Email = string.Empty
            };

            //Act
            var result = _validator.Validate(userSignUpDTO);

            //Assert
            Assert.IsFalse(result.Item1);
            StringAssert.Contains(result.Item2, "The email has an invalid format");
        }

        [Test]
        public void Validate_Null_ReturnsFalse()
        {
            //Arrange
            var userSignUpDTO = new CapRedV2UserLoginDTO
            {
                Email = null
            };

            //Act
            var result = _validator.Validate(userSignUpDTO);

            //Assert
            Assert.IsFalse(result.Item1);
            StringAssert.Contains(result.Item2, "The email has an invalid format");
        }
    }
}
