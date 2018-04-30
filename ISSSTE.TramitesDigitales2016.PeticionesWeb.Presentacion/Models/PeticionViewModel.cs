using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models
{
    public class PeticionViewModel
    {
        public string RequesterCURP { get; set; }
        public string RequesterRFC { get; set; }
        public string RequesterName { get; set; }
        public string RequesterFirstName { get; set; }
        public string RequesterLastName { get; set; }
        public int RequesterGender { get; set; }
        public int RequesterRightHolderType { get; set; }
        public int RequesterColony { get; set; }
        public string RequesterStreet { get; set; }
        public string ExtNumber { get; set; }
        public string IntNumber { get; set; }
        public string RequesterLada { get; set; }
        public string RequesterFixedPhone { get; set; }
        public string RequesterMobilPhone { get; set; }
        public string RequesterEmail { get; set; }
        public string AffectedCurp { get; set; }
        public string AffectedRfc { get; set; }
        public string AffectedName { get; set; }
        public string AffectedFirstName { get; set; }
        public string AffectedLastName { get; set; }
        public int AffectedGender { get; set; }
        public int AffectedRightHolderType { get; set; }
        public string AffectedPhoneNumber { get; set; }
        public string AffectedEmail { get; set; }
        public int Area { get; set; }
        public int UPS { get; set; }
        public int ServicioHecho { get; set; }
        public int CausaAsunto { get; set; }
        public DateTime FechaHechos { get; set; }
        public string Description { get; set; }
    }
}