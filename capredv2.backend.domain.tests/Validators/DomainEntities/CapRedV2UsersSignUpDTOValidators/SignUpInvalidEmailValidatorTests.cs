using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Validators.DomainEntities.CapRedV2SignUpDTOValidators;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.Validators.DomainEntities.CapRedV2UsersSignUpDTOValidators
{
    [TestFixture]
    public class SignUpInvalidEmailValidatorTests
    {
        private SignUpInvalidEmailValidator _validator;

        [SetUp]
        public void CreateInstances()
        {
            _validator = new SignUpInvalidEmailValidator();
        }

        [Test]
        public void Validate_ValidEmail_ReturnsTrue()
        {
            //Arrange
            var userSignUpDTO = new CapRedV2UserSignUpDTO
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
            var userSignUpDTO = new CapRedV2UserSignUpDTO
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
            var userSignUpDTO = new CapRedV2UserSignUpDTO
            {
                Email = string.Empty
            };

            //Act
            var result = _validator.Validate(userSignUpDTO);

            //Assert
            Assert.IsFalse(result.Item1);
            StringAssert.Contains(result.Item2, "The email has an invalid format");
        }
    }
}

