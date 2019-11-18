using System;
using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Validators.CommmonFeatures;
using capredv2.backend.domain.Validators.DomainEntities.Interfaces;

namespace capredv2.backend.domain.Validators.DomainEntities.CapRedV2SignUpDTOValidators
{
    public class SignUpPasswordValidator : IDomainEntitiesValidator<CapRedV2UserSignUpDTO>
    {
        public Tuple<bool, string> Validate(CapRedV2UserSignUpDTO entity) =>
            PasswordValidator.IsValid(entity.Password)
                ? new Tuple<bool, string>(true, string.Empty)
                : new Tuple<bool, string>(false, "Password is null or empty");
    }
}
