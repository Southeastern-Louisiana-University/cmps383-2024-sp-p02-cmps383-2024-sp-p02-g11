using Microsoft.AspNetCore.Identity;

namespace Selu383.SP24.Api.Features.Users
{
    public class Role : IdentityRole<int>
    {
        public int Id {  get; set; }

        public User User { get; set; }
    }
}
