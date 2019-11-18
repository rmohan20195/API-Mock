using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace capredv2.backend.domain.Identity.Interfaces
{
    public interface ICapRedV2UserManager<T> where T : IdentityUser
    {
        Task<IdentityResult> CreateAsync(T user, string password);
        Task<T> FindByNameAsync(string userName);
        Task<bool> CheckPasswordAsync(T user, string password);
        Task<IList<string>> GetRolesAsync(T user);
    }
}
