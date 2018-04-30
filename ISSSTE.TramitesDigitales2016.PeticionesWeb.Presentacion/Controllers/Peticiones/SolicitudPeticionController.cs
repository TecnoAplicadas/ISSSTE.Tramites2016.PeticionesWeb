using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Catalogos;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.RegistroPeticion;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Utilerias;

using System.Net;
using Newtonsoft.Json.Linq;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Controllers.Peticiones
{
    public class SolicitudPeticionController : Controller
    {
        public JsonResult CatalogoGenero()
        {

            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsGenero cGenero = new clsGenero();
            cGenero.IdGenero = null;
            CrudGeneroRdn catGenero = new CrudGeneroRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result> respGenero = new List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_Generos_Result OpcionSelecciona = new pa_PeticionesWeb_Catalogos_Obtener_Generos_Result();
            //OpcionSelecciona.IdGenero = 0;
            //OpcionSelecciona.Nombre = "<Selecciona>";
            respGenero = catGenero.solicitarGeneros(cGenero, errorErrror);
            //respGenero.Add(OpcionSelecciona);
            return Json(respGenero.OrderBy(g => g.IdGenero), JsonRequestBehavior.AllowGet);


        }
        public JsonResult GetTipoDerechoabiente()
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsTipoDerechoHabiente cTipoDereh = new clsTipoDerechoHabiente();
            cTipoDereh.IdTipoDerechohabiente = null;
            CatalogoTipoDerechoHabienteRdn catTipoDerecoh = new CatalogoTipoDerechoHabienteRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result> respGenero = new List<pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result OpcionSelecciona = new pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result();
            respGenero = catTipoDerecoh.solicitarTipoDerechohabiente(cTipoDereh, errorErrror);
            return Json(respGenero, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetUnidadAdministrativa()
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsTipoUps cUnidadAdm = new clsTipoUps();
            cUnidadAdm.EstatusRegistro = "A";
            CatalogoTipoUpsRdn catUnidadAdm = new CatalogoTipoUpsRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_TipoUps_Result> respuesta = new List<pa_PeticionesWeb_Catalogos_Obtener_TipoUps_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_TipoUps_Result OpcionSelecciona = new pa_PeticionesWeb_Catalogos_Obtener_TipoUps_Result();
            respuesta = catUnidadAdm.solicitarTipoUps(cUnidadAdm, errorErrror);
            return Json(respuesta.OrderBy(T => T.Nombre), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAreas()
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsArea cArea = new clsArea();
            cArea.EstatusRegistro = "A";
            CatalogoAreaRdn catAreaRdn = new CatalogoAreaRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_Areas_Result> respuesta = new List<pa_PeticionesWeb_Catalogos_Obtener_Areas_Result>();
            respuesta = catAreaRdn.ObtenerAreas(cArea, errorErrror);
            return Json(respuesta.OrderBy(T => T.Nombre), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTipoOpinion()
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsTipoOpinion cTipoOpinion = new clsTipoOpinion();
            cTipoOpinion.IdTiposOpinion = null;
            CatalogoTipoOpinionRdn catTipoOpinion = new CatalogoTipoOpinionRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result> respuesta = new List<pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result OpcionSelecciona = new pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result();
            respuesta = catTipoOpinion.solicitarTipoOpinion(cTipoOpinion, errorErrror);
            return Json(respuesta.OrderBy(s => s.Nombre), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCausaAsunto(int idTipoOpinion)
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsCausaAsunto cCausaAsunto = new clsCausaAsunto();
            cCausaAsunto.IdTipoOpinion = idTipoOpinion;
            CatalogoCausasAsuntoRdn catCausaAsunto = new CatalogoCausasAsuntoRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result> respuesta = new List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result OpcionSelecciona = new pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result();
            respuesta = catCausaAsunto.solicitarCausasAsunto(cCausaAsunto, errorErrror);
            return Json(respuesta.OrderBy(T => T.Nombre), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCausaAsuntoPorTipoOpinionYArea(int idTipoOpinion, int idArea)
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsCausaAsunto cCausaAsunto = new clsCausaAsunto();
            cCausaAsunto.IdTipoOpinion = idTipoOpinion;
            cCausaAsunto.IdArea = idArea;
            CatalogoCausasAsuntoRdn catCausaAsuntoRdn = new CatalogoCausasAsuntoRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result> respuesta = new List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result>();
            respuesta = catCausaAsuntoRdn.obtenerCausasAsuntoPorTipoOpinionYArea(cCausaAsunto, errorErrror);
            return Json(respuesta.OrderBy(T => T.Nombre), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetServicioHechos()
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsServicioHecho cServHecho = new clsServicioHecho();
            cServHecho.IdServicioHecho = null;
            CatalogoServiciosHechosRdn catServHecho = new CatalogoServiciosHechosRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result> respuesta = new List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result OpcionSelecciona = new pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result();
            respuesta = catServHecho.solicitarServiciosHecho(cServHecho, errorErrror);
            return Json(respuesta.OrderBy(S => S.Nombre), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetServicioHechosPorArea(int idArea)
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsServicioHecho cServHecho = new clsServicioHecho();
            cServHecho.IdArea = idArea;
            CatalogoServiciosHechosRdn catServHecho = new CatalogoServiciosHechosRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result> respuesta = new List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result>();
            respuesta = catServHecho.ObtenerServiciosHechosPorAreaRdn(cServHecho, errorErrror);
            return Json(respuesta.OrderBy(S => S.Nombre), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDelegacionHospitales()
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsUnidadAdministrativa cUndPrestServ = new clsUnidadAdministrativa();
            cUndPrestServ.EstatusRegistro = "A";
            CatalogoUnidadAdministrativaRdn catServHecho = new CatalogoUnidadAdministrativaRdn();

            List<pa_PeticionesWeb_Catalogos_Obtener_UndadesAdministrativas_Result> respuesta = new List<pa_PeticionesWeb_Catalogos_Obtener_UndadesAdministrativas_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_UndadesAdministrativas_Result OpcionSelecciona = new pa_PeticionesWeb_Catalogos_Obtener_UndadesAdministrativas_Result();
            respuesta = catServHecho.solicitarUnidadAdministrativa(cUndPrestServ, errorErrror);
            return Json(respuesta.OrderBy(U => U.Nombre), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUnidPrestServ(int pIdUnidadAdministrativa)
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsUnidadPrestadoraServicio Miunidad = new clsUnidadPrestadoraServicio();
            Miunidad.IdUnidadAdministrativa = pIdUnidadAdministrativa;
            Miunidad.NivelUps.TipoUps.IdTipoUps = 1;//pIdTipoUps;
            CatalogoUnidadesPrestadoraServicioRdn catUps = new CatalogoUnidadesPrestadoraServicioRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result> respuesta = new List<pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result OpcionSelecciona = new pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result();
            respuesta = catUps.solicitarUnidadPrestServ(Miunidad, errorErrror);
            return Json(respuesta.OrderBy(U => U.Nombre), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEstadoMunicipio(string pCodigoPostal)
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsCodigoPostal cCodPostal = new clsCodigoPostal();
            cCodPostal.Clave = pCodigoPostal;
            CatalogoCodigoPostalRdn catEstado = new CatalogoCodigoPostalRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_CodigosPostales_Result> respuesta = new List<pa_PeticionesWeb_Catalogos_Obtener_CodigosPostales_Result>();
            respuesta = catEstado.solicitarCodigoPostal(cCodPostal, errorErrror);

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Trae el Municipio por medio del CP
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMunicipio(ZipCodeViewModel pCodigoPostal)
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsCodigoPostal cCodPostal = new clsCodigoPostal();
            cCodPostal.Clave = pCodigoPostal.zipCode;
            CatalogoCodigoPostalRdn catEstado = new CatalogoCodigoPostalRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_MunicipioByCodigoPostal_Result> respuesta = new List<pa_PeticionesWeb_Catalogos_Obtener_MunicipioByCodigoPostal_Result>();

            respuesta = catEstado.solicitarMunicipioCP(cCodPostal, errorErrror);
            //return Json(respuesta.OrderBy(M => M.IdMunicipio), JsonRequestBehavior.AllowGet);
            return Json(respuesta.OrderBy(M => M.IdMunicipio), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Trael el Estado por medio del CP
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEstadoCP(ZipCodeViewModel pCodigoPostal)
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsCodigoPostal cCodPostal = new clsCodigoPostal();
            //cCodPostal.Clave = pCodigoPostal.zipCode;
            cCodPostal.Clave = pCodigoPostal.zipCode;
            CatalogoCodigoPostalRdn catEstado = new CatalogoCodigoPostalRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_EstadoByCodigoPostal_Result> respuesta = new List<pa_PeticionesWeb_Catalogos_Obtener_EstadoByCodigoPostal_Result>();
            respuesta = catEstado.solicitarEstadoCP(cCodPostal, errorErrror);
            return Json(respuesta.OrderBy(E => E.IdEstado), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Trae las poblaciones o colinias por medio del codigo postal
        /// </summary>
        /// <param name="pCodigoPostal"></param>
        /// <returns></returns>
        public JsonResult PoblacionesOColoniasCodigoPostal(ZipCodeViewModel pCodigoPostal)
        {
            ErrorProcedimientoAlmacenado errorError = new ErrorProcedimientoAlmacenado();
            clsCodigoPostal cCodPostal = new clsCodigoPostal();
            cCodPostal.Clave = pCodigoPostal.zipCode;
            CatalogoCodigoPostalRdn catPobColonias = new CatalogoCodigoPostalRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_PoblacionesOColoniasByCodigoPostal_Result> respuesta = new List<pa_PeticionesWeb_Catalogos_Obtener_PoblacionesOColoniasByCodigoPostal_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_PoblacionesOColoniasByCodigoPostal_Result OpcionSelecciona = new pa_PeticionesWeb_Catalogos_Obtener_PoblacionesOColoniasByCodigoPostal_Result();
            respuesta = catPobColonias.solicitarPobColCP(cCodPostal, errorError);
            return Json(respuesta.OrderBy(P => P.Nombre), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarPeticion(PeticionViewModel pNewRequest)
        {

            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            Peticion cPeticion = new Peticion();
            cPeticion.Peticionario = new Peticionario();
            cPeticion.Peticionario.Curp = pNewRequest.RequesterCURP;
            cPeticion.Peticionario.Rfc = pNewRequest.RequesterRFC;
            cPeticion.Peticionario.Nombre = pNewRequest.RequesterName;
            cPeticion.Peticionario.ApellidoPaterno = pNewRequest.RequesterFirstName;
            cPeticion.Peticionario.ApellidoMaterno = pNewRequest.RequesterLastName;
            cPeticion.Peticionario.IdGenero = pNewRequest.RequesterGender;
            cPeticion.Peticionario.IdTipoDerechohabiente = pNewRequest.RequesterRightHolderType;
            cPeticion.Peticionario.IdPoblacionOColonia = pNewRequest.RequesterColony;
            cPeticion.Peticionario.Calle = pNewRequest.RequesterStreet;
            cPeticion.Peticionario.NumeroExterior = pNewRequest.ExtNumber;
            cPeticion.Peticionario.NumeroInterior = pNewRequest.IntNumber;
            cPeticion.Peticionario.Lada = pNewRequest.RequesterLada;
            cPeticion.Peticionario.TelefonoFijo = pNewRequest.RequesterFixedPhone;
            cPeticion.Peticionario.TelefonoMovil = pNewRequest.RequesterMobilPhone;
            cPeticion.Peticionario.CorreoElectronico = pNewRequest.RequesterEmail;
            cPeticion.Afectado = new Afectado();
            cPeticion.Afectado.Curp = pNewRequest.AffectedCurp;
            cPeticion.Afectado.Rfc = pNewRequest.AffectedRfc;
            cPeticion.Afectado.Nombre = pNewRequest.AffectedName;
            cPeticion.Afectado.ApellidoPaterno = pNewRequest.AffectedFirstName;
            cPeticion.Afectado.ApellidoMaterno = pNewRequest.AffectedLastName;
            cPeticion.Afectado.IdGenero = pNewRequest.AffectedGender;
            cPeticion.Afectado.IdTipoDerechohabiente = pNewRequest.AffectedRightHolderType;
            cPeticion.Afectado.TelefonoFijo = pNewRequest.AffectedPhoneNumber;
            cPeticion.Afectado.CorreoElectronico = pNewRequest.AffectedEmail;
            cPeticion.IdArea = pNewRequest.Area;
            cPeticion.IdUnidadPrestadoraServicio = pNewRequest.UPS;
            cPeticion.IdServicioHecho = pNewRequest.ServicioHecho;
            cPeticion.IdCausaAsunto = pNewRequest.CausaAsunto;
            cPeticion.FechaHechos = pNewRequest.FechaHechos;
            cPeticion.Descripcion = pNewRequest.Description;
            cPeticion.IdFlujoNotificacion = 1;
            cPeticion.IdFlujoRecordatorio = 1;
            cPeticion.IdFlujoSemaforo = 1;
            cPeticion.IdFlujoEstatus = 1;
            cPeticion.IdEstatusInterno = 1;

            PeticionRdn GuardarPeticion = new PeticionRdn();
            List<pa_PeticionesWeb_Peticion_Guardar_Peticion_Result> respuesta = new List<pa_PeticionesWeb_Peticion_Guardar_Peticion_Result>();

            respuesta = GuardarPeticion.SalvarPeticion(cPeticion, errorErrror);

            foreach (pa_PeticionesWeb_Peticion_Guardar_Peticion_Result itemPeticion in respuesta)
            {
                int idPeticionCorreo;
                ErrorProcedimientoAlmacenado ParametrosError = new ErrorProcedimientoAlmacenado();
                UtileriasCorreo EnvioCorreo = new UtileriasCorreo();

                idPeticionCorreo = itemPeticion.IdPeticion;
                string AppPath = Server.MapPath("~");

                EnvioCorreo.enviarCorreo(idPeticionCorreo, AppPath);
            }

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CaptchaSubmit(string captchaResponse)
        {
            string secretKey = "6LfLMRIUAAAAAItucTrsPplZsAddaWgD_dzX5BKO";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, captchaResponse));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}