using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDocSach.Startup))]
namespace WebDocSach
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
