using Microsoft.AspNetCore.Identity;
using Selu383.SP24.Api.Features.Roles;

namespace Selu383.SP24.Api.Features.Users
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual Role? Role { get; set; }
        public virtual User? User { get; set; }

    }
}