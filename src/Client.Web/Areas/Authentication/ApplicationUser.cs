using Microsoft.AspNetCore.Identity;

namespace Client.Web.Areas.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public int? ExternalUserId { get; set; }
        public string Name { get; set; }
    }
}
