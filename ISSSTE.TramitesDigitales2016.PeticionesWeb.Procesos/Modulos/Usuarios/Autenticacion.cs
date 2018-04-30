using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos;


namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Usuarios
{
   public class Autenticacion
   {
      public List<pa_PeticionesWeb_Usuarios_Obtener_InformacionUsuario_Result> obtenerInformacionUsuario
      (String pEntrada, ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_Usuarios_Obtener_InformacionUsuario_Result>();
         try
         {
            using (var Db = new TramitesDigitalesEntities())
            {
               respuestaWeb = Db.pa_PeticionesWeb_Usuarios_Obtener_InformacionUsuario(
               pnvc_username: pEntrada,
               pi_errorNumero: pError.Numero,
               pnvc_errorMensaje: pError.Mensaje,
               pi_errorLinea: pError.Linea,
               pnvc_errorProcAlm: pError.ProcedimientoAlmacenado,
               pi_errorSeveridad: pError.Severidad,
               pi_errorEstado: pError.Estado
               ).ToList();
            }
         }
         catch
         {
            throw;
         }
         return respuestaWeb;
      }


        public List<pa_PeticionesWeb_ConfiguraPermisosUsuario_Result>  ConfiguraPermisosUsuario
        (UsuarioSeguridad pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_ConfiguraPermisosUsuario_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_ConfiguraPermisosUsuario(
                    idUsuarioSeguridad: pEntrada.IdUsuarioSeguridad,
                    nameSeguridad: pEntrada.NameSeguridad,
                    idRolSeguridad: pEntrada.RolesUsuarioSeguridaId,
                    nameRolSeguridad: pEntrada.RolesUsuarioSeguridaName,
                    delegacionesSeguridad: pEntrada.DelegacionesSeguridad,
                    uPSSeguridad: pEntrada.UpsDelUsuarioSeguridad,
                    correoUsuarioSeguridad: pEntrada.EmailSeguridad,
                    pi_errorNumero: pError.Numero,
                    pnvc_errorMensaje: pError.Mensaje,
                    pi_errorLinea: pError.Linea,
                    pnvc_errorProcAlm: pError.ProcedimientoAlmacenado,
                    pi_errorSeveridad: pError.Severidad,
                    pi_errorEstado: pError.Estado
                    ).ToList();
                }
            }
            catch
            {
                throw;
            }
            return respuestaWeb;
        }

    }
}
