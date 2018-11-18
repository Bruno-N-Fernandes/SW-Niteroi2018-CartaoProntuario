using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CP.WebApp.Startup))]
namespace CP.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
