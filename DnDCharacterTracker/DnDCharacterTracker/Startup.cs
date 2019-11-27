using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DnDCharacterTracker.Startup))]
namespace DnDCharacterTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
