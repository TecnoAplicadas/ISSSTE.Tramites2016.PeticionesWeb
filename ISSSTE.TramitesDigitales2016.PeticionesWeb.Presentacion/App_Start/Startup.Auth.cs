using System;
using ISSSTE.Tramites2015.Common.Security.Identity;
using ISSSTE.Tramites2015.Common.Security.Owin;
using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System.Configuration;
using Owin;
//using ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion
{
    public partial class Startup
    {

        #region Static Properties

        public static string ClientId
        {
            get { return ConfigurationManager.AppSettings["ClientId"]; }
        }

        public static string ProcedureId
        {
            get { return ConfigurationManager.AppSettings["ProcedureId"]; }
        }

        public static string Secret
        {
            get { return ConfigurationManager.AppSettings["Secret"]; }
        }

        public static string CookieName
        {
            get { return ConfigurationManager.AppSettings["CookieName"]; }
        }

        #endregion

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }


        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(IsssteIdentityDbContext.Create);
            app.CreatePerOwinContext<IsssteUserManager<IsssteIdentityUser>>(IsssteUserManager<IsssteIdentityUser>.Create);
            app.CreatePerOwinContext<IsssteRoleManager<IdentityRole>>(IsssteRoleManager<IdentityRole>.Create);
            app.CreatePerOwinContext<IsssteSignInManager<IsssteIdentityUser>>(IsssteSignInManager<IsssteIdentityUser>.Create);

            //Se utiliza para "darle la vuelta" a un error de asignación de cookies de autenticación en OWIN
            app.UseKentorOwinCookieSaver();

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with  a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                CookieName = Startup.CookieName,
                LoginPath = new PathString("/account/login"),
                //LoginPath = new PathString("/login"),
                ExpireTimeSpan = TimeSpan.FromMinutes(Double.Parse(ConfigurationManager.AppSettings["TokenTimeoutMinutes"]))
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new IsssteOAuthProvider<IsssteIdentityUser>(Startup.ClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(Double.Parse(ConfigurationManager.AppSettings["TokenTimeoutMinutes"])),
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            //Configures the application to use the ISSSTE Identity Provider
            app.UseIsssteTramitesAuthentication(
                procedureId: Startup.ProcedureId,
                clientId: ClientId,
                secret: Startup.Secret,
                errorUrl: "account/loginerror");
        }
        #region Old Configuration (before issste security)
        //// Para obtener más información para configurar la autenticación, visite http://go.microsoft.com/fwlink/?LinkId=301864
        //public void ConfigureAuth(IAppBuilder app)
        //{
        //    // Configure el contexto de base de datos, el administrador de usuarios y el administrador de inicios de sesión para usar una única instancia por solicitud
        //    app.CreatePerOwinContext(ApplicationDbContext.Create);
        //    app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
        //    app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

        //    // Permitir que la aplicación use una cookie para almacenar información para el usuario que inicia sesión
        //    // y una cookie para almacenar temporalmente información sobre un usuario que inicia sesión con un proveedor de inicio de sesión de terceros
        //    // Configurar cookie de inicio de sesión
        //    app.UseCookieAuthentication(new CookieAuthenticationOptions
        //    {
        //        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        //        LoginPath = new PathString("/Account/Login"),
        //        Provider = new CookieAuthenticationProvider
        //        {
        //            // Permite a la aplicación validar la marca de seguridad cuando el usuario inicia sesión.
        //            // Es una característica de seguridad que se usa cuando se cambia una contraseña o se agrega un inicio de sesión externo a la cuenta.  
        //            OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
        //                validateInterval: TimeSpan.FromMinutes(30),
        //                regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
        //        }
        //    });            
        //    app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

        //    // Permite que la aplicación almacene temporalmente la información del usuario cuando se verifica el segundo factor en el proceso de autenticación de dos factores.
        //    app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

        //    // Permite que la aplicación recuerde el segundo factor de verificación de inicio de sesión, como el teléfono o correo electrónico.
        //    // Cuando selecciona esta opción, el segundo paso de la verificación del proceso de inicio de sesión se recordará en el dispositivo desde el que ha iniciado sesión.
        //    // Es similar a la opción Recordarme al iniciar sesión.
        //    app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

        //    // Quitar los comentarios de las siguientes líneas para habilitar el inicio de sesión con proveedores de inicio de sesión de terceros
        //    //app.UseMicrosoftAccountAuthentication(
        //    //    clientId: "",
        //    //    clientSecret: "");

        //    //app.UseTwitterAuthentication(
        //    //   consumerKey: "",
        //    //   consumerSecret: "");

        //    //app.UseFacebookAuthentication(
        //    //   appId: "",
        //    //   appSecret: "");

        //    //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
        //    //{
        //    //    ClientId = "",
        //    //    ClientSecret = ""
        //    //});
        //}
        #endregion
    }
}