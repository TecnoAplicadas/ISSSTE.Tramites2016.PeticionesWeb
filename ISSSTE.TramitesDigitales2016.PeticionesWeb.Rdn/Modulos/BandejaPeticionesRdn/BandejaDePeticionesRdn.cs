using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;

using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.BandejaPeticiones;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.BandejaPeticionesRdn
{
    public class BandejaDePeticionesRdn
    {
        #region Optiene Genero
        BandejaDePeticiones ProcesosBandejaDePetcionesP = new BandejaDePeticiones();
        #endregion

        public List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Usuario_Result> Obtener_Peticiones_UsuarioRdn
        (clsUsuario pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Usuario_Result>();
            try
            {
                #region Funcionalidad del Metodo
                respuestaWeb = ProcesosBandejaDePetcionesP.Obtener_Peticiones_UsuarioP(pEntrada, pError);
                #endregion
            }
            catch (Exception)
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return respuestaWeb;
        }

        /// <summary>
        /// Obtiene las peticiones que cumplen los criterios de consulta
        /// </summary>
        /// <param name="pEntrada"></param>
        /// <param name="pError"></param>
        /// <returns></returns>
        public List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Filtros_Result> Obtener_Peticiones_FiltrosRdn
        (ParamEntradaGeneral ParametrosGenerales, FiltrosPeticion pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Filtros_Result>();
            try
            {
                #region Funcionalidad del Metodo
                respuestaWeb = ProcesosBandejaDePetcionesP.Obtener_Peticiones_FiltrosP(ParametrosGenerales, pEntrada, pError);
                #endregion
            }
            catch (Exception)
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return respuestaWeb;
        }

        /// <summary>
        /// Obtiene toda la información de la petición que se pasa como parámetro
        /// </summary>
        /// <param name="pEntrada"></param>
        /// <param name="pError"></param>
        /// <returns></returns>
        public List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result> Obtener_Peticiones_DetalleRdn
        (clsPeticion pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result>();
            try
            {
                #region Funcionalidad del Metodo
                respuestaWeb = ProcesosBandejaDePetcionesP.Obtener_Peticiones_DetalleP(pEntrada, pError);
                #endregion
            }
            catch (Exception)
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return respuestaWeb;
        }

        /// <summary>
        /// Actualiza la petición, el peticionario y el afectado respectivo
        /// </summary>  
        /// <param name="ParametrosPeticion"></param>
        /// <param name="ParametrosPeticionario"></param>
        /// <param name="ParametrosAfectado"></param>
        /// <param name="ParametrosError"></param>
        /// <returns></returns>
        public int Actualizar_PeticionRdn
        (clsPeticion ParametrosPeticion, clsPeticionario ParametrosPeticionario, 
         clsAfectado ParametrosAfectado,ErrorProcedimientoAlmacenado ParametrosError)
        {
            int resp;
            try
            {
                resp = ProcesosBandejaDePetcionesP.Actualizar_PeticionP(ParametrosPeticion, ParametrosPeticionario, ParametrosAfectado, ParametrosError);
            }
            catch
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return resp;
        }


        /// <summary>
        /// Obtiene el operador asignado a la unidad 
        /// </summary>
        /// <param name="ParametrosPeticion"></param>
        /// <param name="ParametrosError"></param>
        /// <returns></returns>
        public List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiene_Operador_Por_UPS_Result> ObtieneOperadorPorUnidadRdn
        (clsPeticion DatosPeticion, clsUsuario Usuario, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiene_Operador_Por_UPS_Result>();
            try
            {
                #region Funcionalidad del Metodo
                respuestaWeb = ProcesosBandejaDePetcionesP.ObtieneOperadorPorUnidad(DatosPeticion, Usuario, pError);
                #endregion
            }
            catch (Exception)
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return respuestaWeb;
        }

        /// <summary>
        /// Actualiza la petición, el peticionario y el afectado respectivo
        /// </summary>  
        /// <param name="ParametrosPeticion"></param>
        /// <param name="ParametrosPeticionario"></param>
        /// <param name="ParametrosAfectado"></param>
        /// <param name="ParametrosError"></param>
        /// <returns></returns>
        public int AsignarOperadorRdn
        (clsUsuario ParametrosUsuario, clsPeticion ParametrosPeticion, bool OperadorNuevoReasignado, ErrorProcedimientoAlmacenado ParametrosError)
        {
            int resp;
            try
            {
                resp = ProcesosBandejaDePetcionesP.AsignarOperador(ParametrosUsuario, ParametrosPeticion, OperadorNuevoReasignado, ParametrosError);
            }
            catch
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return resp;
        }

        public List<pa_PeticionesWeb_Catalogos_EsatusInterno_Result> ObtenerCatalogoEstatusInternoRdn
        (clsUsuario pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_EsatusInterno_Result>();
            try
            {
                #region Funcionalidad del Metodo
                respuestaWeb = ProcesosBandejaDePetcionesP.ObtenerCatalogoEstatusInterno(pEntrada, pError);
                #endregion
            }
            catch (Exception)
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return respuestaWeb;
        }


        ///+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /// Métodos desarrollados por Luis Solano para Concluir y Cerrar la Petición
        /// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public int ConcluirCerrar_PeticionRdn(clsPeticion ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            int resp = 0;
            BandejaDePeticiones objBandejaDePeticionesP = new BandejaDePeticiones();

            try
            {
                resp = objBandejaDePeticionesP.ConcluirCerrar_PeticionP(ParametrosEntrada, ParametrosError);
            }
            catch
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return resp;
        }



        public List<pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result> ObeterInformacionUsuarioRdn
        (int IdusuarioParam, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result>();
            try
            {
                #region Funcionalidad del Metodo
                respuestaWeb = ProcesosBandejaDePetcionesP.ObeterInformacionUsuario(IdusuarioParam, pError);
                #endregion
            }
            catch (Exception)
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return respuestaWeb;
        }

        public List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_DetalleExportaExcel_Result> ObtenerExcelPeticiones(string CadPeticiones, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_DetalleExportaExcel_Result>();
            try
            {
                respuestaWeb = ProcesosBandejaDePetcionesP.ObtenerExcelPeticiones(CadPeticiones,pError);
            }
            catch (Exception e)
            {
                throw;
            }
            return respuestaWeb;
        }

        public int ActualizarPeticionRdn
       (pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            int respuestaWeb = 0;

            try
            {
                respuestaWeb = ProcesosBandejaDePetcionesP.ActualizarPeticion(ParametrosEntrada, ParametrosError);
            }
            catch (Exception e)
            {
                throw;
            }
            return respuestaWeb;
        }


        public List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiener_UsuariosQueCompartenUPS_Result> Obtiener_UsuariosQueCompartenUPS
        (clsUsuario ParclsUsuario, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiener_UsuariosQueCompartenUPS_Result>();
            try
            {
                respuestaWeb = ProcesosBandejaDePetcionesP.Obtiener_UsuariosQueCompartenUPS(ParclsUsuario, pError);
            }
            catch (Exception e)
            {
                throw;
            }
            return respuestaWeb;
        }




    }
}