using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.TableroControl;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.ListarReporte;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Reportes.ServiciosReportes
{
   public class TableroControlCatalogos
   {
      CatalogoTableroControlRdn rdnListaCatalogos = new CatalogoTableroControlRdn();
      public ViewModelTableroControl cargaCatalogosTableroControl(int pi, int? idRol)
      {
         ViewModelTableroControl vmtc = new ViewModelTableroControl();
         ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
         vmtc.Delegacion = new List<SelectListItem>();
         vmtc.TiposOpinion = new List<SelectListItem>();
         vmtc.Status = new List<SelectListItem>();
         vmtc.FiltrosTableroControl = new FiltroTableroControl();
         try
         {
            var listaDelegaciones = rdnListaCatalogos.solicitarDelegaciones(pi, errorProcedimientoAlmacenado);
            var listaTipoOpinion = rdnListaCatalogos.solicitarTipoOpinion(errorProcedimientoAlmacenado);
            var listaStatus = rdnListaCatalogos.solicitarStatus(errorProcedimientoAlmacenado);
            if(idRol==1)
                vmtc.Delegacion.Add(new SelectListItem { Value = "", Text = "-Selecciona-", Selected = true });
            foreach (var item in listaDelegaciones)
               vmtc.Delegacion.Add(new SelectListItem { Value = item.IdUnidadAdministrativa.ToString(), Text = item.Nombre });
            vmtc.TiposOpinion.Add(new SelectListItem { Value = "", Text = "-Selecciona-", Selected = true });
            foreach (var item in listaTipoOpinion)
               vmtc.TiposOpinion.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nombre });
            vmtc.Status.Add(new SelectListItem { Value = "", Text = "-Selecciona-", Selected = true });
            foreach (var item in listaStatus)
               vmtc.Status.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nombre });
            return vmtc;
         }
         catch
         {
            return vmtc;
         }
      }
   }
}