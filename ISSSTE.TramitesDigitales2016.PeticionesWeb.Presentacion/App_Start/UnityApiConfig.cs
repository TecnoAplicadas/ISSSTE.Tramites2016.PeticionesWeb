using ISSSTE.Tramites2015.Common.Mail;
using ISSSTE.Tramites2015.Common.Util;
using ISSSTE.Tramites2015.Velacion.DataAccess;
using ISSSTE.Tramites2015.Velacion.Domian;
using ISSSTE.Tramites2015.Velacion.Domian.Implementation;
using Microsoft.Practices.Unity;
using System.Configuration;
using System.Web.Http;
using ISSSTE.Tramites2015.Common.Reports;
using ISSSTE.Tramites2015.Common.Reports.Implementation;
using ISSSTE.Tramites2015.Common.Reports.Reports;
using Unity.WebApi;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion
{
    public static class UnityApiConfig
    {
        #region Static Properties

        /// <summary>
        /// Obtiene la ruta relativa donde se encuentra el html a utilizar como plantilla de los correos
        /// </summary>
        //private static string MailMasterPagePath
        //{
        //    get
        //    {
        //        return System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["MailMasterPagePath"]);
        //    }
        //}

        ///// <summary>
        ///// Obtiene la ruta relativa donde se encuentra la a utilizar como logo para los correos
        ///// </summary>
        //private static string MailMasterPageLogoPath
        //{
        //    get
        //    {
        //        return System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["MailMasterPageLogoPath"]);
        //    }
        //}

        #endregion

        #region Static Methods

        /// <summary>
        /// Registra los tipos necesarios para los controladores Web API
        /// </summary>
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ILogger, Logger>();
            //container.RegisterType<IMailService, MailService>(new InjectionConstructor(MailMasterPagePath, MailMasterPageLogoPath));
            //container.RegisterType<IMortuaryReportHelper, MortuaryReportHelper>();
            //container.RegisterType<IPitReportHelper, PitReportHelper>();

            //container.RegisterType<IUnitOfWork, MortuaryModel>();
            container.RegisterType<IEntitleDomainServices, EntitleDomainServices>();
            container.RegisterType<IProductDomainServices, ProductDomainServices>();
            container.RegisterType<IQuotationDomainServices, QuotationDomainServices>();            
            container.RegisterType<IIndicatorsDomainService, IndicatorsDomainService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        #endregion Static Methods
    }
}