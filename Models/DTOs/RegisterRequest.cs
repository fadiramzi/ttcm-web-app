﻿using System.ComponentModel.DataAnnotations;

namespace ttcm_mvc.Models.DTOs
{
    public class RegisterRequest
    {
        [Required]
        
        public string UserName { get; set; }

        [Required] public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
