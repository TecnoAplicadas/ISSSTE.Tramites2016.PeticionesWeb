using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Controllers.BandejaDePeticionesControlador
{
    public class ModalAjaxController : Controller
    {
        // GET: ModalAjax
        // GET: Modal1
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IndexPost(FormCollection Formulario)
        {
            return View();
        }
    }
}