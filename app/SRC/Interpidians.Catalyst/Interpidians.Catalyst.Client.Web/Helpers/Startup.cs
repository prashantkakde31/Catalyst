using System.Security.Claims;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.Owin.Security.Facebook;
using System.Configuration;

namespace Interpidians.Catalyst.Client.Web.Helpers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            //// Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/User/LoginRegister")
            });

            // these values are stored in CodePasteKeys.json
            // and are NOT included in repro - autocreated on first load
            //if (!string.IsNullOrEmpty(app.Secrets.GoogleClientId))
            //{
            app.UseGoogleAuthentication(
                clientId: ConfigurationManager.AppSettings["GoogleClientId"],
                clientSecret: ConfigurationManager.AppSettings["GoogleClientSecret"]);
            //}

            //app.UseFacebookAuthentication(
            //   appId: "1746282458958349",
            //   appSecret: "8d94b7da136a46feb3f11516457abc1b");

            app.UseFacebookAuthentication(new FacebookAuthenticationOptions
            {
                AppId = ConfigurationManager.AppSettings["FacebookAppId"],
                AppSecret = ConfigurationManager.AppSettings["FacebookAppSecret"],
                BackchannelHttpHandler = new FacebookBackChannelHandler(),
                UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,name,email,first_name,last_name,location",
                Scope = { "email" }
            });

            //if (!string.IsNullOrEmpty(App.Secrets.TwitterConsumerKey))
            //{
            //    app.UseTwitterAuthentication(
            //        consumerKey: App.Secrets.TwitterConsumerKey,
            //        consumerSecret: App.Secrets.TwitterConsumerSecret);
            //}

            //if (!string.IsNullOrEmpty(App.Secrets.GitHubClientId))
            //{
            //    app.UseGitHubAuthentication(
            //        clientId: App.Secrets.GitHubClientId,
            //        clientSecret: App.Secrets.GitHubClientSecret);
            //}

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}