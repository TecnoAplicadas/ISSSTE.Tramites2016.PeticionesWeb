using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Adjuntos
{
    public class Adjuntos
    {
        ///         <summary>
        /// Obtiene los archivos adjuntos de una petición
        /// </summary>
        /// <param name="ParametrosEntrada"></param>
        /// <param name="ParametrosError"></param>
        /// <returns></returns>
        public List<pa_PeticionesWeb_Adjuntos_Obtener_Adjuntos_Result> Obtener_AdjuntosP(clsDetallePeticionArchivo ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            var ArchivosAdejuntos = new List<pa_PeticionesWeb_Adjuntos_Obtener_Adjuntos_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    ArchivosAdejuntos = Db.pa_PeticionesWeb_Adjuntos_Obtener_Adjuntos(
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
            return ArchivosAdejuntos;
        }

      /// <summary>
      /// Registra el alta de un archivo adjunto de una petición
      /// </summary>
      /// <param name="ParametrosEntrada"></param>
      /// <param name="ParametrosError"></param>
      /// <returns></returns>
      public int Insertar_AdjuntoP(int IdUsuario, clsDetallePeticionArchivo ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
      {
         int resp = 0;
         try
         {
            using (var DB = new TramitesDigitalesEntities())
            {
               resp = DB.pa_PeticionesWeb_Adjuntos_Insertar_Adjunto(
                   pi_IdUsuario: IdUsuario,
                   pi_IdPeticion: ParametrosEntrada.IdPeticion,
                   pvc_RutaArchivo: ParametrosEntrada.RutaArchivo,
                   pvc_NombreArchivo: ParametrosEntrada.NombreArchivo,
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

      /// <summary>
      /// Elimina el registro de un archivo adjunto de una petición
      /// </summary>
      /// <param name="ParametrosEntrada"></param>
      /// <param name="ParametrosError"></param>
      /// <returns></returns>
      public int Eliminar_AdjuntoP(int IdUsuario, clsDetallePeticionArchivo ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
      {
         int resp = 0;
         try
         {
            using (var DB = new TramitesDigitalesEntities())
            {
               resp = DB.pa_PeticionesWeb_Adjuntos_Eliminar_Adjunto(
                   pi_IdOperador: IdUsuario,
                   pi_IdPeticion: ParametrosEntrada.IdPeticion,
                   pi_IdRenglon: ParametrosEntrada.IdRenglon,
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
