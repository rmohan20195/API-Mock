using System;
using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Validators.CommmonFeatures;
using capredv2.backend.domain.Validators.DomainEntities.Interfaces;

namespace capredv2.backend.domain.Validators.DomainEntities.CapRedV2LoginDTOValidators
{
    public class LoginEmailValidator : IDomainEntitiesValidator<CapRedV2UserLoginDTO>
    {
        public Tuple<bool, string> Validate(CapRedV2UserLoginDTO entity)
        {
            var message = string.Empty;

            var result = EmailValidator.IsValid(entity.Email);

            if (!result)
                message = "The email has an invalid format";

            return new Tuple<bool, string>(result, message);
        }
    }
}
