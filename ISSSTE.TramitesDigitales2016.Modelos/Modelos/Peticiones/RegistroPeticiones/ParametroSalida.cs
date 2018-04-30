using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos.Peticiones.RegistroPeticiones
{
    public class ParametroSalida
    {
        public ParametroSalida()
        {
            IdPeticion = new ObjectParameter("IdPeticion", typeof(Int32));
            IdPeticion.Value = -1;
        }
        public ObjectParameter IdPeticion { get; set; }
    }
}
