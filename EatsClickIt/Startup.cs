using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EatsClickIt.Startup))]
namespace EatsClickIt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
