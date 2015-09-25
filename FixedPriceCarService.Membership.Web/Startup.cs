using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FixedPriceCarService.Membership.Web.Startup))]
namespace FixedPriceCarService.Membership.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
