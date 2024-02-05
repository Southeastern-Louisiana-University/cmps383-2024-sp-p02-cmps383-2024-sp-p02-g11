using Microsoft.AspNetCore.Identity;

namespace Selu383.SP24.Api.Features.Users
{
    public class User : IdentityUser<int>
    {
        public int Id { get; set; }

        public Role Role { get; set; }
    }
}
