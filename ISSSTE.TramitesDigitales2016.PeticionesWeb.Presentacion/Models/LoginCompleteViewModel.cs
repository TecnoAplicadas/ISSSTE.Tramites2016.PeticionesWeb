using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models
{
    public class LoginCompleteViewModel
    {
        public string ClientId { get; set; }

        public string UserName { get; set; }

        public string ReturnUrl { get; set; }
    }
}