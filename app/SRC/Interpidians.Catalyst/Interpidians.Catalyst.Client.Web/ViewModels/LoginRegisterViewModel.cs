using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interpidians.Catalyst.Client.Web.ViewModels
{
    public class LoginRegisterViewModel
    {
        //public LoginRegisterViewModel()
        //{
        //    LoginModel = new LoginViewModel();
        //    RegisterModel = new RegisterViewModel();
        //}
        public LoginViewModel LoginModel { get; set; }
        public RegisterViewModel RegisterModel { get; set; }
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
        public string Password { get; set; } // nvarchar(50), not null

        [Required]
        [Display(Name = "Mobile Number")]
        [Remote("CheckMobileNumberAlreadyExists", "User", ErrorMessage = "Mobile number already exists!")]
        public string MobileNumber { get; set; } // nvarchar(50), not null
        [Required]
        [Display(Name = "Email ID")]
        [Remote("CheckEmailIdAlreadyExists", "User", ErrorMessage = "EmailID already exists!")]
        public string EmailID { get; set; } // nvarchar(50), not null
        public int ExamYear { get; set; } // int, not null
        public int ExamMonth { get; set; } // int, not null
    }
}