using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TemporaryWebWithIdentity.Startup))]
namespace TemporaryWebWithIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
