using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSMSWebSite.Startup))]
namespace CSMSWebSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
