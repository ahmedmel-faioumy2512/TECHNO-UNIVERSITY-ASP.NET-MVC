using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Training.Startup))]
namespace MVC_Training
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
