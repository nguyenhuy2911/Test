using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Authorization_Authentication.Startup))]
namespace Authorization_Authentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
