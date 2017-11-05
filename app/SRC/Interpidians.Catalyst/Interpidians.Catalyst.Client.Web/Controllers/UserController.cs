using Interpidians.Catalyst.Client.Web.Common;
using Interpidians.Catalyst.Client.Web.ViewModels;
using Interpidians.Catalyst.Core.ApplicationService;
using Interpidians.Catalyst.Core.Common;
using Interpidians.Catalyst.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interpidians.Catalyst.Client.Web.Controllers
{
    public partial class UserController : BaseController
    {
        private ILogger Logger { get; set; }
        private IUserService UserService { get; set; }

        private UserMaster CurrentUser { get; set; }

        public UserController(ILogger logger, IUserService userService)
        {
            this.Logger = logger;
            this.UserService = userService;
        }
        //
        // GET: /User/

        public virtual ActionResult Index()
        {
            Logger.Info("Hi, This is Prashant");
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
                authUser=UserService.Authenticate(authUser);

                if(authUser == null)
                {
                    ModelState.AddModelError(string.Empty,"Invalid username / password !");
                    return RedirectToAction(MVC.User.ActionNames.LoginRegister, MVC.User.Name);
                    //return RedirectToAction("LoginRegister", new LoginRegisterViewModel() { LoginModel = loginModel });
                }

                if (this.sessionStore.ItemExists(SessionKeys.USER_DETAILS))
                {
                    this.CurrentUser = this.sessionStore.GetItemFromSession<UserMaster>(SessionKeys.USER_DETAILS);
                }
                else
                {
                    this.CurrentUser = this.UserService.GetUserByEmailID(authUser.EmailID);
                    this.sessionStore.SaveItemToSession<UserMaster>(SessionKeys.USER_DETAILS, this.CurrentUser);
                }

                return View(MVC.User.Views.ViewNames.Dashboard);
            }
            else
            {
                return RedirectToAction(MVC.User.ActionNames.LoginRegister, MVC.User.Name);
                //return RedirectToAction("LoginRegister", new LoginRegisterViewModel() { LoginModel = loginModel });
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
                userMaster.ExamMonth = registerModel.ExamMonth;
                userMaster.ExamYear = registerModel.ExamYear;

                UserService.Register(userMaster);

                if (this.sessionStore.ItemExists(SessionKeys.USER_DETAILS))
                {
                    this.CurrentUser = this.sessionStore.GetItemFromSession<UserMaster>(SessionKeys.USER_DETAILS);
                }
                else
                {
                    this.CurrentUser = this.UserService.GetUserByEmailID(userMaster.EmailID);
                    this.sessionStore.SaveItemToSession<UserMaster>(SessionKeys.USER_DETAILS, this.CurrentUser);
                }

                return View(MVC.User.Views.ViewNames.Dashboard);
            }
            else
            {
                return RedirectToAction(MVC.User.ActionNames.LoginRegister, MVC.User.Name);
                //return RedirectToAction("LoginRegister",new LoginRegisterViewModel() { RegisterModel=registerModel});
            }
        }

        [HttpGet]
        public virtual ActionResult Dashboard()
        {
            return View();
        }

        public virtual ActionResult CheckEmailIdAlreadyExists(LoginRegisterViewModel loginRegisterViewModel)
        {
            bool ifEmailExist = false;
            try
            {
                ifEmailExist = UserService.GetAllExistingUserEmailIDs().Contains(loginRegisterViewModel.RegisterModel.EmailID.ToUpper()) ? true : false;
                return Json(!ifEmailExist, JsonRequestBehavior.AllowGet);
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
    }
}
