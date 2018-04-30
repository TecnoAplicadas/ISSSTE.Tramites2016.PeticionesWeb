using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Bitacora;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Controllers
{
   [Authorize]
   public class BitacoraController : Controller
   {
      public ActionResult Index()
      {
         ViewBag.noRegistros = "";
         return View();
      }

      public JsonResult GetBitacoraDetail(string pUsuario, string pFechaInicio, string pFechaFinal, string pFolio)
      {
         ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
         BitacoraRdn objBitacoraRdn = new BitacoraRdn();
         Procesos.Modulos.Bitacora.ParametrosBitacora parametrosEntrada = new ParametrosBitacora();
         parametrosEntrada.Folio = pFolio;
         parametrosEntrada.Username = pUsuario;
         parametrosEntrada.FechaInicio = pFechaInicio;
         parametrosEntrada.FechaFin = pFechaFinal;

         var bitacora = objBitacoraRdn.Obtener_BitacoraPeticionRdn(parametrosEntrada, errorProcedimientoAlmacenado);
         return Json(bitacora, JsonRequestBehavior.AllowGet);
      }
   }
}