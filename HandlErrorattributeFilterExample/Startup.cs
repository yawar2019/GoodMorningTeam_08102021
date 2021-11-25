using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HandlErrorattributeFilterExample.Startup))]
namespace HandlErrorattributeFilterExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
