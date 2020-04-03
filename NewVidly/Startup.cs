using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewVidly.Startup))]
namespace NewVidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
