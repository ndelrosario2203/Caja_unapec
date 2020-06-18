using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Caja_Unapec.Startup))]
namespace Caja_Unapec
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
