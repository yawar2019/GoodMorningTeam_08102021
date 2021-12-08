using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bundling.Startup))]
namespace Bundling
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
