using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: OwinStartupAttribute(typeof(Electricity_Ui.Startup))]
namespace Electricity_Ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // AreaRegistration.RegisterAllAreas();
           // RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
