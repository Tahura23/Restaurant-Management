using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Restaurant_app.Startup))]
namespace Restaurant_app
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
