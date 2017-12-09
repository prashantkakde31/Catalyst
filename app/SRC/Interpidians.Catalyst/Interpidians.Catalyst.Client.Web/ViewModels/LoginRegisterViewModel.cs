using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Interpidians.Catalyst.Client.Web.ViewModels
{
    public class LoginRegisterViewModel
    {
        public LoginViewModel LoginModel { get; set; }
        public RegisterViewModel RegisterModel { get; set; }
        public ForgotPasswordViewModel ForgotPasswordModel { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; } // nvarchar(50), not null

        [Required]
        public string Password { get; set; } // nvarchar(50), not null
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; } // nvarchar(50), not null

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", ErrorMessage = "Password should contain minimum eight characters, at least one letter, one number and one special character !")]
        public string Password { get; set; } // nvarchar(50), not null

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password and Confirmation Password must match !")]
        public string ConfirmPassword { get; set; } // nvarchar(50), not null

        [Required]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number !")]
        [Remote("CheckMobileNumberAlreadyExists", "User", ErrorMessage = "Mobile number already exists !")]
        public string MobileNumber { get; set; } // nvarchar(50), not null
        [Required]
        [Display(Name = "Email ID")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email ID is not valid !")]
        [Remote("CheckEmailIdAlreadyExists", "User", ErrorMessage = "Email ID already exists !")]
        public string EmailID { get; set; } // nvarchar(50), not null
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "Email ID")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email ID is not valid !")]
        [Remote("CheckEmailIdRegistered", "User", ErrorMessage = "This email id is not registered with us ! kindly register !")]
        public string RegisterEmail { get; set; } // nvarchar(50), not null
    }
}