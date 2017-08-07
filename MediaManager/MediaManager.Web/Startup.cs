using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediaManager.Web.Startup))]
namespace MediaManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
