using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;


namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.SeguimientoOperador
{
    public class SeguimientoOperador
    {
        /// <summary>
        /// Obtiene los registros de seguimiento que los operadores hacen a una petición
        /// </summary>
        /// <param name="ParametrosEntrada"></param>
        /// <param name="ParametrosError"></param>
        /// <returns></returns>
        public List<pa_PeticionesWeb_SeguimientoOperador_Obtener_SeguimientoOperador_Result> Obtener_SeguimientoOperadorP(clsDetallePeticionSeguimieto ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            var seguimientoOperador = new List<pa_PeticionesWeb_SeguimientoOperador_Obtener_SeguimientoOperador_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    seguimientoOperador = Db.pa_PeticionesWeb_SeguimientoOperador_Obtener_SeguimientoOperador(
                        pi_IdPeticion: ParametrosEntrada.IdPeticion,
                        pi_IdOperador: ParametrosEntrada.IdUsuario,
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
            return seguimientoOperador;
        }


        /// <summary>
        /// Agrega el seguimiento que el operador hace a una petición
        /// </summary>
        /// <param name="ParametrosEntrada"></param>
        /// <param name="ParametrosError"></param>
        /// <returns></returns>
        public int Insertar_SeguimientoOperadorP(clsDetallePeticionSeguimientoOperador ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            int resp=0;
            try
            {
                using (var DB = new TramitesDigitalesEntities())
                {
                    resp = DB.pa_PeticionesWeb_SeguimientoOperador_Insertar_SeguimientoOperador(
                        pi_IdPeticion: ParametrosEntrada.IdPeticion,
                        pi_IdOperador: ParametrosEntrada.IdOperador,
                        pnvc_Comentarios: ParametrosEntrada.Comentarios,
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
        /// Elimina un registro de seguimiento de una petición
        /// </summary>
        /// <param name="ParametrosEntrada"></param>
        /// <param name="ParametrosError"></param>
        /// <returns></returns>
        public int Eliminar_SeguimientoOperadorP(clsDetallePeticionSeguimientoOperador ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            int resp = 0;
            try
            {
                using (var DB = new TramitesDigitalesEntities())
                {
                    resp = DB.pa_PeticionesWeb_SeguimientoOperador_Eliminar_SeguimientoOperador(
                        pi_IdPeticion: ParametrosEntrada.IdPeticion,
                        pi_IdSeguimiento: ParametrosEntrada.IdSeguimiento,
                        pi_IdSeguimientoOperador: ParametrosEntrada.IdSeguimientoOperador,
                        pi_IdOperador: ParametrosEntrada.IdOperador,
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


