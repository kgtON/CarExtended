using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarModelExt.Startup))]
namespace CarModelExt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
