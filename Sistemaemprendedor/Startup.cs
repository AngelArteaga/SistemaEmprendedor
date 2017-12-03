using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sistemaemprendedor.Startup))]
namespace Sistemaemprendedor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
