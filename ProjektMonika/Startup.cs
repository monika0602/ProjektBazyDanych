using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjektMonika.Startup))]
namespace ProjektMonika
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
