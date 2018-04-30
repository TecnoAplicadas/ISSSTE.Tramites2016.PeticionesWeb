using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Notificaciones;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Notificaciones
{
    public class NotificacionesRdn
    {
        public List<pa_PeticionesWeb_Notificaciones_Obtener_Notificaciones_Result> Obtener_NotificacionesRdn(ParametrosNotificacion ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            Procesos.Modulos.Notificaciones.Notificaciones objNotificacionesP = new Procesos.Modulos.Notificaciones.Notificaciones();

            List<pa_PeticionesWeb_Notificaciones_Obtener_Notificaciones_Result> Notificaciones = new List<pa_PeticionesWeb_Notificaciones_Obtener_Notificaciones_Result>();
            try
            {                 
                Notificaciones = objNotificacionesP.Obtener_NotificacionesP(ParametrosEntrada, ParametrosError);
            }
            catch (Exception)
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return Notificaciones;
        }

        public int Insertar_NotificacionRdn(clsDetallePeticionNotificacion ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            Procesos.Modulos.Notificaciones.Notificaciones objNotificacionesP = new Procesos.Modulos.Notificaciones.Notificaciones();
            int resp;
                try
            {
                resp = objNotificacionesP.Insertar_NotificacionP(ParametrosEntrada, ParametrosError);
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
