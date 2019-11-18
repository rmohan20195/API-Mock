using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Validators.DomainEntities.CapRedV2SignUpDTOValidators;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.Validators.DomainEntities.CapRedV2UsersSignUpDTOValidators
{
    [TestFixture]
    public class SignUpPasswordValidatorTests
    {
        private SignUpPasswordValidator _validator;

        [SetUp]
        public void CreateInstances()
        {
            _validator = new SignUpPasswordValidator();
        }

        [Test]
        public void Validate_ValidPassword_ReturnTrue()
        {
            //Arrange
            var userSignUpDTO = new CapRedV2UserSignUpDTO
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
            var userSignUpDTO = new CapRedV2UserSignUpDTO
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
