using Microsoft.Owin;
using Owin;

//[assembly: OwinStartupAttribute(typeof(ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Startup))]
[assembly: OwinStartup(typeof(ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Startup))]


namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
