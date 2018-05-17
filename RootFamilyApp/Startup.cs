using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RootFamilyApp.Startup))]
namespace RootFamilyApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
