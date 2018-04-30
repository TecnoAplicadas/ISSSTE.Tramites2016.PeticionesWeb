using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.DiasNoLaborales
{
   public class CrudDiasNoLaborales
   {
      Fechas pfecha = new Fechas();
      public CrudDiasNoLaborales()
      {
         pfecha.FechaServidor = DateTime.Today;
      }
      public List<pa_PeticionesWeb_Catalogos_Obtener_DiasNoLaborables_Result> obtenerDiasNoLaborales(ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_DiasNoLaborables_Result>();
         try
         {
            using (var Db = new TramitesDigitalesEntities())
            {
               respuestaWeb = Db.pa_PeticionesWeb_Catalogos_Obtener_DiasNoLaborables(
               pdt_FechaServidor: pfecha.FechaServidor,
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
      public String insertarDiasNoLaborales(DiaNoLaborable pi, ErrorProcedimientoAlmacenado pError)
      {
         try
         {
            using (var Db = new TramitesDigitalesEntities())
            {
               var respuestaWeb = Db.pa_PeticionesWeb_Catalogos_Insertar_DiasNoLaborables(
               pdt_Fecha: pi.Fecha,
               pdnv_Dia: pi.Dia,
               pdnv_Descripcion: pi.Descripcion,
               pdnv_ERegistro: pi.EstatusRegistro,
               pdt_FechaRegistro: pi.FechaRegistro,
               pdi_IdUsuaruario: pi.IdUsuarioRegistro,
               pi_errorNumero: pError.Numero,
               pnvc_errorMensaje: pError.Mensaje,
               pi_errorLinea: pError.Linea,
               pnvc_errorProcAlm: pError.ProcedimientoAlmacenado,
               pi_errorSeveridad: pError.Severidad,
               pi_errorEstado: pError.Estado);
            }
         }
         catch
         {
            throw;
         }
         return pError.ToString();
      }
      public String eliminarDiasNoLaborales(int pi, ErrorProcedimientoAlmacenado pError)
      {
         try
         {
            using (var Db = new TramitesDigitalesEntities())
            {
               var respuestaWeb = Db.pa_PeticionesWeb_Catalogos_Eliminar_DiasNoLaborables(
               pi_IdRegistro: pi,
               pi_errorNumero: pError.Numero,
               pnvc_errorMensaje: pError.Mensaje,
               pi_errorLinea: pError.Linea,
               pnvc_errorProcAlm: pError.ProcedimientoAlmacenado,
               pi_errorSeveridad: pError.Severidad,
               pi_errorEstado: pError.Estado);
            }
         }
         catch
         {
            throw;
         }
         return pError.ToString();
      }
      public List<DateTime?> obtenDiaNoLaborable(DateTime? pi,ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<DateTime?>();
         try
         {
            using (var Db = new TramitesDigitalesEntities())
            {
               respuestaWeb = Db.pa_PeticionesWeb_Obtener_DiaNoLaborables(
               pdt_fecha: pi,
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
