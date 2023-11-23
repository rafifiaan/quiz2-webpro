using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GenshinCourse.Startup))]
namespace GenshinCourse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
