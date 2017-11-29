using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CPP.Startup))]
namespace CPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           ConfigureAuth(app);
        }
    }
}
