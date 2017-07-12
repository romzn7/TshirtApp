using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TshirtApp.Startup))]
namespace TshirtApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
