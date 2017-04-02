using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReferalRockAssignment.Startup))]
namespace ReferalRockAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
