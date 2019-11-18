using System.Threading.Tasks;
using capredv2.backend.domain.DatabaseEntities;
using capredv2.backend.domain.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace capredv2.backend.domain.Identity
{
    public class CapRedV2SignInManager : ICapRedV2SignInManager<CapRedV2User>
    {
        private readonly SignInManager<CapRedV2User> _signInManager;

        public CapRedV2SignInManager(SignInManager<CapRedV2User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> PasswordSignInAsync(CapRedV2User user, string password, bool isPersistent, bool lockOutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(user, password, isPersistent, lockOutOnFailure);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
