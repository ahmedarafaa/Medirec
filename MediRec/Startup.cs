using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediRec.Startup))]
namespace MediRec
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
