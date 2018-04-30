using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Controllers
{
    public class PeticionController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch
            {
                return RedirectToAction("Error500");                    
            }
           
        }
        public ActionResult Error500()
        {
            return View();

        }
    }
}