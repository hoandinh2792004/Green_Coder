﻿using System.ComponentModel.DataAnnotations;

namespace Web_bestcoder.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Old Password is required!")]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New Password is required!")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        [Compare("ConfirmNewPassword", ErrorMessage = "Password does not match!")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password is required!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; }
    }

}
