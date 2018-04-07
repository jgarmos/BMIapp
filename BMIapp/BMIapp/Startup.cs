using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BMIapp.Startup))]
namespace BMIapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
