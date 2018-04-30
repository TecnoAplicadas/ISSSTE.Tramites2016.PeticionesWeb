using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Usuarios;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Usuarios
{
   public class AutenticacionRdn
   {
      Autenticacion procesoAutenticacion = new Autenticacion();
      public List<pa_PeticionesWeb_Usuarios_Obtener_InformacionUsuario_Result> solicitarInformacionUsuario
      (String pEntrada, ErrorProcedimientoAlmacenado pError)
      {
         var respuestaweb = new List<pa_PeticionesWeb_Usuarios_Obtener_InformacionUsuario_Result>();
         try
         {
            respuestaweb = procesoAutenticacion.obtenerInformacionUsuario(pEntrada, pError);
         }
         catch
         {
            throw;
         }
         return respuestaweb;
      }


        public List<pa_PeticionesWeb_ConfiguraPermisosUsuario_Result> ConfiguraPermisosUsuarioRdn
        (UsuarioSeguridad pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            List<pa_PeticionesWeb_ConfiguraPermisosUsuario_Result> respuestaweb = 
            new List<pa_PeticionesWeb_ConfiguraPermisosUsuario_Result>();
            try
            {
                respuestaweb = procesoAutenticacion.ConfiguraPermisosUsuario(pEntrada, pError);
            }
            catch
            {
                throw;
            }
            return respuestaweb;
        }
    }
}
