using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sigue.Startup))]
namespace Sigue
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
