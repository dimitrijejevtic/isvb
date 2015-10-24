using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(isvb.dev.Startup))]
namespace isvb.dev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
