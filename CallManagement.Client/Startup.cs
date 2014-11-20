using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CallManagement.Client.Startup))]
namespace CallManagement.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
