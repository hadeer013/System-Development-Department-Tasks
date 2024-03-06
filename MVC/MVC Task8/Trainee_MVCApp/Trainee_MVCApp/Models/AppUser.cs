using Microsoft.AspNetCore.Identity;

namespace Trainee_MVCApp.Models
{
    public class AppUser:IdentityUser
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
    }
}
