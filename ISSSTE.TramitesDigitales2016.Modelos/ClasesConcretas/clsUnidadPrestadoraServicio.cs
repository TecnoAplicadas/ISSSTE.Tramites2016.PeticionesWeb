using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
    public class clsUnidadPrestadoraServicio:UnidadPrestadoraServicio
    {
        public new Nullable<int> IdUnidadPrestadoraServicio { get; set; }
        public override string Clave { get; set; }
        public override string Nombre { get; set; }
        public override string ClavePresupuestal { get; set; }
        public new Nullable<int> IdClasificacionUps { get; set; }
        public new Nullable<int> IdUnidadAdministrativa { get; set; }
        public new Nullable<int> IdNivelUps { get; set; }
        public override string EstatusRegistro { get; set; }
        public new Nullable<DateTime> FechaRegistro { get; set; }
        public new Nullable<int> IdUsuarioRegistro { get; set; }


        public new clsClasificacionUps ClasificacionUps = new clsClasificacionUps();

        public new clsNivelUps NivelUps = new clsNivelUps();

        public new clsUnidadAdministrativa UnidadAdministrativa = new clsUnidadAdministrativa();
    }
}
