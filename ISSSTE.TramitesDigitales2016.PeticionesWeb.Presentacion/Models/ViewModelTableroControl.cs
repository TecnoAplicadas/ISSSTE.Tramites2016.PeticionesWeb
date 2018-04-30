using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.TableroControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models
{
   public class ViewModelTableroControl
   {
      #region Listas
      /*Propiedades auto declaradas; por las cuales podremos desplegar los elementos
       en un combo box. Así como optener los valores de cada elemento*/
      public List<SelectListItem> Delegacion { get; set; }

      public List<SelectListItem> TiposOpinion { get; set; }

      public List<SelectListItem> Status { get; set; }
      #endregion

      #region filtroTableroControl
      /*El filtro nos permite pasar aquellos valores de un elemento en el combo,
       al ActionResult que nos va generar el excel.*/
      public FiltroTableroControl FiltrosTableroControl { get; set; }
      #endregion
   }
}