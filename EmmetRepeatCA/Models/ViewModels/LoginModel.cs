﻿using System.ComponentModel.DataAnnotations;
namespace EmmetRepeatCA.Models.ViewModels
{
    public class LoginModel 
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ReturnUrl { get; set; }
    }
}
