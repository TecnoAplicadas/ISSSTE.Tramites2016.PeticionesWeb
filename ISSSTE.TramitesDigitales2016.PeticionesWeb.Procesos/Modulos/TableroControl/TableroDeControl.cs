using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.TableroControl
{
   public class TableroDeControl
   {
        //Nueva invoacion pa
        public List<pa_PeticionesWeb_TableroControl_Obtener_Peticiones_Result1> obtenerPeticionesTableroDeControl(FiltroTableroControl pi, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_TableroControl_Obtener_Peticiones_Result1>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_TableroControl_Obtener_Peticiones(
                    pi_id_usuario: pi.IdUsuario,
                    pi_id_unidad_administrativa: pi.Delegacion,
                    pi_id_unidad_prestadora_servicio: pi.Ups,
                    pdt_fecha_inicio: pi.FechaInicio,
                    pdt_fecha_fin: pi.FechaFin,
                    pi_id_estatus_interno: pi.Status,
                    pi_id_tipo_opinion: pi.TipoOpinion,
                    pi_id_causa_asunto: pi.CausaAsunto,
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

        //Fin nueva invocacion

        public List<pa_PeticionesWeb_TableroControl_Obtener_IndicadoresPanelControl_Result> obtenerTableroDeControl(FiltroTableroControl pi, ErrorProcedimientoAlmacenado pError)
        {
         var respuestaWeb = new List<pa_PeticionesWeb_TableroControl_Obtener_IndicadoresPanelControl_Result>();
         try
         {
            using (var Db = new TramitesDigitalesEntities())
            {
               respuestaWeb = Db.pa_PeticionesWeb_TableroControl_Obtener_IndicadoresPanelControl(
               pi_id_unidad_administrativa: pi.Delegacion,
               pi_id_unidad_prestadora_servicio: pi.Ups,
               pdt_fecha_inicio: pi.FechaInicio,
               pdt_fecha_fin: pi.FechaFin,
               pi_id_estatus_interno: pi.Status,
               pi_id_tipo_opinion: pi.TipoOpinion,
               pi_id_causa_asunto: pi.CausaAsunto,
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
      public List<pa_PeticionesWeb_TableroControl_Obtener_PuntosControl_Result> obtenerPuntoDeControl(FiltroTableroControl pi, ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_TableroControl_Obtener_PuntosControl_Result>();
         try
         {
            using (var Db = new TramitesDigitalesEntities())
            {
               respuestaWeb = Db.pa_PeticionesWeb_TableroControl_Obtener_PuntosControl(
               pi_id_unidad_administrativa: pi.Delegacion,
               pi_id_unidad_prestadora_servicio: pi.Ups,
               pdt_fecha_inicio: pi.FechaInicio,
               pdt_fecha_fin: pi.FechaFin,
               pi_id_estatus_interno: pi.Status,
               pi_id_tipo_opinion: pi.TipoOpinion,
               pi_id_causa_asunto: pi.CausaAsunto,
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
      public List<pa_PeticionesWeb_TableroControl_Obtener_TotalPeticionesPorEstatus_Result> obtenerTotalPetcionesPorEstatus(FiltroTableroControl pi, ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_TableroControl_Obtener_TotalPeticionesPorEstatus_Result>();
         try
         {
            using (var Db = new TramitesDigitalesEntities())
            {
               respuestaWeb = Db.pa_PeticionesWeb_TableroControl_Obtener_TotalPeticionesPorEstatus(
               pi_id_unidad_administrativa: pi.Delegacion,
               pi_id_unidad_prestadora_servicio: pi.Ups,
               pdt_fecha_inicio: pi.FechaInicio,
               pdt_fecha_fin: pi.FechaFin,
               pi_id_estatus_interno: pi.Status,
               pi_id_tipo_opinion: pi.TipoOpinion,
               pi_id_causa_asunto: pi.CausaAsunto,
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



        public List<pa_PeticionesWeb_TableroDeControlGeneral_Result> ListaPeticionesTableroControl
        (FiltroTableroControl Parametros ,ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_TableroDeControlGeneral_Result>();

            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    //respuestaWeb = Db.pa_PeticionesWeb_TableroDeControlGeneral(
                    //pi_errorNumero: pError.Numero,
                    //pnvc_errorMensaje: pError.Mensaje,
                    //pi_errorLinea: pError.Linea,
                    //pnvc_errorProcAlm: pError.ProcedimientoAlmacenado,
                    //pi_errorSeveridad: pError.Severidad,
                    //pi_errorEstado: pError.Estado
                    //).ToList();

                    respuestaWeb = Db.pa_PeticionesWeb_TableroDeControlGeneral(
                        idDelegacion: Parametros.Delegacion,
                        idUps: Parametros.Ups,
                        fechaInicio: DateTime.Now.ToString(),
                        fechaFin: DateTime.Now.ToString(),
                        idTipoOpinion: Parametros.TipoOpinion,
                        idCausaAsunto: Parametros.CausaAsunto,
                        statusPeticion: Parametros.Status,
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

        public List<pa_PeticionesWeb_TableroDeControlConfiguracionDias_Result> ListaParanetrosDiasTableroControl
        (ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_TableroDeControlConfiguracionDias_Result>();

            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_TableroDeControlConfiguracionDias(
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

        public List<pa_PeticionesWeb_TableroDeEncabazadosDetalle_Result> ListaTableroDeEncabazadosDetalle
        (ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_TableroDeEncabazadosDetalle_Result>();

            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_TableroDeEncabazadosDetalle(
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

        public List<pa_PeticionesWeb_TableroDeEncabazadosEstadisticas_Result> EncabezadosEstadisticas
        (ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_TableroDeEncabazadosEstadisticas_Result>();

            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_TableroDeEncabazadosEstadisticas(
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