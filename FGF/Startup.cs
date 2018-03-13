using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FGF.Startup))]
namespace FGF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
