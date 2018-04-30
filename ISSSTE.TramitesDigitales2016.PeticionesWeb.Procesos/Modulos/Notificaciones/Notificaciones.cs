using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Notificaciones
{
    public class Notificaciones
    {
        public List<pa_PeticionesWeb_Notificaciones_Obtener_Notificaciones_Result> Obtener_NotificacionesP( ParametrosNotificacion ParametrosEntrada , ErrorProcedimientoAlmacenado ParametrosError)
        {
            var Notificaciones = new List<pa_PeticionesWeb_Notificaciones_Obtener_Notificaciones_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                        Notificaciones = Db.pa_PeticionesWeb_Notificaciones_Obtener_Notificaciones(
                        pi_IdPeticion: ParametrosEntrada.IdPeticion,
                        pi_errorNumero: ParametrosError.Numero,
                        pnvc_errorMensaje: ParametrosError.Mensaje,
                        pi_errorLinea: ParametrosError.Linea,
                        pnvc_errorProcAlm: ParametrosError.ProcedimientoAlmacenado,
                        pi_errorSeveridad: ParametrosError.Severidad,
                        pi_errorEstado: ParametrosError.Estado
                        ).ToList();
                }
            }
            catch
            {
                throw;
            }
            return Notificaciones;
        }

        public int Insertar_NotificacionP( clsDetallePeticionNotificacion ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            int resp;
            try
            {
                using (var DB = new TramitesDigitalesEntities() )
                {
                    resp = DB.pa_PeticionesWeb_Notificaciones_Insertar_Notificacion(
                        pi_IdPeticion: ParametrosEntrada.IdPeticion,
                        pi_IdNotificacion: ParametrosEntrada.IdNotificacion,
                        pnvc_Remitente: ParametrosEntrada.Remitente,
                        pnvc_Destinatario: ParametrosEntrada.Destinatario,
                        pnvc_ConCopiaA: ParametrosEntrada.ConCopiaA,
                        pnvc_Asunto: ParametrosEntrada.Asunto,
                        pb_EstatusEnvio: ParametrosEntrada.EstatusEnvio,
                        pnvc_ComentariosEnvio: ParametrosEntrada.ComentariosEnvio,
                        pi_errorNumero: ParametrosError.Numero,
                        pnvc_errorMensaje: ParametrosError.Mensaje,
                        pi_errorLinea: ParametrosError.Linea,
                        pnvc_errorProcAlm: ParametrosError.ProcedimientoAlmacenado,
                        pi_errorSeveridad: ParametrosError.Severidad,
                        pi_errorEstado: ParametrosError.Estado
                        );
                }

            }
            catch
            {
                throw;
            }
            return resp;
        }

    }
}
