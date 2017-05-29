using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SNotes.Startup))]
namespace SNotes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
