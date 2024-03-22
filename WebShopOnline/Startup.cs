using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShopOnline.Startup))]
namespace WebShopOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
