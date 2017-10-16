using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PingYourPackage.API.Client.Web.Startup))]
namespace PingYourPackage.API.Client.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
