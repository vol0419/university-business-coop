using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(inz.Startup))]
namespace inz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
