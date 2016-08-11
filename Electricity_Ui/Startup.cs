using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Electricity_Ui.Startup))]
namespace Electricity_Ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
