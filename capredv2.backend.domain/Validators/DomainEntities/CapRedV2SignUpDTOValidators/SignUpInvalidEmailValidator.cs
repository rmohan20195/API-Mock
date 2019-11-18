using System;
using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Validators.CommmonFeatures;
using capredv2.backend.domain.Validators.DomainEntities.Interfaces;

namespace capredv2.backend.domain.Validators.DomainEntities.CapRedV2SignUpDTOValidators
{
    public class SignUpInvalidEmailValidator : IDomainEntitiesValidator<CapRedV2UserSignUpDTO>
    {
        public Tuple<bool, string> Validate(CapRedV2UserSignUpDTO entity)
        {
            var message = string.Empty;

            var result = EmailValidator.IsValid(entity.Email);

            if (!result)
                message = "The email has an invalid format";

            return new Tuple<bool, string>(result, message);
        }
    }
}
