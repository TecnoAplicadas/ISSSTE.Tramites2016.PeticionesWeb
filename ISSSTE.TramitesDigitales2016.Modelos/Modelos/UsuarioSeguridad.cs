using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
    public class UsuarioSeguridad
    {
        public string IdUsuarioSeguridad { get; set; }
        public string NameSeguridad { get; set; }
        public string EmailSeguridad { get; set; }
        //public bool EmailConfirmed { get; set; }
        //public string PasswordHash { get; set; }
        //public string SecurityStamp { get; set; }
        //public string PhoneNumber { get; set; }
        //public bool PhoneNumberConfirmed { get; set; }
        //public bool TwoFactorEnabled { get; set; }
        //public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        //public bool LockoutEnabled { get; set; }
        //public int AccessFailedCount { get; set; }
        //public string UserNameSeguridad { get; set; }

        public string RolesUsuarioSeguridaId { get; set; }
        public string RolesUsuarioSeguridaName { get; set; }
        public string UpsDelUsuarioSeguridad { get; set; }
        public string DelegacionesSeguridad { get; set; }

    }
}
