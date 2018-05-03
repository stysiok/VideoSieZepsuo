using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoLender.Startup))]
namespace VideoLender
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
