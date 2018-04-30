using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.SeguimientoOperador
{
    public class SeguimientoOperadorRdn
    {
        public List<pa_PeticionesWeb_SeguimientoOperador_Obtener_SeguimientoOperador_Result> Obtener_SeguimientoOperadorRdn(clsDetallePeticionSeguimieto ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {

            Procesos.Modulos.SeguimientoOperador.SeguimientoOperador objSeguimientoOperadorP = new Procesos.Modulos.SeguimientoOperador.SeguimientoOperador();

            List<pa_PeticionesWeb_SeguimientoOperador_Obtener_SeguimientoOperador_Result> SeguimientoOperador = new List<pa_PeticionesWeb_SeguimientoOperador_Obtener_SeguimientoOperador_Result>();
            try
            {
                SeguimientoOperador = objSeguimientoOperadorP.Obtener_SeguimientoOperadorP(ParametrosEntrada, ParametrosError);
            }
            catch (Exception)
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return SeguimientoOperador;
        }

        public int Insertar_SeguimientoOperadorRdn(clsDetallePeticionSeguimientoOperador ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            Procesos.Modulos.SeguimientoOperador.SeguimientoOperador objSeguimientoOperadorP = new Procesos.Modulos.SeguimientoOperador.SeguimientoOperador();
            int resp = 0;
            try
            {
                resp = objSeguimientoOperadorP.Insertar_SeguimientoOperadorP(ParametrosEntrada, ParametrosError);
            }
            catch
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return resp;
        }

        public int Eliminar_SeguimientoOperadorRdn(clsDetallePeticionSeguimientoOperador ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            Procesos.Modulos.SeguimientoOperador.SeguimientoOperador objSeguimientoOperadorP = new Procesos.Modulos.SeguimientoOperador.SeguimientoOperador();
            int resp = 0;
            try
            {
                resp = objSeguimientoOperadorP.Eliminar_SeguimientoOperadorP(ParametrosEntrada, ParametrosError);
            }
            catch
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return resp;
        }

    }
}
