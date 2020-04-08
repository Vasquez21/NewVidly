﻿using System.ComponentModel.DataAnnotations;

namespace NewVidly.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}