using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProgrammersBlog.Startup))]
namespace ProgrammersBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
