using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
    public class clsArea
    {
        public Nullable<int> IdArea { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string EstatusRegistro { get; set; }
        public Nullable<DateTime> FechaRegistro { get; set; }
        public Nullable<int> IdUsuarioRegistro { get; set; }
    }
}
