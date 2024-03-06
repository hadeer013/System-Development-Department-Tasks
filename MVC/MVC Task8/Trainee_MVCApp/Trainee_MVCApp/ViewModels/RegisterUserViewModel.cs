//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Trainee_MVCApp.ViewModels
{
    public class RegisterUserViewModel
    {


        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

    }
}
