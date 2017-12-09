using Interpidians.Catalyst.Client.Web.Common;
using Interpidians.Catalyst.Client.Web.ViewModels;
using Interpidians.Catalyst.Core.ApplicationService;
using Interpidians.Catalyst.Core.Common;
using Interpidians.Catalyst.Core.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Interpidians.Catalyst.Client.Web.Controllers
{
    public partial class UserController : BaseController
    {
        #region Variables
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "Catalyst_$31!.2*#";
        #endregion

        #region Properties
        private ILogger Logger { get; set; }
        private IMailer Mailer { get; set; }
        private IUserService UserService { get; set; }
        private UserMaster CurrentUser { get; set; }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        #endregion

        #region Constructor
        public UserController(ILogger logger, IMailer mailer,IUserService userService)
        {
            this.Logger = logger;
            this.Mailer = mailer;
            this.UserService = userService;
        }

        #endregion

        #region Methods
        public void IdentitySignin(string userId, string name, bool isPersistent = false)
        {
            var claims = new List<Claim>();

            // create *required* claims
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userId));
            claims.Add(new Claim(ClaimTypes.Name, name));
            claims.Add(new Claim(ClaimTypes.Email, userId));

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            // add to user here!
            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = isPersistent,
                ExpiresUtc = DateTime.UtcNow.AddDays(1)
            }, identity);
        }

        public void IdentitySignout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie,
                                          DefaultAuthenticationTypes.ExternalCookie);
        }
        #endregion

        #region Remote Validation
        public virtual ActionResult CheckEmailIdAlreadyExists(LoginRegisterViewModel loginRegisterViewModel)
        {
            bool ifEmailIDExist = false;
            try
            {
                ifEmailIDExist = UserService.GetAllExistingUserEmailIDs().Contains(loginRegisterViewModel.RegisterModel.EmailID.ToUpper()) ? true : false;
                return Json(!ifEmailIDExist, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public virtual ActionResult CheckEmailIdRegistered(LoginRegisterViewModel loginRegisterViewModel)
        {
            bool isEmailIDRegistered = false;
            try
            {
                isEmailIDRegistered = UserService.GetAllExistingUserEmailIDs().Contains(loginRegisterViewModel.ForgotPasswordModel.RegisterEmail.ToUpper()) ? true : false;
                return Json(isEmailIDRegistered, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public virtual ActionResult CheckMobileNumberAlreadyExists(LoginRegisterViewModel loginRegisterViewModel)
        {
            bool ifEmailExist = false;
            try
            {
                ifEmailExist = UserService.GetAllMobileNumber().Contains(loginRegisterViewModel.RegisterModel.MobileNumber.ToUpper()) ? true : false;
                return Json(!ifEmailExist, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region External Login Code
        public class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            { }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                    properties.Dictionary[XsrfKey] = UserId;

                var owin = context.HttpContext.GetOwinContext();
                owin.Authentication.Challenge(properties, LoginProvider);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public virtual ActionResult ExternalLogin(string provider)
        {
            string returnUrl = Url.Action(MVC.User.ActionNames.Dashboard, MVC.User.Name, null);
            return new ChallengeResult(provider, Url.Action(MVC.User.ActionNames.ExternalLoginCallback,
                                       MVC.User.Name, new { ReturnUrl = returnUrl }));
        }

        [AllowAnonymous]
        public virtual async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl))
                returnUrl = "~/";

            var ctx = Request.GetOwinContext();
            var result = ctx.Authentication.AuthenticateAsync("ExternalCookie").Result;

            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
                return RedirectToAction(MVC.User.ActionNames.LoginRegister,MVC.User.Name);

            // AUTHENTICATED!
            var providerKey = loginInfo.Login.ProviderKey;

            // Register external user if not exists
            UserMaster externalUser= UserService.GetUserByEmailID(loginInfo.Email);
            if(externalUser == null) {
                UserService.Register(new UserMaster()
                {
                    UserName = loginInfo.DefaultUserName,
                    EmailID = loginInfo.Email,
                    IsExternalUser = true,
                    ExternalLoginProvider = loginInfo.Login.LoginProvider,
                    ProviderKey = loginInfo.Login.ProviderKey,
                    IsRegistrationComplete = false
                });

                externalUser = UserService.GetUserByEmailID(loginInfo.Email);
            }

            

            if (this.sessionStore.ItemExists(SessionKeys.USER_DETAILS) && this.sessionStore.GetItemFromSession<UserMaster>(SessionKeys.USER_DETAILS).UserName == externalUser.UserName)
            {
                this.CurrentUser = this.sessionStore.GetItemFromSession<UserMaster>(SessionKeys.USER_DETAILS);
            }
            else
            {
                this.CurrentUser = this.UserService.GetUserByEmailID(externalUser.EmailID);
                this.sessionStore.SaveItemToSession<UserMaster>(SessionKeys.USER_DETAILS, this.CurrentUser);
            }

            // when all good make sure to sign in user
            //IdentitySignin(loginInfo.Email, loginInfo.DefaultUserName, isPersistent: true);

            return Redirect(returnUrl);
        }
        #endregion

        #region Actions
        public virtual ActionResult Index()
        {
            //Logger.Info("Hi, This is Prashant");
            return View(MVC.User.Views.ViewNames.Index);
            //return View();
        }

        [HttpGet]
        [RestoreModelStateFromTempData]
        public virtual ActionResult LoginRegister()
        {
            return View(MVC.User.Views.ViewNames.LoginRegister, new LoginRegisterViewModel());
            //return View("LoginRegister", new LoginRegisterViewModel());
        }

        [HttpPost]
        [SetTempDataModelState]
        //[IgnoreModelErrors("EmailID, MobileNumber")]
        public virtual ActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                UserMaster authUser = new UserMaster();
                authUser.UserName = loginModel.UserName;
                authUser.EmailID = loginModel.UserName;
                authUser.MobileNumber = loginModel.UserName;
                authUser.Password = loginModel.Password;

                //authenticate user
                authUser = UserService.Authenticate(authUser);

                if (authUser == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid username / password !");
                    return RedirectToAction(MVC.User.ActionNames.LoginRegister, MVC.User.Name);
                }

                if (this.sessionStore.ItemExists(SessionKeys.USER_DETAILS) && this.sessionStore.GetItemFromSession<UserMaster>(SessionKeys.USER_DETAILS).UserName == authUser.UserName)
                {
                    this.CurrentUser = this.sessionStore.GetItemFromSession<UserMaster>(SessionKeys.USER_DETAILS);
                }
                else
                {
                    this.CurrentUser = this.UserService.GetUserByEmailID(authUser.EmailID);
                    this.sessionStore.SaveItemToSession<UserMaster>(SessionKeys.USER_DETAILS, this.CurrentUser);
                }

                //IdentitySignin(this.CurrentUser.EmailID, this.CurrentUser.UserName, isPersistent: true);

                return View(MVC.User.Views.ViewNames.Dashboard);
            }
            else
            {
                return RedirectToAction(MVC.User.ActionNames.LoginRegister, MVC.User.Name);
            }
        }

        [HttpPost]
        [SetTempDataModelState]
        public virtual ActionResult Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                UserMaster userMaster = new UserMaster();
                userMaster.UserName = registerModel.UserName;
                userMaster.Password = registerModel.Password;
                userMaster.EmailID = registerModel.EmailID;
                userMaster.MobileNumber = registerModel.MobileNumber;

                UserService.Register(userMaster);

                if (this.sessionStore.ItemExists(SessionKeys.USER_DETAILS) && this.sessionStore.GetItemFromSession<UserMaster>(SessionKeys.USER_DETAILS).UserName == userMaster.UserName)
                {
                    this.CurrentUser = this.sessionStore.GetItemFromSession<UserMaster>(SessionKeys.USER_DETAILS);
                }
                else
                {
                    this.CurrentUser = this.UserService.GetUserByEmailID(userMaster.EmailID);
                    this.sessionStore.SaveItemToSession<UserMaster>(SessionKeys.USER_DETAILS, this.CurrentUser);
                }

                //IdentitySignin(this.CurrentUser.EmailID, this.CurrentUser.UserName, isPersistent: true);

                return View(MVC.User.Views.ViewNames.Dashboard);
            }
            else
            {
                return RedirectToAction(MVC.User.ActionNames.LoginRegister, MVC.User.Name);
            }
        }

        [HttpPost]
        [SetTempDataModelState]
        public virtual ActionResult ForgotPassword(ForgotPasswordViewModel forgotPasswordModel)
        {
            UserMaster user = this.UserService.GetUserByEmailID(forgotPasswordModel.RegisterEmail);
            bool isMailSent=false;

            try
            {
                isMailSent = Mailer.Send(user.EmailID, "Catalyst Password", $"Hi {user.UserName},<br/> Your password is {user.Password}");
            }
            catch (Exception ex)
            {
                Logger.Info("Error:-" + ex.ToString());
            }
             
            if (isMailSent)
            {
                ModelState.AddModelError(string.Empty, "Your password has been sent to registered mail address");
                Logger.Info("Mail Sent");
            } 
            return RedirectToAction(MVC.User.ActionNames.LoginRegister, MVC.User.Name);
        }
        public virtual ActionResult LogOff()
        {
            //IdentitySignout();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction(MVC.User.ActionNames.LoginRegister, MVC.User.Name);
        }

        [HttpGet]
        public virtual ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        [SetTempDataModelState]
        //[AuthorizeAction]
        public virtual ActionResult Me()
        {
            if (!this.sessionStore.ItemExists(SessionKeys.USER_DETAILS))
            {
                ModelState.AddModelError(string.Empty, "Session Expired ! Login again !");
                return RedirectToAction(MVC.User.ActionNames.LoginRegister, MVC.User.Name);
            }
            UserMaster user = this.sessionStore.GetItemFromSession<UserMaster>(SessionKeys.USER_DETAILS);
            UserProfile userProfile = this.UserService.GetProfileDetails(new IdentifiableData() { Id = user.UserID });
            ManageProfileViewModel manageProfileVM = new ManageProfileViewModel();
            manageProfileVM.ProfileVM.UserID = user.UserID;
            manageProfileVM.ProfileVM.EmailID = user.EmailID;
            manageProfileVM.ProfileVM.ProfileID = userProfile.ProfileID;
            manageProfileVM.ProfileVM.FirstName = userProfile.FirstName;
            manageProfileVM.ProfileVM.LastName = userProfile.LastName;
            manageProfileVM.ProfileVM.Landline = userProfile.LandlineNo;
            manageProfileVM.ProfileVM.Mobile = userProfile.MobileNo;
            manageProfileVM.ProfileVM.Addresss = userProfile.AddrLine1;
            return View(MVC.User.Views.Me,manageProfileVM);
        }

        [HttpPost]
        public virtual JsonResult ChangePassword(ChangePasswordViewModel changePasswordVM)
        {
            UserMaster user = this.sessionStore.GetItemFromSession<UserMaster>(SessionKeys.USER_DETAILS);
            if (user.Password.Equals(changePasswordVM.OldPassword) || user.IsExternalUser==true)
            {
                user.Password = changePasswordVM.NewPassword;
                this.UserService.UpdateUserMaster(user);
                return Json("Password changed successfully !");
            }
            else
            {
                return Json("Please enter correct old password !");
            }
        }

        [HttpPost]
        public virtual JsonResult ManageProfile(ProfileViewModel profileVM)
        {
            UserProfile userProfile = this.UserService.GetProfileDetails(new IdentifiableData() { Id = profileVM.UserID });
            userProfile.FirstName = profileVM.FirstName;
            userProfile.LastName = profileVM.LastName;
            userProfile.LandlineNo = profileVM.Landline;
            userProfile.MobileNo = profileVM.Mobile;
            userProfile.AddrLine1 = profileVM.Addresss;
            this.UserService.UpdateProfile(userProfile);
            return Json("Profile has been updated successfully !");
        }
            #endregion

        }
}
