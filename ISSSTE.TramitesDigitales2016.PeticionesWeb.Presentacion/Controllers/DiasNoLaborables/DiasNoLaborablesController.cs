using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Catalogos;
using PagedList;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Controllers.DiasNoLaborables
{
    [Authorize]
    public class DiasNoLaborablesController : Controller
    {
      CrudDiasNoLaboralesRdn dias = new CrudDiasNoLaboralesRdn();
      public ActionResult ListaDiasNoLaborables(int? page)
      {
         int tamañoLista=10;
         int numeroDePagina=1;
         ErrorProcedimientoAlmacenado pError = new ErrorProcedimientoAlmacenado();
         try
         {
            var listSP = dias.solicitarDiasNoLaborables(pError);
            tamañoLista = 10;
            numeroDePagina = (page ?? 1);
            return View(listSP.ToPagedList(numeroDePagina, tamañoLista));
         }
         catch
         {
            List<ISSSTE.TramitesDigitales2016.Modelos.Contextos.pa_PeticionesWeb_Catalogos_Obtener_DiasNoLaborables_Result> listSP = new List<ISSSTE.TramitesDigitales2016.Modelos.Contextos.pa_PeticionesWeb_Catalogos_Obtener_DiasNoLaborables_Result>();
            ViewBag.ErrorMessage = "Error al cargar los días no laborables";
            return View(listSP.ToPagedList(numeroDePagina, tamañoLista));
         }
      }

      public ActionResult EliminaDiasNoLaborables(int idRegistro)
      {
         ErrorProcedimientoAlmacenado pError = new ErrorProcedimientoAlmacenado();
         try
         {
            dias.procesoEliminarDiasNoLaborables(idRegistro, pError);
         }
         catch
         {
            throw;
         }
         return RedirectToAction("ListaDiasNoLaborables");
      }

      public ActionResult AgregaDiasNoLaborables()
      {
         DiaNoLaborable dia = new DiaNoLaborable();
         //dia.Fecha = DateTime.Today.AddDays(00).AddHours(00).AddSeconds(00).AddMilliseconds(00);
         return View(dia);
      }
      [HttpPost]
      public ActionResult AgregaDiasNoLaborables(DiaNoLaborable dia)
      {
         try
         {
            ErrorProcedimientoAlmacenado pErrorExiste = new ErrorProcedimientoAlmacenado();
            var existeDia = dias.existeDiaNoLaborable(dia.Fecha,pErrorExiste);
            if (existeDia.Count > 0) {
               ViewBag.ExisteDia = "La fecha que ingresaste ya existe, ingresa una fecha diferente.";
               return View(dia);
            }
            ErrorProcedimientoAlmacenado pError = new ErrorProcedimientoAlmacenado();
            dia.FechaRegistro = DateTime.Today;
            string diaLetras = (dia.Fecha.ToString("dddd", new CultureInfo("es-ES")));
            dia.Dia = diaLetras.ToUpper().First() + diaLetras.Substring(1);
            dia.IdUsuarioRegistro = 1;
            dia.EstatusRegistro = "A";
            dias.procesoInsertarDiasNoLaborables(dia, pError);
         }
         catch{
            ViewBag.ErrorMessage = "Error al insertar Dia No Laborable";
            return View(dia);
         }
         return RedirectToAction("ListaDiasNoLaborables");
      }
   }
}