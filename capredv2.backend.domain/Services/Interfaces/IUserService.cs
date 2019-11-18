using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using capredv2.backend.domain.DatabaseEntities;
using capredv2.backend.domain.DomainEntities.Identity;
using Microsoft.AspNetCore.Identity;

namespace capredv2.backend.domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterAsync(CapRedV2UserSignUpDTO capRedV2UserSignUpDTO);

        Task<Tuple<CapRedV2User, SignInResult>> LoginAsync(CapRedV2UserLoginDTO capRedV2UserLoginDTO);

        Task<IList<string>> GetRolesAsync(CapRedV2User user);
    }
}
