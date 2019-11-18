using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Validators.DomainEntities.CapRedV2SignUpDTOValidators;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.Validators.DomainEntities.CapRedV2UsersSignUpDTOValidators
{
    [TestFixture]
    public class SignUpPasswordConfirmPasswordMatchValidatorTests
    {
        private SignUpPasswordConfirmPasswordMatchValidator _validator;

        [SetUp]
        public void CreateInstances()
        {
            _validator = new SignUpPasswordConfirmPasswordMatchValidator();
        }

        [Test]
        public void Validate_PasswordsMatch_ReturnTrue()
        {
            //Arrange
            var userSignDTO = new CapRedV2UserSignUpDTO
            {
                Password = "123",
                ConfirmPassword = "123"
            };

            //Act
            var result = _validator.Validate(userSignDTO);

            //Assert
            Assert.IsTrue(result.Item1);
            Assert.IsEmpty(result.Item2);
        }

        [Test]
        public void Validate_PasswordsDontMatch_ReturnTrue()
        {
            //Arrange
            var userSignDTO = new CapRedV2UserSignUpDTO
            {
                Password = "123",
                ConfirmPassword = "1234"
            };

            //Act
            var result = _validator.Validate(userSignDTO);

            //Assert
            Assert.IsFalse(result.Item1);
            StringAssert.Contains("Passwords don't match", result.Item2);
        }
    }
}
