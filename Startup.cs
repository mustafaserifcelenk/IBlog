using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IBlog.Startup))]
namespace IBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
