using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BBRG.Startup))]
namespace BBRG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
