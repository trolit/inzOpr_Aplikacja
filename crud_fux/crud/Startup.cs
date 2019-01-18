using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(crud.Startup))]
namespace crud
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
