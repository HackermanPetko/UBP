using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Administration.Startup))]
namespace Administration
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
