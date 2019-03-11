using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineJobApplication.Startup))]
namespace OnlineJobApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
