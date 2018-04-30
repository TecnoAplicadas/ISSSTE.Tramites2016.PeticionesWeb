using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.BandejaPeticiones
{
    public class BandejaDePeticiones
    {
        public List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Usuario_Result> Obtener_Peticiones_UsuarioP
        (clsUsuario pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Usuario_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Usuario(
                    idUsuario: pEntrada.IdUsuario,
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

        /// <summary>
        /// Obtiene las peticiones que cumplen los criterios de consulta
        /// </summary>
        /// <param name="pEntrada"></param>
        /// <param name="pError"></param>
        /// <returns></returns>
        public List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Filtros_Result> Obtener_Peticiones_FiltrosP
        (ParamEntradaGeneral ParametrosGenerales, FiltrosPeticion pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Filtros_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Filtros(
                        pi_IdUsuario: pEntrada.IdUsuario,
                        pnvc_Folio: pEntrada.Folio,
                        pi_IdEstatusInterno: pEntrada.IdEstatusInterno,
                        pnvc_Curp: pEntrada.Curp,
                        pnvc_Rfc: pEntrada.Rfc,
                        pnvc_Nombre: pEntrada.Nombre,
                        pnvc_ApellidoPaterno: pEntrada.ApellidoPaterno,
                        pnvc_ApellidoMaterno: pEntrada.ApellidoMaterno,
                        pi_IdGenero: pEntrada.IdGenero,
                        pi_IdTipoDerechohabiente: pEntrada.IdTipoDerechohabiente,
                        pnvc_ClaveCP: pEntrada.ClaveCP,
                        pi_IdEstado: pEntrada.IdEstado,
                        pi_IdMunicipio: pEntrada.IdMunicipio,
                        pnvc_NombreColonia: pEntrada.NombreColonia,
                        pnvc_Calle: pEntrada.Calle,
                        pnvc_NumeroExterior: pEntrada.NumeroExterior,
                        pnvc_NumeroInterior: pEntrada.NumeroInterior,
                        pnvc_Lada: pEntrada.Lada,
                        pnvc_TelefonoFijo: pEntrada.TelefonoFijo,
                        pnvc_TelefonoMovil: pEntrada.TelefonoMovil,
                        pnvc_CorreoElectronico: pEntrada.CorreoElectronico,
                        pnvc_CurpAfectado: pEntrada.CurpAfectado,
                        pnvc_RfcAfectado: pEntrada.RfcAfectado,
                        pnvc_NombreAfectado: pEntrada.NombreAfectado,
                        pnvc_ApellidoPaternoAfectado: pEntrada.ApellidoPaternoAfectado,
                        pnvc_ApellidoMaternoAfectado: pEntrada.ApellidoMaternoAfectado,
                        pi_IdGeneroAfectado: pEntrada.IdGeneroAfectado,
                        pi_IdTipoDhbAfectado: pEntrada.IdTipoDhbAfectado,
                        pnvc_TelefonoFijoAfectado: pEntrada.TelefonoFijoAfectado,
                        pnvc_CorreoElectronicoAfectado: pEntrada.CorreoElectronicoAfectado,
                        pi_IdTipoUps: pEntrada.IdTipoUps,
                        pi_IdUnidadAdministrativa: pEntrada.IdUnidadAdministrativa,
                        pi_IdUnidadPrestadoraServicio: pEntrada.IdUnidadPrestadoraServicio,
                        pi_IdTipoOpinion: pEntrada.IdTipoOpinion,
                        pi_IdCausaAsunto: pEntrada.IdCausaAsunto,
                        pvc_FechaHechos: pEntrada.FechaHechos,
                        pi_IdServicioHecho: pEntrada.IdServicioHecho,
                        pvc_Descripcion: pEntrada.Descripcion,
                        pvc_FechaCaptura: pEntrada.FechaRegistro,
                        pvc_FechaCapturaFin: pEntrada.FechaRegistroFin,
                        consultaPorAsignadas: ParametrosGenerales.ConsultaPorAsignadas,
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

        /// <summary>
        /// Obtiene toda la información de la petición que se pasa como parámetro
        /// </summary>
        /// <param name="pEntrada"></param>
        /// <param name="pError"></param>
        /// <returns></returns>
        public List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result> Obtener_Peticiones_DetalleP
        (clsPeticion pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle(
                        pi_IdPeticion: pEntrada.IdPeticion,
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

        /// <summary>
        /// Actualiza la petición, el peticionario y afectado respectivo
        /// </summary>
        /// <param name="ParametrosPeticion"></param>
        /// <param name="ParametrosPeticionario"></param>
        /// <param name="ParametrosAfectado"></param>
        /// <param name="ParametrosError"></param>
        /// <returns></returns>
        public int Actualizar_PeticionP
        (clsPeticion ParametrosPeticion, clsPeticionario ParametrosPeticionario,
         clsAfectado ParametrosAfectado, ErrorProcedimientoAlmacenado ParametrosError)
        {
            int resp;
            try
            {
                using (var DB = new TramitesDigitalesEntities())
                {
                    resp = DB.pa_PeticionesWeb_Bandeja_Peticiones_Actualizar_Peticion(
                        pi_IdPeticion: ParametrosPeticion.IdPeticion,
                        pi_IdArea: ParametrosPeticion.IdArea,
                        pi_IdPeticionario: ParametrosPeticion.IdPeticionario,
                        pi_IdAfectado: ParametrosPeticion.IdAfectado,
                        pi_IdCausaAsunto: ParametrosPeticion.IdCausaAsunto,
                        pi_IdServicioHecho: ParametrosPeticion.IdServicioHecho,
                        pi_IdUnidadPrestadoraServicio: ParametrosPeticion.IdUnidadPrestadoraServicio,
                        pnvc_FechaHechos: ParametrosPeticion.FechaHechos,
                        pnvc_Descripcion: ParametrosPeticion.Descripcion,
                        pi_IdOperador: ParametrosPeticion.IdOperador,
                        pi_IdEstatusInterno: ParametrosPeticion.IdEstatusInterno,
                        pnvc_Curp_Peticionario: ParametrosPeticionario.Curp,
                        pnvc_Nombre_Peticionario: ParametrosPeticionario.Nombre,
                        pnvc_ApellidoPaterno_Peticionario: ParametrosPeticionario.ApellidoPaterno,
                        pnvc_ApellidoMaterno_Peticionario: ParametrosPeticionario.ApellidoMaterno,
                        pi_IdTipoDerechohabiente_Peticionario: ParametrosPeticionario.IdTipoDerechohabiente,
                        pnvc_Lada_Peticionario: ParametrosPeticionario.Lada,
                        pnvc_TelefonoFijo_Peticionario: ParametrosPeticionario.TelefonoFijo,
                        pnvc_TelefonoMovil_Peticionario: ParametrosPeticionario.TelefonoMovil,
                        pnvc_CorreoElectronico_Peticionario: ParametrosPeticionario.CorreoElectronico,
                        pi_IdGenero_Peticionario: ParametrosPeticionario.IdGenero,
                        pnvc_Rfc_Peticionario: ParametrosPeticionario.Rfc,
                        pnvc_Calle_Peticionario: ParametrosPeticionario.Calle,
                        pnvc_NumeroExterior_Peticionario: ParametrosPeticionario.NumeroExterior,
                        pnvc_NumeroInterior_Peticionario: ParametrosPeticionario.NumeroInterior,
                        pi_IdPoblacionOColonia_Peticionario: ParametrosPeticionario.IdPoblacionOColonia,
                        pnvc_Curp_Afectado: ParametrosAfectado.Curp,
                        pnvc_Nombre_Afectado: ParametrosAfectado.Nombre,
                        pnvc_ApellidoPaterno_Afectado: ParametrosAfectado.ApellidoPaterno,
                        pnvc_ApellidoMaterno_Afectado: ParametrosAfectado.ApellidoMaterno,
                        pi_IdTipoDerechohabiente_Afectado: ParametrosAfectado.IdTipoDerechohabiente,
                        pnvc_Lada_Afectado: ParametrosAfectado.Lada,
                        pnvc_TelefonoFijo_Afectado: ParametrosAfectado.TelefonoFijo,
                        pnvc_TelefonoMovil_Afectado: ParametrosAfectado.TelefonoMovil,
                        pnvc_CorreoElectronico_Afectado: ParametrosAfectado.CorreoElectronico,
                        pi_IdGenero_Afectado: ParametrosAfectado.IdGenero,
                        pnvc_Rfc_Afectado: ParametrosAfectado.Rfc,
                        //pnvc_Calle_Afectado:
                        //pnvc_NumeroExterior_Afectado
                        //pnvc_NumeroInterior_Afectado
                        //pi_IdPoblacionOColonia_Afectado
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
        /// Obtiene el operador asignado a la unidad 
        /// </summary>
        /// <param name="ParametrosPeticion"></param>
        /// <param name="ParametrosError"></param>
        /// <returns></returns>
        public List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiene_Operador_Por_UPS_Result> ObtieneOperadorPorUnidad
        (clsPeticion ParametrosPeticion, clsUsuario DatosUsuario, ErrorProcedimientoAlmacenado ParametrosError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiene_Operador_Por_UPS_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Bandeja_Peticiones_Obtiene_Operador_Por_UPS(
                    idUPS: ParametrosPeticion.IdUnidadPrestadoraServicio,
                    idUsuario: DatosUsuario.IdUsuario,
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
            return respuestaWeb;
        }

        /// <summary>
        /// Asigna Operador a la peticion
        /// </summary>
        /// <param name="ParametrosUsuario"></param>
        /// <param name="ParametrosPeticion"></param>
        /// <param name="ParametrosError"></param>
        /// <returns></returns>
        public int AsignarOperador
        (clsUsuario ParametrosUsuario, clsPeticion ParametrosPeticion, bool OperadorNuevoReasignado, ErrorProcedimientoAlmacenado ParametrosError)
        {
            int respuestaWeb = 0;
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Bandeja_Peticiones_Asignar_Operador(
                                    pi_IdPeticion: ParametrosPeticion.IdPeticion,
                                    pi_IdUsuario: ParametrosUsuario.IdUsuario,
                                    pi_IdOperador: ParametrosPeticion.IdOperador,
                                    pb_Asignacion: OperadorNuevoReasignado,
                                    pi_errorNumero: ParametrosError.Numero,
                                    pnvc_errorMensaje: ParametrosError.Mensaje,
                                    pi_errorLinea: ParametrosError.Linea,
                                    pnvc_errorProcAlm: ParametrosError.ProcedimientoAlmacenado,
                                    pi_errorSeveridad: ParametrosError.Severidad,
                                    pi_errorEstado: ParametrosError.Estado);
                }
            }
            catch
            {
                throw;
            }
            return respuestaWeb;
        }


        public List<pa_PeticionesWeb_Catalogos_EsatusInterno_Result> ObtenerCatalogoEstatusInterno
        (clsUsuario pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_EsatusInterno_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Catalogos_EsatusInterno(
                    idUsuario: pEntrada.IdUsuario,
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

        public int ConcluirCerrar_PeticionP
        (clsPeticion ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            int resp = 0;
            try
            {
                using (var DB = new TramitesDigitalesEntities())
                {
                    resp = DB.pa_PeticionesWeb_Bandeja_Peticiones_ConcluirCerrarPeticion(
                        pi_IdPeticion: ParametrosEntrada.IdPeticion,
                        pi_IdOperador: ParametrosEntrada.IdOperador,
                        pi_errorNumero: ParametrosError.Numero,
                        pnvc_errorMensaje: ParametrosError.Mensaje,
                        pi_errorLinea: ParametrosError.Linea,
                        pnvc_errorProcAlm: ParametrosError.ProcedimientoAlmacenado,
                        pi_errorSeveridad: ParametrosError.Severidad,
                        pi_errorEstado: ParametrosError.Estado
                        );
                    resp = int.Parse(ParametrosError.Numero.Value.ToString());
                    resp = (resp == 0) ? 1 : 0;
                }
            }
            catch (Exception e)
            {
                resp = 0;
            }
            return resp;
        }

        public List<pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result> ObeterInformacionUsuario
        (int IdUsuarioparam, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Usuarios_Obtener_Usuario(
                    pi_IdUsuario: IdUsuarioparam,
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

        public List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_DetalleExportaExcel_Result>ObtenerExcelPeticiones
        (string CadPeticiones, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_DetalleExportaExcel_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_DetalleExportaExcel(
                    pi_IdPeticion: CadPeticiones,
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

        public int ActualizarPeticion
        (pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            int resp = 0;
            try
            {
                using (var DB = new TramitesDigitalesEntities())
                {
                    resp = DB.pa_PeticionesWeb_Bandeja_Peticiones_Actualizar_Peticion(

                    pi_IdPeticion : ParametrosEntrada.IdPeticion,
                    pi_IdArea: ParametrosEntrada.IdArea,
                    pi_IdPeticionario: ParametrosEntrada.IdPeticionario,
                    pi_IdAfectado: ParametrosEntrada.IdAfectado,
                    pi_IdCausaAsunto: ParametrosEntrada.IdCausaAsunto,
                    pi_IdServicioHecho: ParametrosEntrada.IdServicioHecho,
                    pi_IdUnidadPrestadoraServicio: ParametrosEntrada.IdUps,  // validar
                    pnvc_FechaHechos: ParametrosEntrada.FechaHechos,
                    pnvc_Descripcion: ParametrosEntrada.Descripcion,
                    pi_IdOperador: ParametrosEntrada.IdOperador,
                    pi_IdEstatusInterno: ParametrosEntrada.IdEstatusInterno,
                    pnvc_Curp_Peticionario : ParametrosEntrada.CurpPeticionario,
                    pnvc_Nombre_Peticionario : ParametrosEntrada.NombrePeticionario,
                    pnvc_ApellidoPaterno_Peticionario : ParametrosEntrada.ApePaternoPeticionario,
                    pnvc_ApellidoMaterno_Peticionario: ParametrosEntrada.ApeMaternoPeticionario,
                    pi_IdTipoDerechohabiente_Peticionario: ParametrosEntrada.IdTipoDhbPeticionario,
                    pnvc_Lada_Peticionario: ParametrosEntrada.LadaPeticionario,
                    pnvc_TelefonoFijo_Peticionario: ParametrosEntrada.TelefonoFijoPeticionario,
                    pnvc_TelefonoMovil_Peticionario: ParametrosEntrada.TelefonoMovilPeticionario,
                    pnvc_CorreoElectronico_Peticionario: ParametrosEntrada.CorreoElectronicoPeticionario,
                    pi_IdGenero_Peticionario: ParametrosEntrada.IdGeneroPeticionario,
                    pnvc_Rfc_Peticionario: ParametrosEntrada.RfcPeticionario,
                    pnvc_Calle_Peticionario: ParametrosEntrada.CallePeticionario,
                    pnvc_NumeroExterior_Peticionario : ParametrosEntrada.NumeroExteriorPeticionario,
                    pnvc_NumeroInterior_Peticionario: ParametrosEntrada.NumeroInteriorPeticionario,
                    pi_IdPoblacionOColonia_Peticionario: ParametrosEntrada.IdColoniaPeticionario,
                    pnvc_Curp_Afectado: ParametrosEntrada.CurpAfectado,
                    pnvc_Nombre_Afectado: ParametrosEntrada.NombreAfectado,
                    pnvc_ApellidoPaterno_Afectado: ParametrosEntrada.ApePaternoAfectado,
                    pnvc_ApellidoMaterno_Afectado: ParametrosEntrada.ApeMaternoAfectado,
                    pi_IdTipoDerechohabiente_Afectado: ParametrosEntrada.IdTipoDhbAfectado,
                    pnvc_Lada_Afectado: ParametrosEntrada.LadaAfectado,
                    pnvc_TelefonoFijo_Afectado:ParametrosEntrada.TelefonoFijoAfectado,
                    pnvc_TelefonoMovil_Afectado: ParametrosEntrada.TelefonoFijoAfectado,
                    pnvc_CorreoElectronico_Afectado:ParametrosEntrada.CorreoElectronicoAfectado,
                    pi_IdGenero_Afectado: ParametrosEntrada.IdGeneroAfectado,
                    pnvc_Rfc_Afectado: ParametrosEntrada.RfcAfectado,
                    pi_errorNumero: ParametrosError.Numero,
                    pnvc_errorMensaje: ParametrosError.Mensaje,
                    pi_errorLinea: ParametrosError.Linea,
                    pnvc_errorProcAlm: ParametrosError.ProcedimientoAlmacenado,
                    pi_errorSeveridad: ParametrosError.Severidad,
                    pi_errorEstado: ParametrosError.Estado
                        );
                    resp = int.Parse(ParametrosError.Numero.Value.ToString());
                    resp = (resp == 0) ? 1 : 0;
                }
            }
            catch (Exception e)
            {
                resp = 0;
            }
            return resp;
        }

        public List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiener_UsuariosQueCompartenUPS_Result> Obtiener_UsuariosQueCompartenUPS
        (clsUsuario ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiener_UsuariosQueCompartenUPS_Result>();
            try
            {
                using (var DB = new TramitesDigitalesEntities())
                {
                    respuestaWeb = DB.pa_PeticionesWeb_Bandeja_Peticiones_Obtiener_UsuariosQueCompartenUPS(
                    idUsuario: ParametrosEntrada.IdUsuario,
                    pi_errorNumero: ParametrosError.Numero,
                    pnvc_errorMensaje: ParametrosError.Mensaje,
                    pi_errorLinea: ParametrosError.Linea,
                    pnvc_errorProcAlm: ParametrosError.ProcedimientoAlmacenado,
                    pi_errorSeveridad: ParametrosError.Severidad,
                    pi_errorEstado: ParametrosError.Estado
                    ).ToList();
                }
            }
            catch (Exception e)
            {
                ParametrosError.Mensaje.ToString();
            }
            return respuestaWeb;
        }

    }
}
