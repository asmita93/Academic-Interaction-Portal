using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aip.Startup))]
namespace aip
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
