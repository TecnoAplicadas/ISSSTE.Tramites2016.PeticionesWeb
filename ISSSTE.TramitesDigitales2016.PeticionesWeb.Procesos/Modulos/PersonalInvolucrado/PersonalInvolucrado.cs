using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.PersonalInvolucrado
{
    public class PersonalInvolucrado
    {
        /// <summary>
        /// Consulta del personal involucrado de una petición
        /// </summary>
        /// <param name="ParametrosEntrada"></param>
        /// <param name="ParametrosError"></param>
        /// <returns></returns>
        public List<pa_PeticionesWeb_PersonalInvolucrado_Obtener_PersonalInvolucrado_Result> Obtener_PersonalInvolucradoP(  clsPeticion ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            var PersonalInvolucrado = new List<pa_PeticionesWeb_PersonalInvolucrado_Obtener_PersonalInvolucrado_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    PersonalInvolucrado = Db.pa_PeticionesWeb_PersonalInvolucrado_Obtener_PersonalInvolucrado(
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
            return PersonalInvolucrado;
        }


        /// <summary>
        /// Alta de personal involucrado
        /// </summary>
        /// <param name="ParametrosEntrada"></param>
        /// <param name="ParametrosError"></param>
        /// <returns></returns>
        public int Insertar_PersonalInvolucradoP(clsDetallePeticionInvolucrado ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            int resp=0;
            try
            {
                using (var DB = new TramitesDigitalesEntities())
                {
                    resp = DB.pa_PeticionesWeb_PersonalInvolucrado_Registrar_PersonalInvolucrado(
                        pi_IdPeticion: ParametrosEntrada.IdPeticion,
                        pnvc_Nombre: ParametrosEntrada.Nombre,
                        pnvc_ApellidoPaterno: ParametrosEntrada.ApellidoPaterno,
                        pnvc_ApellidoMaterno: ParametrosEntrada.ApellidoMaterno,
                        pi_IdTipoPersonal: ParametrosEntrada.IdTipoPersonal,
                        pi_IdUsuarioRegistro: ParametrosEntrada.IdUsuarioRegistro,
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
        /// Eliminación de personal involucrado
        /// </summary>
        /// <param name="ParametrosEntrada"></param>
        /// <param name="ParametrosError"></param>
        /// <returns></returns>
        public int Eliminar_PersonalInvolucradoP(int IdUsuario, clsDetallePeticionInvolucrado ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            int resp=0;
            try
            {
            using (var DB = new TramitesDigitalesEntities())
            {
               resp = DB.pa_PeticionesWeb_PersonalInvolucrado_Eliminar_PersonalInvolucrado(
                    pi_IdOperador: IdUsuario,
                    pi_IdPeticion: ParametrosEntrada.IdPeticion,
                    pi_IdInvolucrado: ParametrosEntrada.IdInvolucrado,
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
