using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Catalogos;
using ISSSTE.Tramites2015.Common.Web.Mvc;
using ISSSTE.Tramites2015.Common.Security.Helpers;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Controllers
{
    [Authorize]
    public class GeneroController : Controller
    {
        // GET: Genero
        public ActionResult Index()
        {
            var owinContext = Request.GetOwinContext();
            var user = owinContext.GetAuthenticatedUser(); 
            ViewBag.userLogged = user.UserName;

            return View();
        }
    }
}