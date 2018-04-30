using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Comunes
{
    public class Correo
    {
        public bool enviarCorreo(string asuntoCorreo, string cuerpoCorreo, bool comoHtml, string listaCorreosPara, string listaCorreosCC, List<string> adjuntos, out string msgError)
        {
            msgError = string.Empty;

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Asunto
            mmsg.Subject = asuntoCorreo;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico a la que queremos enviar el mensaje
            string[] correosPara = listaCorreosPara.Split(',');
            foreach (string cuentaCorreo in correosPara) mmsg.To.Add(cuentaCorreo);

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            if (!string.IsNullOrEmpty(listaCorreosCC))
            {
                string[] correosCC = listaCorreosCC.Split(',');
                foreach (string cuentaCorreo in correosCC) mmsg.Bcc.Add(cuentaCorreo);
            }

            //Cuerpo del Mensaje
            mmsg.Body = cuerpoCorreo;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = comoHtml; //Si queremos o no que se envíe como HTML        

            //Archivos adjuntos
            try
            {
                //int IdAdjunto = 0;
                foreach (string archivo in adjuntos)
                {
                    System.Net.Mail.Attachment dat = new System.Net.Mail.Attachment(archivo);
                    mmsg.Attachments.Add(dat);
                }
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }

            //Correo electronico desde la que enviamos el mensaje
            string correoDesde = ConfigurationManager.AppSettings["MailAccountSender"].ToString();
            mmsg.From = new System.Net.Mail.MailAddress(correoDesde);

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Host = ConfigurationManager.AppSettings["MailServer"].ToString();
            cliente.Port = int.Parse(ConfigurationManager.AppSettings["MailServerPort"].ToString());
            string MailUseSSL = ConfigurationManager.AppSettings["MailUseSSL"].ToString().ToUpper();
            cliente.EnableSsl = (MailUseSSL == "TRUE" ? true : false);
            //Credenciales
            string usr = ConfigurationManager.AppSettings["MailUser"].ToString();
            string pwd = ConfigurationManager.AppSettings["MailPassword"].ToString();
            cliente.Credentials = new System.Net.NetworkCredential(usr, pwd);


            //Envío de correo
            try
            {
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                string StatusCode = ex.StatusCode.ToString().Trim();
                switch (StatusCode)
                {
                    case "ExceededStorageAllocation":
                        msgError = "Se superó la capacidad para adjuntar archivos (" + ConfigurationManager.AppSettings["ServerAttachmentCapacity"].ToString() + ")";
                        break;
                    default:
                        msgError = ex.Message + " : " + ex.InnerException.Message;
                        break;
                }
                return false;
            }

            return true;
        }

    }
}
