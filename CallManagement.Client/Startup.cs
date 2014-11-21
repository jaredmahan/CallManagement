using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;

[assembly: OwinStartupAttribute(typeof(CallManagement.Client.Startup))]
namespace CallManagement.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var external = new CookieAuthenticationOptions {
                AuthenticationType = "External",
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Passive
            };
            app.UseCookieAuthentication(external);

            var google = new GoogleOAuth2AuthenticationOptions {
                AuthenticationType = "Google",
                ClientId = "932213957859-48m9k25fdl5kmrjjh1m4t6dutl4391oa.apps.googleusercontent.com",
                ClientSecret = "jZzZ2z76rz_VJ8W_XUWbgOnM",
                SignInAsAuthenticationType = "External",
                //CallbackPath = "/google"
            };
            google.Scope.Clear();
            google.Scope.Add("openid");
            google.Scope.Add("email");
            google.Scope.Add("profile");
            app.UseGoogleAuthentication(google);
        }
    }
}
