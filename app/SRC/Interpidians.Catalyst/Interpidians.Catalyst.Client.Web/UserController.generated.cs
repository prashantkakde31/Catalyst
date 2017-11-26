// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Interpidians.Catalyst.Client.Web.Controllers
{
    public partial class UserController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected UserController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult CheckEmailIdAlreadyExists()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckEmailIdAlreadyExists);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult CheckEmailIdRegistered()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckEmailIdRegistered);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult CheckMobileNumberAlreadyExists()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckMobileNumberAlreadyExists);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ExternalLogin()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLogin);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ExternalLoginCallback()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLoginCallback);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Login()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Register()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Register);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ForgotPassword()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ForgotPassword);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public UserController Actions { get { return MVC.User; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "User";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "User";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string CheckEmailIdAlreadyExists = "CheckEmailIdAlreadyExists";
            public readonly string CheckEmailIdRegistered = "CheckEmailIdRegistered";
            public readonly string CheckMobileNumberAlreadyExists = "CheckMobileNumberAlreadyExists";
            public readonly string ExternalLogin = "ExternalLogin";
            public readonly string ExternalLoginCallback = "ExternalLoginCallback";
            public readonly string Index = "Index";
            public readonly string LoginRegister = "LoginRegister";
            public readonly string Login = "Login";
            public readonly string Register = "Register";
            public readonly string ForgotPassword = "ForgotPassword";
            public readonly string LogOff = "LogOff";
            public readonly string Dashboard = "Dashboard";
            public readonly string Home = "Home";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string CheckEmailIdAlreadyExists = "CheckEmailIdAlreadyExists";
            public const string CheckEmailIdRegistered = "CheckEmailIdRegistered";
            public const string CheckMobileNumberAlreadyExists = "CheckMobileNumberAlreadyExists";
            public const string ExternalLogin = "ExternalLogin";
            public const string ExternalLoginCallback = "ExternalLoginCallback";
            public const string Index = "Index";
            public const string LoginRegister = "LoginRegister";
            public const string Login = "Login";
            public const string Register = "Register";
            public const string ForgotPassword = "ForgotPassword";
            public const string LogOff = "LogOff";
            public const string Dashboard = "Dashboard";
            public const string Home = "Home";
        }


        static readonly ActionParamsClass_CheckEmailIdAlreadyExists s_params_CheckEmailIdAlreadyExists = new ActionParamsClass_CheckEmailIdAlreadyExists();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CheckEmailIdAlreadyExists CheckEmailIdAlreadyExistsParams { get { return s_params_CheckEmailIdAlreadyExists; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CheckEmailIdAlreadyExists
        {
            public readonly string loginRegisterViewModel = "loginRegisterViewModel";
        }
        static readonly ActionParamsClass_CheckEmailIdRegistered s_params_CheckEmailIdRegistered = new ActionParamsClass_CheckEmailIdRegistered();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CheckEmailIdRegistered CheckEmailIdRegisteredParams { get { return s_params_CheckEmailIdRegistered; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CheckEmailIdRegistered
        {
            public readonly string loginRegisterViewModel = "loginRegisterViewModel";
        }
        static readonly ActionParamsClass_CheckMobileNumberAlreadyExists s_params_CheckMobileNumberAlreadyExists = new ActionParamsClass_CheckMobileNumberAlreadyExists();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CheckMobileNumberAlreadyExists CheckMobileNumberAlreadyExistsParams { get { return s_params_CheckMobileNumberAlreadyExists; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CheckMobileNumberAlreadyExists
        {
            public readonly string loginRegisterViewModel = "loginRegisterViewModel";
        }
        static readonly ActionParamsClass_ExternalLogin s_params_ExternalLogin = new ActionParamsClass_ExternalLogin();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ExternalLogin ExternalLoginParams { get { return s_params_ExternalLogin; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ExternalLogin
        {
            public readonly string provider = "provider";
        }
        static readonly ActionParamsClass_ExternalLoginCallback s_params_ExternalLoginCallback = new ActionParamsClass_ExternalLoginCallback();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ExternalLoginCallback ExternalLoginCallbackParams { get { return s_params_ExternalLoginCallback; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ExternalLoginCallback
        {
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ActionParamsClass_Login s_params_Login = new ActionParamsClass_Login();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Login LoginParams { get { return s_params_Login; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Login
        {
            public readonly string loginModel = "loginModel";
        }
        static readonly ActionParamsClass_Register s_params_Register = new ActionParamsClass_Register();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Register RegisterParams { get { return s_params_Register; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Register
        {
            public readonly string registerModel = "registerModel";
        }
        static readonly ActionParamsClass_ForgotPassword s_params_ForgotPassword = new ActionParamsClass_ForgotPassword();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ForgotPassword ForgotPasswordParams { get { return s_params_ForgotPassword; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ForgotPassword
        {
            public readonly string forgotPasswordModel = "forgotPasswordModel";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string Dashboard = "Dashboard";
                public readonly string Home = "Home";
                public readonly string Index = "Index";
                public readonly string LoginRegister = "LoginRegister";
            }
            public readonly string Dashboard = "~/Views/User/Dashboard.cshtml";
            public readonly string Home = "~/Views/User/Home.cshtml";
            public readonly string Index = "~/Views/User/Index.cshtml";
            public readonly string LoginRegister = "~/Views/User/LoginRegister.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_UserController : Interpidians.Catalyst.Client.Web.Controllers.UserController
    {
        public T4MVC_UserController() : base(Dummy.Instance) { }

        [NonAction]
        partial void CheckEmailIdAlreadyExistsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Interpidians.Catalyst.Client.Web.ViewModels.LoginRegisterViewModel loginRegisterViewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult CheckEmailIdAlreadyExists(Interpidians.Catalyst.Client.Web.ViewModels.LoginRegisterViewModel loginRegisterViewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckEmailIdAlreadyExists);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "loginRegisterViewModel", loginRegisterViewModel);
            CheckEmailIdAlreadyExistsOverride(callInfo, loginRegisterViewModel);
            return callInfo;
        }

        [NonAction]
        partial void CheckEmailIdRegisteredOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Interpidians.Catalyst.Client.Web.ViewModels.LoginRegisterViewModel loginRegisterViewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult CheckEmailIdRegistered(Interpidians.Catalyst.Client.Web.ViewModels.LoginRegisterViewModel loginRegisterViewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckEmailIdRegistered);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "loginRegisterViewModel", loginRegisterViewModel);
            CheckEmailIdRegisteredOverride(callInfo, loginRegisterViewModel);
            return callInfo;
        }

        [NonAction]
        partial void CheckMobileNumberAlreadyExistsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Interpidians.Catalyst.Client.Web.ViewModels.LoginRegisterViewModel loginRegisterViewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult CheckMobileNumberAlreadyExists(Interpidians.Catalyst.Client.Web.ViewModels.LoginRegisterViewModel loginRegisterViewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckMobileNumberAlreadyExists);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "loginRegisterViewModel", loginRegisterViewModel);
            CheckMobileNumberAlreadyExistsOverride(callInfo, loginRegisterViewModel);
            return callInfo;
        }

        [NonAction]
        partial void ExternalLoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string provider);

        [NonAction]
        public override System.Web.Mvc.ActionResult ExternalLogin(string provider)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLogin);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "provider", provider);
            ExternalLoginOverride(callInfo, provider);
            return callInfo;
        }

        [NonAction]
        partial void ExternalLoginCallbackOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLoginCallback);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ExternalLoginCallbackOverride(callInfo, returnUrl);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void LoginRegisterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult LoginRegister()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.LoginRegister);
            LoginRegisterOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void LoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Interpidians.Catalyst.Client.Web.ViewModels.LoginViewModel loginModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult Login(Interpidians.Catalyst.Client.Web.ViewModels.LoginViewModel loginModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "loginModel", loginModel);
            LoginOverride(callInfo, loginModel);
            return callInfo;
        }

        [NonAction]
        partial void RegisterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Interpidians.Catalyst.Client.Web.ViewModels.RegisterViewModel registerModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult Register(Interpidians.Catalyst.Client.Web.ViewModels.RegisterViewModel registerModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Register);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "registerModel", registerModel);
            RegisterOverride(callInfo, registerModel);
            return callInfo;
        }

        [NonAction]
        partial void ForgotPasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Interpidians.Catalyst.Client.Web.ViewModels.ForgotPasswordViewModel forgotPasswordModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult ForgotPassword(Interpidians.Catalyst.Client.Web.ViewModels.ForgotPasswordViewModel forgotPasswordModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ForgotPassword);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "forgotPasswordModel", forgotPasswordModel);
            ForgotPasswordOverride(callInfo, forgotPasswordModel);
            return callInfo;
        }

        [NonAction]
        partial void LogOffOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult LogOff()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.LogOff);
            LogOffOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void DashboardOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Dashboard()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Dashboard);
            DashboardOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void HomeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Home()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Home);
            HomeOverride(callInfo);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
