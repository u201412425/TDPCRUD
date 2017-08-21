using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TDPCRUD.Startup))]
namespace TDPCRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
