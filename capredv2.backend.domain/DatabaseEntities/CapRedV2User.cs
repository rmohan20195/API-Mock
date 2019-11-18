using Microsoft.AspNetCore.Identity;

namespace capredv2.backend.domain.DatabaseEntities
{
    public class CapRedV2User : IdentityUser
    {
        public bool? IsActive { get; set; }
    }
}
