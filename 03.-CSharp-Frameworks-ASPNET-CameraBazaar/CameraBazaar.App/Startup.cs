using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CameraBazaar.App.Startup))]
namespace CameraBazaar.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
