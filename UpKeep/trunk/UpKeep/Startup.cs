using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UpKeep.Startup))]
namespace UpKeep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
