using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CallManagement.Client.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index() {
            return View();
        }
        public ActionResult Login() {
            return View();
        }

        public void External(string provider) {
            var ctx = Request.GetOwinContext();
            var props = new AuthenticationProperties {
                RedirectUri = "/Login/Callback"
            };
            ctx.Authentication.Challenge(props, "Google");
        }

        public async Task<ActionResult> Callback() {
            //User
            var ctx = Request.GetOwinContext();
            var result = await ctx.Authentication.AuthenticateAsync("External");
            if (result == null) return Redirect("~/Login");

            var claims = result.Identity.Claims;
            var idClaim = claims.First(x => x.Type == ClaimTypes.NameIdentifier);

            var provider = idClaim.Issuer;
            var providerId = idClaim.Value;

            // use provider & providerID to locate user in local DB
            var myclaims = new Claim[]{
                new Claim("id", "123"),
                new Claim("name", "Jaaaared"),
                new Claim("role", "Admin"),
            };
            var ci = new ClaimsIdentity(myclaims, "Cookie", "name", "role");
            ctx.Authentication.SignIn(ci);
            ctx.Authentication.SignOut("External");

            return Redirect("~/Home");
        }
    }
}