using ISSSTE.TramitesDigitales2016.Modelos.Modelos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
    public class clsUsuario : Usuario
    {
        public new Nullable<int> IdUsuario { get; set; }
        public override string Username { get; set; }
        public override string Password { get; set; }
        public override string Clave { get; set; }
        public new Nullable<int> IdEnlace { get; set; }
        public new Nullable<int> IdTipoUsuario { get; set; }
    }
}
