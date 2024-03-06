﻿using System.ComponentModel.DataAnnotations;

namespace Trainee_MVCApp.ViewModels
{
    public class LoginUserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}