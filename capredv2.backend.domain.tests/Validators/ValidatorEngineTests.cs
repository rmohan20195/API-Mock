using System;
using System.Collections.Generic;
using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Exceptions;
using capredv2.backend.domain.Validators;
using capredv2.backend.domain.Validators.DomainEntities.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.Validators
{
    [TestFixture]
    public class ValidatorEngineTests
    {
        private readonly IDomainEntitiesValidator<CapRedV2UserSignUpDTO> _validatorTest1 =
            Substitute.For<IDomainEntitiesValidator<CapRedV2UserSignUpDTO>>();

        private readonly IDomainEntitiesValidator<CapRedV2UserSignUpDTO> _validatorTest2 =
            Substitute.For<IDomainEntitiesValidator<CapRedV2UserSignUpDTO>>();

        [Test]
        public void Validate_TestingOneValidatorThatReturnsTrue_ReturnsTrue()
        {
            //Arrange
            _validatorTest1.Validate(Arg.Any<CapRedV2UserSignUpDTO>()).Returns(new Tuple<bool, string>(true, string.Empty));

            IList<IDomainEntitiesValidator<CapRedV2UserSignUpDTO>> domainEntityValidators = new List
                <IDomainEntitiesValidator<CapRedV2UserSignUpDTO>>
                {
                    _validatorTest1
                };

            var validatorEngine = new ValidatorEngine<CapRedV2UserSignUpDTO>(domainEntityValidators);

            //Act
            validatorEngine.Validate(new CapRedV2UserSignUpDTO());

            //Assert
            _validatorTest1.Received().Validate(Arg.Any<CapRedV2UserSignUpDTO>());
        }

        [Test]
        public void Validate_TestingTwoValidatorsThatReturnTrue_ReturnsTrue()
        {
            //Arrange
            _validatorTest1.Validate(Arg.Any<CapRedV2UserSignUpDTO>()).Returns(new Tuple<bool, string>(true, string.Empty));
            _validatorTest2.Validate(Arg.Any<CapRedV2UserSignUpDTO>()).Returns(new Tuple<bool, string>(true, string.Empty));

            IList<IDomainEntitiesValidator<CapRedV2UserSignUpDTO>> domainEntityValidators = new List
                <IDomainEntitiesValidator<CapRedV2UserSignUpDTO>>
                {
                    _validatorTest1,
                    _validatorTest2
                };

            var validatorEngine = new ValidatorEngine<CapRedV2UserSignUpDTO>(domainEntityValidators);

            //Act
            validatorEngine.Validate(new CapRedV2UserSignUpDTO());

            //Assert
            _validatorTest1.Received().Validate(Arg.Any<CapRedV2UserSignUpDTO>());
            _validatorTest2.Received().Validate(Arg.Any<CapRedV2UserSignUpDTO>());
        }

        [Test]
        public void Validate_TestingTwoValidatorsOneReturnsTrueAndOneReturnsFalseAndMessage_ThrowsExceptionWithMessage()
        {
            //Arrange
            _validatorTest1.Validate(Arg.Any<CapRedV2UserSignUpDTO>()).Returns(new Tuple<bool, string>(true, string.Empty));
            _validatorTest2.Validate(Arg.Any<CapRedV2UserSignUpDTO>()).Returns(new Tuple<bool, string>(false, "Error message"));

            IList<IDomainEntitiesValidator<CapRedV2UserSignUpDTO>> domainEntityValidators = new List
                <IDomainEntitiesValidator<CapRedV2UserSignUpDTO>>
                {
                    _validatorTest1,
                    _validatorTest2
                };

            var validatorEngine = new ValidatorEngine<CapRedV2UserSignUpDTO>(domainEntityValidators);

            //Act
            var exception = Assert.Throws<BusinessValidationException>(() => validatorEngine.Validate(new CapRedV2UserSignUpDTO()));

            //Assert
            _validatorTest1.Received().Validate(Arg.Any<CapRedV2UserSignUpDTO>());
            _validatorTest2.Received().Validate(Arg.Any<CapRedV2UserSignUpDTO>());
            StringAssert.Contains(exception.Message, "Error message");
        }

        [Test]
        public void Validate_TestingTwoValidatorsThatReturnFalseAndMessage_ThrowsExceptionWithMessagesFromBothValidators()
        {
            const string errorMessage1 = "Error message validator 1";
            const string errorMessage2 = "Error message validator 2";

            //Arrange
            _validatorTest1.Validate(Arg.Any<CapRedV2UserSignUpDTO>()).Returns(new Tuple<bool, string>(false, errorMessage1));
            _validatorTest2.Validate(Arg.Any<CapRedV2UserSignUpDTO>()).Returns(new Tuple<bool, string>(false, errorMessage2));

            IList<IDomainEntitiesValidator<CapRedV2UserSignUpDTO>> domainEntityValidators = new List
                <IDomainEntitiesValidator<CapRedV2UserSignUpDTO>>
                {
                    _validatorTest1,
                    _validatorTest2
                };

            var validatorEngine = new ValidatorEngine<CapRedV2UserSignUpDTO>(domainEntityValidators);

            //Act
            var exception = Assert.Throws<BusinessValidationException>(() => validatorEngine.Validate(new CapRedV2UserSignUpDTO()));

            //Assert
            _validatorTest1.Received().Validate(Arg.Any<CapRedV2UserSignUpDTO>());
            _validatorTest2.Received().Validate(Arg.Any<CapRedV2UserSignUpDTO>());
            StringAssert.Contains(errorMessage1, exception.Message);
            StringAssert.Contains(errorMessage2, exception.Message);
        }
    }
}
