using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ETicaretWeb.Startup))]
namespace ETicaretWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
