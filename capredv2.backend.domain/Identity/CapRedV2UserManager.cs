using System.Collections.Generic;
using System.Threading.Tasks;
using capredv2.backend.domain.DatabaseEntities;
using capredv2.backend.domain.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace capredv2.backend.domain.Identity
{
    public class CapRedV2UserManager : ICapRedV2UserManager<CapRedV2User>
    {
        private readonly UserManager<CapRedV2User> _userManager;

        public CapRedV2UserManager(UserManager<CapRedV2User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(CapRedV2User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<CapRedV2User> FindByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<bool> CheckPasswordAsync(CapRedV2User user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public Task<IList<string>> GetRolesAsync(CapRedV2User user)
        {
            return _userManager.GetRolesAsync(user);
        }
    }
}
