using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
    public class UsuarioPeticiones
    {
        public int IdUsuarioPeticiones { get; set; }
        public string NombrePeticiones { get; set; }
        public string ApellidoPaternoPeticiones { get; set; }
        public string ApellidoMaternoPeticiones { get; set; }
        public string UsernamePeticiones { get; set; }
        public string PasswordPeticiones { get; set; }
        public string LadaPeticiones { get; set; }
        public string TelefonoFijoPeticiones { get; set; }
        public string TelefonoMovilPeticiones { get; set; }
        public string RedPeticiones { get; set; }
        public string CorreoElectronicoPeticiones { get; set; }
        public string ClavePeticiones { get; set; }
        public int IdEnlacePeticiones { get; set; }
        public int IdTipoUsuarioPeticiones { get; set; }
        public string EstatusRegistroPeticiones { get; set; }
        public System.DateTime FechaRegistroPeticiones { get; set; }
        public int IdUsuarioRegistroPeticiones { get; set; }
    }
}
