using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interpidians.Catalyst.Client.Web.ViewModels
{
    public class ManageProfileViewModel
    {
        public ManageProfileViewModel()
        {
            ProfileVM = new ProfileViewModel();
        }
        public ChangePasswordViewModel ChangePasswordVM { get; set; }
        public ProfileViewModel ProfileVM { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; } // nvarchar(50), not null

        [Required]
        [Display(Name = "New Password")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", ErrorMessage = "Password should contain minimum eight characters, at least one letter, one number and one special character !")]
        public string NewPassword { get; set; } // nvarchar(50), not null

        [Required]
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Password and Confirmation Password must match !")]
        public string ConfirmPassword { get; set; } // nvarchar(50), not null
    }
    public class ProfileViewModel
    {
        public int UserID { get; set; }
        public int ProfileID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Addresss { get; set; }
        public string Landline { get; set; }
        public string Mobile { get; set; }
        public string EmailID { get; set; }
    }
}