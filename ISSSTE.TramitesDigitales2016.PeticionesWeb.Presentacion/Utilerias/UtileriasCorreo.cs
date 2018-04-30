using ISSSTE.TramitesDigitales2016.PeticionesWeb.Comunes;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Notificaciones;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Notificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using System.Configuration;
using System.IO;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Utilerias
{
    public class UtileriasCorreo
    {

        public void enviarCorreo(int IdPeticion, string AppPath)
        {
            ParametrosNotificacion objParametrosNotificacion = new ParametrosNotificacion();
            ErrorProcedimientoAlmacenado objErrorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            NotificacionesRdn objConsultaNotificacionesRdn = new NotificacionesRdn();
            Boolean RespuestaEnvio = false;

            objParametrosNotificacion.IdPeticion = IdPeticion;
            var Notificaciones = objConsultaNotificacionesRdn.Obtener_NotificacionesRdn(objParametrosNotificacion, objErrorProcedimientoAlmacenado).ToList();
            foreach (pa_PeticionesWeb_Notificaciones_Obtener_Notificaciones_Result notificacion in Notificaciones)
            {
                //Obtiene los datos para el correo
                string asuntoNotificacion = obtAsuntoNotificacion(notificacion, AppPath);
                string contenidoNotificacion = obtContenidoNotificacion(notificacion, AppPath);
                string destinatario = string.IsNullOrEmpty(notificacion.Destinatario) ? string.Empty : notificacion.Destinatario.ToString();
                List<string> Adjuntos = new List<string>();
                //Envía el correo
                Correo objCorreo = new Correo();
                string msgError = string.Empty;
                if (asuntoNotificacion == string.Empty || contenidoNotificacion == string.Empty || destinatario == string.Empty) msgError = "No existe asunto, contenido o destinatario";
                if (msgError == string.Empty)
                {
                    RespuestaEnvio = objCorreo.enviarCorreo(asuntoNotificacion, contenidoNotificacion, true, destinatario, string.Empty, Adjuntos, out msgError);
                }
                //Guarda en la base de datos lo que se envió
                clsDetallePeticionNotificacion objDetalleNotificacion = new clsDetallePeticionNotificacion();
                objDetalleNotificacion.IdPeticion = IdPeticion;
                objDetalleNotificacion.IdNotificacion = notificacion.IdNotificacion;
                objDetalleNotificacion.Remitente = ConfigurationManager.AppSettings["MailAccountSender"].ToString();
                objDetalleNotificacion.Destinatario = notificacion.Destinatario;
                objDetalleNotificacion.ConCopiaA = string.Empty;
                objDetalleNotificacion.Asunto = asuntoNotificacion;
                objDetalleNotificacion.EstatusEnvio = RespuestaEnvio;
                objDetalleNotificacion.ComentariosEnvio = msgError;
                objDetalleNotificacion.Fecha = DateTime.Now;
                ErrorProcedimientoAlmacenado objErrProcAlma = new ErrorProcedimientoAlmacenado();
                NotificacionesRdn objRegistraNotificacionesRdn = new NotificacionesRdn();
                int RespuestaInsert;
                RespuestaInsert = objRegistraNotificacionesRdn.Insertar_NotificacionRdn(objDetalleNotificacion, objErrProcAlma);
            }
        }

        public string obtAsuntoNotificacion
        (pa_PeticionesWeb_Notificaciones_Obtener_Notificaciones_Result Notificacion, string AppPath)
        {
            //Lee la plantilla del asunto del correo.
            string subject = string.Empty;
            string plantillaAsunto = Notificacion.PlantillaAsunto.ToString();
            //string AppPath = Server.MapPath("~");
            string pathSubject = Path.Combine(AppPath, plantillaAsunto);
            try
            {
                System.IO.StreamReader file = System.IO.File.OpenText(pathSubject);
                for (; !file.EndOfStream;)
                {
                    subject += file.ReadLine();
                }
            }
            catch
            {
                return string.Empty;
            }

            //Efectúa la sustitución de datos
            subject = subject.Replace("[FOLIO]", Notificacion.Folio);

            return subject;
        }

        private string obtContenidoNotificacion
        (pa_PeticionesWeb_Notificaciones_Obtener_Notificaciones_Result Notificacion, string AppPath)
        {
            //Lee la plantilla del cuerpo del correo.
            string body = string.Empty;
            string plantillaContenido = Notificacion.PlantillaContenido.ToString();
            //string AppPath = Server.MapPath("~");
            string pathBody = Path.Combine(AppPath, plantillaContenido);
            try
            {
                System.IO.StreamReader file = System.IO.File.OpenText(pathBody);
                for (; !file.EndOfStream;)
                {
                    body += file.ReadLine();
                }
            }
            catch
            {
                return string.Empty;
            }

            //Efectúa la sustitución de datos
            string pathLogosCorreos = ConfigurationManager.AppSettings["pathLogosCorreos"].ToString();
            body = body.Replace("[PATHLOGO]", pathLogosCorreos);
            body = body.Replace("[FOLIO]", Notificacion.Folio);
            string Delegacion = Notificacion.Delegacion.ToString();
            body = body.Replace("[DELEGACION]", Delegacion);

            return body;
        }
    }
}