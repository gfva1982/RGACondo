using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Condos.WebAdmin.Startup))]
namespace Condos.WebAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
