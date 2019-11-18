using System;
using capredv2.backend.domain.DomainEntities.Identity;
using capredv2.backend.domain.Validators.DomainEntities.Interfaces;

namespace capredv2.backend.domain.Validators.DomainEntities.CapRedV2SignUpDTOValidators
{
    public class SignUpPasswordConfirmPasswordMatchValidator : IDomainEntitiesValidator<CapRedV2UserSignUpDTO>
    {
        public Tuple<bool, string> Validate(CapRedV2UserSignUpDTO entity) =>
            entity.Password == entity.ConfirmPassword
                ? new Tuple<bool, string>(true, string.Empty)
                : new Tuple<bool, string>(false, "Passwords don't match");
    }
}
