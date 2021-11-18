using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webpr3odev.Startup))]
namespace webpr3odev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
