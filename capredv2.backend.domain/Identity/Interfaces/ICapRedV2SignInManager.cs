using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace capredv2.backend.domain.Identity.Interfaces
{
    public interface ICapRedV2SignInManager<in T> where T : IdentityUser
    {
        Task<SignInResult> PasswordSignInAsync(T user, string password, bool isPersistent, bool lockOutOnFailure);
        Task SignOutAsync();
    }
}
