using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.RegistroPeticion;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.RegistroPeticion
{
    public class PeticionRdn
    {
        public List<pa_PeticionesWeb_Peticion_Guardar_Peticion_Result> SalvarPeticion(Peticion pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            PeticionPro procesosGuardarPeticion = new PeticionPro();
            var respuestaweb = new List<pa_PeticionesWeb_Peticion_Guardar_Peticion_Result>();
            try
            {
                respuestaweb = procesosGuardarPeticion.GuardarPeticion(pEntrada, pError);
            }
            catch (Exception)
            {
                throw;
            }
            return respuestaweb;
        }
    }
}
