using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JSPs.Startup))]
namespace JSPs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
