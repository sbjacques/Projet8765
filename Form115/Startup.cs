using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Form115.Startup))]
namespace Form115
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
