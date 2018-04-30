using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Bitacora;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;


namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Bitacora
{
    public class BitacoraRdn
    {
        public List<pa_PeticionesWeb_Bitacora_Obtener_BitacoraPeticion_Result> Obtener_BitacoraPeticionRdn(ParametrosBitacora ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            Procesos.Modulos.Bitacora.Bitacora objBitacoraP = new Procesos.Modulos.Bitacora.Bitacora();

            List<pa_PeticionesWeb_Bitacora_Obtener_BitacoraPeticion_Result> Bitacora = new List<pa_PeticionesWeb_Bitacora_Obtener_BitacoraPeticion_Result>();
            try
            {
                Bitacora = objBitacoraP.Obtener_BitacoraPeticionP(ParametrosEntrada, ParametrosError);
            }
            catch (Exception)
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return Bitacora;
        }

    }
}
