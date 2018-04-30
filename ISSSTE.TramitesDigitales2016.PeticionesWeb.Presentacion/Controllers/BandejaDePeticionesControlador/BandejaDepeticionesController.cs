using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.BandejaPeticionesRdn;
using PagedList;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.BandejaPeticiones;
using System.Text.RegularExpressions;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Catalogos;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.SeguimientoOperador;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.PersonalInvolucrado;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Utilerias;
using System.Data;
using ISSSTE.Tramites2015.Common.Security.Helpers;
using Microsoft.Reporting.WebForms;
using System.IO;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Adjuntos;
using System.Configuration;
using Elmah;
using System.Web.Routing;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Controllers.BandejaDePeticionesControlador
{
    [Authorize]
    //[RoutePrefix("Administrador")]
    public class BandejaDepeticionesController : Controller
    {
        #region Variables
        BandejaDePeticionesRdn BandejaDePeticionesc = new BandejaDePeticionesRdn();
        private CatalogoAreaRdn CatalogosAreas = new CatalogoAreaRdn();
        private CatalogoServiciosHechosRdn CatalogoServicioHechosMetodos = new CatalogoServiciosHechosRdn();
        private clsArea ParametrosCatalogoArea = new clsArea();
        private clsServicioHecho ParametrosclsServicioHecho = new clsServicioHecho();

        private List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Usuario_Result> ListPeticiones =
            new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Usuario_Result>();
        private List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Filtros_Result> ListPeticionesFiltradas =
            new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Filtros_Result>();
        private List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiene_Operador_Por_UPS_Result> ListOperadores =
            new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiene_Operador_Por_UPS_Result>();
        private List<pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result> ListaDatosUsuarioActivo =
            new List<pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result>();
        private List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiener_UsuariosQueCompartenUPS_Result> ListaUsuariosQueCompartenUPS =
            new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiener_UsuariosQueCompartenUPS_Result>();

        private List<FiltrosPeticion> ParametrosFiltros = new List<FiltrosPeticion>();
        private FiltrosPeticion pEntrada = new FiltrosPeticion();
        private FiltrosPeticion validarRegistros = new FiltrosPeticion();
        public FiltrosPeticion FiltoActivado = new FiltrosPeticion();

        //private int IdUsuarioIniciodeSeseion = 0;
        //private int IdUsiarioInicioSession = 2;
        private int BusquedaFiltros = 0;
        public ParamEntradaGeneral ParemtrosEntradaGenerales = new ParamEntradaGeneral();

        #endregion

        public ActionResult Reset()
        {
            Session["BusquedaActivadaControl"] = 0;
            Session["ConsultaPorTipoAsignadas"] = 0;

            //return RedirectToAction("BandejaIndex");
            return RedirectToAction("BandejaIndex");


        }

        //[Route("BandejaIndex")]
        public ActionResult BandejaIndex
        (string sortOrder, string currentFilter, string searchString, int? page)
        {

            Session["IdUsuarioActivo"] = Convert.ToInt64(Session["UserLoggedId"].ToString());
            Session["IdPeticionDetalle"] = 0;

            //BusquedaFiltros = Convert.ToInt16(Session["BusquedaActivadaControl"]);
            ParemtrosEntradaGenerales.BusquedaActivada = Convert.ToInt16(Session["BusquedaActivadaControl"]);
            ParemtrosEntradaGenerales.ConsultaPorAsignadas = Convert.ToInt16(Session["ConsultaPorTipoAsignadas"]);
            FiltoActivado = ParametrosFiltros.FirstOrDefault();

            clsUsuario UsuarioAccesado = new clsUsuario();
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            UsuarioAccesado.IdUsuario = Convert.ToInt32(Session["IdUsuarioActivo"]);
            pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result UsuarioDatos = new pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result();
            ConvierteListaDataset ConvierteLIstaADataset = new ConvierteListaDataset();

            ListaDatosUsuarioActivo = BandejaDePeticionesc.ObeterInformacionUsuarioRdn
                                      (Convert.ToInt32(Session["IdUsuarioActivo"]), errorProcedimientoAlmacenado);

            Session["DatosUsuarioActual"] = ListaDatosUsuarioActivo;
            Session["NombreUsiario"] = ListaDatosUsuarioActivo.FirstOrDefault().NombreUsuario.ToString();
            Session["RolIdUsuario"] = ListaDatosUsuarioActivo;

            Session["IdUsuarioController"] = ListaDatosUsuarioActivo.OrderBy(order => order.IdRol).Select(selectId => selectId.IdRol).FirstOrDefault().ToString();
            Session["UserName"] = ListaDatosUsuarioActivo.Select(selectUserName => selectUserName.Username).FirstOrDefault().ToString();
            Session["IdUsuarioRolReportes"] = ListaDatosUsuarioActivo.Where(id => id.IdRol >= 1 && id.IdRol <= 2).OrderBy(order => order.IdRol).Select(selectId => selectId.IdRol).FirstOrDefault().ToString();
            int RolOperador = 3;
            int RolEnlace = 2;

            var DatosParametrosPeticion = (from ListaRolesUsuario in ListaDatosUsuarioActivo
                                           select new
                                           {
                                               IdRol = ListaRolesUsuario.IdRol
                                           }).ToList();
            Session["OcultarControlDeMenuVar"] = "";

            if (DatosParametrosPeticion.Count() == 1)
            {
                if (DatosParametrosPeticion.First().IdRol == RolOperador)
                {
                    string OcultarControl = " hidden = 'hidden'";
                    @ViewBag.ColumnaAsinarOperador = OcultarControl;

                    string OcultarControlDeMenu = "hidden";
                    Session["OcultarControlDeMenuVar"] = OcultarControlDeMenu;
                    @ViewBag.OcultaOpcionMenuDias = OcultarControlDeMenu;
                    @ViewBag.OcultaOpcionMenuReportes = OcultarControlDeMenu;
                    @ViewBag.OcultaOpcionMenuTablero = OcultarControlDeMenu;
                }
            }
            else if (DatosParametrosPeticion.Count() == 2)
            {
                if (DatosParametrosPeticion.First().IdRol == RolEnlace)
                {
                    string OcultarControlDeMenu = "hidden";
                    Session["OcultarControlDeMenuVar"] = OcultarControlDeMenu;
                    @ViewBag.OcultaOpcionMenuDias = OcultarControlDeMenu;
                }
            }

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            ListPeticiones = ResultadosBandejaDePeticiones(ParemtrosEntradaGenerales, FiltoActivado, UsuarioAccesado);//            
            Session["PetionesDescarga"] = ListPeticiones;

            //DataSet PeticionesDataSet = ConvierteLIstaADataset.CreateDataSet(ListPeticiones);

            var VarListaPeticiones = ListPeticiones;


            if (searchString != null)
            {
                page = 1;
            }
            
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                VarListaPeticiones = (VarListaPeticiones.Where(s => s.Folio.Contains(searchString) || s.UPSNombre.Contains(searchString))).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    VarListaPeticiones = (VarListaPeticiones.OrderByDescending(s => s.Folio)).ToList();
                    break;
                case "Date":
                    VarListaPeticiones = (VarListaPeticiones.OrderBy(s => s.UPSNombre)).ToList();
                    break;
                case "date_desc":
                    VarListaPeticiones = VarListaPeticiones.OrderByDescending(s => s.UPSNombre).ToList();
                    break;
                default:  // Name ascending 
                    VarListaPeticiones = VarListaPeticiones.OrderBy(s => s.Folio).ToList();
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);


            return View(VarListaPeticiones.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult BuscarPeticion(int? valida)
        {
            if (valida == null || valida == 0)
            {
                @ViewBag.escondevalidar = 1;
            }
            else
            {
                @ViewBag.escondevalidar = 0;
            }
            clsUsuario ParamPeticion = new clsUsuario();
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();

            ParamPeticion.IdUsuario = Convert.ToInt32(Session["IdUsuarioActivo"]);

            //@ViewBag.OcultaOpcionMenuDias = Session["OcultarControlDeMenuVar"].ToString();
            //@ViewBag.OcultaOpcionMenuReportes = Session["OcultarControlDeMenuVar"].ToString();
            //@ViewBag.OcultaOpcionMenuTablero = Session["OcultarControlDeMenuVar"].ToString();


            #region Catalogos
            pa_PeticionesWeb_Bandeja_Peticiones_Obtiener_UsuariosQueCompartenUPS_Result OpcionSeleccioneUsuarios =
            new pa_PeticionesWeb_Bandeja_Peticiones_Obtiener_UsuariosQueCompartenUPS_Result();
            OpcionSeleccioneUsuarios.IdUsuario = 0;
            OpcionSeleccioneUsuarios.Username = "Seleccione";
            ListaUsuariosQueCompartenUPS = BandejaDePeticionesc.Obtiener_UsuariosQueCompartenUPS(ParamPeticion, errorProcedimientoAlmacenado);
            //ListaUsuariosQueCompartenUPS.Insert(0, OpcionSeleccioneUsuarios);
            ViewBag.CatalogoListaUsuariosQueCompartenUPS = new SelectList(ListaUsuariosQueCompartenUPS, "IdUsuario", "Username");
            Session["UsuariosQueCompartenUPS"] = ListaUsuariosQueCompartenUPS;

            List<pa_PeticionesWeb_Catalogos_EsatusInterno_Result> CatalogoEstatus =
            new List<pa_PeticionesWeb_Catalogos_EsatusInterno_Result>();
            pa_PeticionesWeb_Catalogos_EsatusInterno_Result OpcionSeleccione =
            new pa_PeticionesWeb_Catalogos_EsatusInterno_Result();
            OpcionSeleccione.IdEstatusInterno = 0;
            OpcionSeleccione.Nombre = "Seleccione";
            CatalogoEstatus = BandejaDePeticionesc.ObtenerCatalogoEstatusInternoRdn(ParamPeticion, errorProcedimientoAlmacenado);
            CatalogoEstatus.Insert(0, OpcionSeleccione);
            ViewBag.CatalogoEstatusInternoRdn = new SelectList(CatalogoEstatus, "IdEstatusInterno", "Nombre");


            clsGenero cGenero = new clsGenero();
            cGenero.IdGenero = null;
            CrudGeneroRdn catGenero = new CrudGeneroRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result> respGenero =
            new List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_Generos_Result OpcionSeleccioneSexo =
            new pa_PeticionesWeb_Catalogos_Obtener_Generos_Result();
            OpcionSeleccioneSexo.IdGenero = 0;
            OpcionSeleccioneSexo.Nombre = "Seleccione";
            respGenero = catGenero.solicitarGeneros(cGenero, errorProcedimientoAlmacenado);
            respGenero.Insert(0, OpcionSeleccioneSexo);
            ViewBag.IdGenero = new SelectList(respGenero, "IdGenero", "Nombre");

            clsTipoDerechoHabiente cTipoDereh = new clsTipoDerechoHabiente();
            cTipoDereh.IdTipoDerechohabiente = null;
            CatalogoTipoDerechoHabienteRdn catTipoDerecoh = new CatalogoTipoDerechoHabienteRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result> CatalogoTipoDerecoh =
            new List<pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result OpcionSeleccioneTipoDerechoHabiente =
            new pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result();
            OpcionSeleccioneTipoDerechoHabiente.IdTipoDerechohabiente = 0;
            OpcionSeleccioneTipoDerechoHabiente.Nombre = "Seleccione";
            CatalogoTipoDerecoh = catTipoDerecoh.solicitarTipoDerechohabiente(cTipoDereh, errorProcedimientoAlmacenado);
            CatalogoTipoDerecoh.Insert(0, OpcionSeleccioneTipoDerechoHabiente);
            ViewBag.IdTipoDerechohabiente = new SelectList(CatalogoTipoDerecoh, "IdTipoDerechohabiente", "Nombre");


            clsEstado cEstado = new clsEstado();
            cEstado.IdPais = 1;
            CatalogoEstadoRdn catEstado = new CatalogoEstadoRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_Estados_Result> CatalogoEstado =
            new List<pa_PeticionesWeb_Catalogos_Obtener_Estados_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_Estados_Result OpcionSeleccioneEstado =
            new pa_PeticionesWeb_Catalogos_Obtener_Estados_Result();
            OpcionSeleccioneEstado.IdEstado = 0;
            OpcionSeleccioneEstado.Nombre = "Seleccione";
            CatalogoEstado = catEstado.solicitarEstados(cEstado, errorProcedimientoAlmacenado);
            CatalogoEstado.Insert(0, OpcionSeleccioneEstado);
            ViewBag.CatalogoEstado = new SelectList(CatalogoEstado.ToList(), "IdEstado", "Nombre");

            //Area
            clsTipoUps cUnidadAdm = new clsTipoUps();
            cUnidadAdm.EstatusRegistro = "A";
            CatalogoTipoUpsRdn catUnidadAdm = new CatalogoTipoUpsRdn();            
            List<pa_PeticionesWeb_Catalogos_Obtener_Areas_Result> CatalogoDeAreas =
            new List<pa_PeticionesWeb_Catalogos_Obtener_Areas_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_Areas_Result OpcionSeleccioneUPS = new pa_PeticionesWeb_Catalogos_Obtener_Areas_Result();
            ParametrosCatalogoArea.EstatusRegistro = DatosGenerales.EstatusRegistroActivo;
            OpcionSeleccioneUPS.IdArea = 0;
            OpcionSeleccioneUPS.Nombre = "Seleccione";
            CatalogoDeAreas = CatalogosAreas.ObtenerAreas(ParametrosCatalogoArea, errorProcedimientoAlmacenado);
            CatalogoDeAreas.Insert(0, OpcionSeleccioneUPS);
            ViewBag.CatalogoDeAreas = new SelectList(CatalogoDeAreas.ToList(), "IdArea", "Nombre");

            //Delegación/Hospitales
            clsUnidadAdministrativa cUndPrestServ = new clsUnidadAdministrativa();
            cUndPrestServ.EstatusRegistro = "A";
            CatalogoUnidadAdministrativaRdn CatlogoDelHosp = new CatalogoUnidadAdministrativaRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_UndadesAdministrativas_Result> CatalogoDelegacionHospital =
            new List<pa_PeticionesWeb_Catalogos_Obtener_UndadesAdministrativas_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_UndadesAdministrativas_Result OpcionSeleccioneDel =
            new pa_PeticionesWeb_Catalogos_Obtener_UndadesAdministrativas_Result();
            OpcionSeleccioneDel.IdUnidadAdministrativa = 0;
            OpcionSeleccioneDel.Nombre = "Seleccione";
            CatalogoDelegacionHospital = CatlogoDelHosp.solicitarUnidadAdministrativa(cUndPrestServ, errorProcedimientoAlmacenado);
            CatalogoDelegacionHospital.Insert(0, OpcionSeleccioneDel);
            ViewBag.CatalogoDelegacionHospital = new SelectList(CatalogoDelegacionHospital.ToList(), "IdUnidadAdministrativa", "Nombre");


            clsTipoOpinion cTipoOpinion = new clsTipoOpinion();
            cTipoOpinion.IdTiposOpinion = null;
            CatalogoTipoOpinionRdn catTipoOpinion = new CatalogoTipoOpinionRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result> CatalogoTipoOpinion =
            new List<pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result TipoOpinionSeleccione =
            new pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result();
            TipoOpinionSeleccione.IdTipoOpinion = 0;
            TipoOpinionSeleccione.Nombre = "Seleccione";

            CatalogoTipoOpinion = catTipoOpinion.solicitarTipoOpinion(cTipoOpinion, errorProcedimientoAlmacenado);
            CatalogoTipoOpinion.Insert(0, TipoOpinionSeleccione);
            ViewBag.CatalogoTipoOpinion = new SelectList(CatalogoTipoOpinion, "IdTipoOpinion", "Nombre");


            //clsCausaAsunto cCausaAsunto = new clsCausaAsunto();
            //cCausaAsunto.IdTipoOpinion = null;
            //CatalogoCausasAsuntoRdn catCausaAsunto = new CatalogoCausasAsuntoRdn();
            //List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result> CatalogoCausasAsunto =
            //new List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result>();
            //CatalogoCausasAsunto = catCausaAsunto.solicitarCausasAsunto(cCausaAsunto, errorProcedimientoAlmacenado);
            //ViewBag.CatalogoCausasAsunto = new SelectList(CatalogoCausasAsunto, "IdCausaAsunto", "Nombre");

            //clsServicioHecho cServHecho = new clsServicioHecho();
            //cServHecho.IdServicioHecho = null;
            //CatalogoServiciosHechosRdn catServHecho = new CatalogoServiciosHechosRdn();
            //List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result> CatalogoServHecho =
            //new List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result>();
            //pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result OpcionSeleccioneSer = new pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result();
            //OpcionSeleccioneSer.IdServicioHecho = 0;
            //OpcionSeleccioneSer.Nombre = "Seleccione";
            //CatalogoServHecho = catServHecho.solicitarServiciosHecho(cServHecho, errorProcedimientoAlmacenado);
            //CatalogoServHecho.Insert(0, OpcionSeleccioneSer);
            //ViewBag.CatalogoServHecho = new SelectList(CatalogoServHecho.ToList(), "IdServicioHecho", "Nombre");
            #endregion

            return View();
        }

        [HttpPost]
        public ActionResult BuscarPeticion(ViewModelBuscarPeticion Formulario, FormCollection FormularioControlesRazor)
        {
            Session["ConsultaPorTipoAsignadas"] = Convert.ToInt16(DatosGenerales.ConsultaPorTipo.Inicio);
            string CkxHabilitaOperadoresVar = string.Empty;
            CkxHabilitaOperadoresVar = Request.Form["CkxHabilitaOperadores"];
            string UsuarioSeleccionado = string.Empty;
            string VTxtOperadoresUps = string.Empty;
            ParemtrosEntradaGenerales.ConsultaPorAsignadas = Convert.ToInt16(DatosGenerales.ConsultaPorTipo.Inicio);

            if (CkxHabilitaOperadoresVar == DatosGenerales.HabilitaOperadoresActivo)
            {
                 Session["ConsultaPorTipoAsignadas"]  = Convert.ToInt16(DatosGenerales.ConsultaPorTipo.Asignadas);
                 UsuarioSeleccionado = Request["ID"].ToString();
                 VTxtOperadoresUps = (Request["TxtOperadoresUps"].ToString()).TrimEnd().TrimStart();
            }

            ListaUsuariosQueCompartenUPS =
            (List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiener_UsuariosQueCompartenUPS_Result>)Session["UsuariosQueCompartenUPS"];
            var UsuarioUps = ListaUsuariosQueCompartenUPS.SingleOrDefault(l => l.Username == VTxtOperadoresUps);

            if (VTxtOperadoresUps == "")
            {
                pEntrada.IdUsuario = Convert.ToInt32(Session["IdUsuarioActivo"]);
            }
            else
            {
                if (UsuarioUps == null)
                {
                    pEntrada.IdUsuario = -1;
                }
                if (UsuarioUps != null)
                {
                    pEntrada.IdUsuario = UsuarioUps.IdUsuario;//Convert.ToInt32(Session["IdUsuarioActivo"]);
                }
            }

            int CatCauAsu = 0;
            int CatTipOp = Convert.ToInt16(Request["CatalogoTipoOpinion"]);
            string folio = Request["FoliotTxt"].ToString();
            int CatalogoServicioHecho = 0;

            if (string.IsNullOrEmpty(Request["CatlogoCausaAsunto"]))
            {
                CatCauAsu = 0;
            }
            else
            {
                CatCauAsu = Convert.ToInt16(Request["CatlogoCausaAsunto"]);
            }

            if (string.IsNullOrEmpty(Request["CatalogoServicioHecho"]))
            {
                pEntrada.IdServicioHecho = 0;
            }
            else
            {
                pEntrada.IdServicioHecho = Convert.ToInt16(Request["CatalogoServicioHecho"]);
            }

            int UniAdmin = Convert.ToInt16(Request["CatalogoDeAreas"]);
            int DelHosp = Convert.ToInt16(Request["CatalogoDelegacionHospital"]);

            if (folio == "" &&
              Formulario.CataloEstatus.Clave == null &&
              Formulario.CataloEstatus.IdEstatusInterno == 0 &&
              Formulario.Detalle_peticionBusqueda.CurpPeticionario == null &&
              Formulario.Detalle_peticionBusqueda.RfcPeticionario == null &&
              Formulario.Detalle_peticionBusqueda.NombrePeticionario == null &&
              Formulario.Detalle_peticionBusqueda.ApePaternoPeticionario == null &&
              Formulario.Detalle_peticionBusqueda.ApeMaternoPeticionario == null &&
              Formulario.CataloGenero.IdGenero == 0 &&
              Formulario.CatalogoTiposDerhabiente.IdTipoDerechohabiente == 0 &&
              Formulario.Detalle_peticionBusqueda.CPPeticionario == null &&
              Formulario.CatalogoEstado.IdEstado == 0 &&
              Formulario.Detalle_peticionBusqueda.ColoniaPeticionario == null &&
              Formulario.Detalle_peticionBusqueda.CallePeticionario == null &&
              Formulario.Detalle_peticionBusqueda.MpioPeticionario == null &&
              Formulario.Detalle_peticionBusqueda.NumeroExteriorPeticionario == null &&
              Formulario.Detalle_peticionBusqueda.NumeroInteriorPeticionario == null &&
              Formulario.Detalle_peticionBusqueda.LadaPeticionario == null &&
              Formulario.Detalle_peticionBusqueda.TelefonoFijoPeticionario == null &&
              Formulario.Detalle_peticionBusqueda.TelefonoMovilPeticionario == null &&
              Formulario.Detalle_peticionBusqueda.CorreoElectronicoPeticionario == null &&
              Formulario.Detalle_peticionBusqueda.CurpAfectado == null &&
              Formulario.Detalle_peticionBusqueda.RfcAfectado == null &&
              Formulario.Detalle_peticionBusqueda.NombreAfectado == null &&
              Formulario.Detalle_peticionBusqueda.ApePaternoAfectado == null &&
              Formulario.Detalle_peticionBusqueda.ApeMaternoAfectado == null &&
              Formulario.CataloGeneroAfectado.IdGenero == 0 &&
              Formulario.CatalogoTiposDerhabienteAfectado.IdTipoDerechohabiente == 0 &&
              Formulario.Detalle_peticionBusqueda.TelefonoFijoAfectado == null &&
              Formulario.Detalle_peticionBusqueda.CorreoElectronicoAfectado == null &&
              pEntrada.IdCausaAsunto == 0 &&
              CatTipOp == 0 &&
              CatCauAsu == 0 &&
              Formulario.Detalle_peticionBusqueda.FechaRegistro == null &&
              Formulario.Detalle_peticionBusqueda.FechaRegistroFin == null &&
              Formulario.Detalle_peticionBusqueda.FechaHechos == null &&
              pEntrada.IdServicioHecho == 0 &&

              //Formulario.CatalogoServicioHecho.IdServicioHecho == 0 &&
              Formulario.Detalle_peticionBusqueda.Descripcion == null &&
              UniAdmin == 0 &&
              DelHosp == 0 &&
              VTxtOperadoresUps == ""
              )
            {
                TempData["Error"] = 1;
                int BotonCerrarPeticion = 1;
                @ViewBag.escondevalidar = BotonCerrarPeticion;
                return RedirectToAction("BuscarPeticion", new RouteValueDictionary(new { valida = 1 }));
            }
            else
            {
                ViewModelBuscarPeticion VistaBuscar = new ViewModelBuscarPeticion();

                ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
                BusquedaFiltros = 1;
                //pEntrada.IdUsuario = Convert.ToInt32(Session["IdUsuarioActivo"]);
                pEntrada.Folio = Request["FoliotTxt"].ToString();
                pEntrada.IdEstatusInterno = Formulario.CataloEstatus.IdEstatusInterno; // Convert.ToInt32(Request["CatalogoEstatusInternoRdn"]);

                #region Datos del peticionario
                pEntrada.Curp = Formulario.Detalle_peticionBusqueda.CurpPeticionario;
                pEntrada.Rfc = Formulario.Detalle_peticionBusqueda.RfcPeticionario;     // Request["rfcPetTxt"].ToString(); 
                pEntrada.Nombre = Formulario.Detalle_peticionBusqueda.NombrePeticionario;  // Request["nombreTxt"].ToString();
                pEntrada.ApellidoPaterno = Formulario.Detalle_peticionBusqueda.ApePaternoPeticionario;     //Request["apPaternoTxt"].ToString();
                pEntrada.ApellidoMaterno = Formulario.Detalle_peticionBusqueda.ApeMaternoPeticionario;     //Request["apMaternoTxt"].ToString();
                pEntrada.IdGenero = Formulario.CataloGenero.IdGenero; //Convert.ToInt16(Request["sexoSlct"]);
                pEntrada.IdTipoDerechohabiente = Formulario.CatalogoTiposDerhabiente.IdTipoDerechohabiente;// Convert.ToInt16(Request["tipoDerSlct"]);
                #endregion

                #region Datos de contacto
                pEntrada.ClaveCP = Formulario.Detalle_peticionBusqueda.CPPeticionario; //Request["codPostTxt"].ToString();
                pEntrada.IdEstado = Formulario.CatalogoEstado.IdEstado; //Convert.ToInt16(Request["estadoSlct"]);
                                                                        //pEntrada.IdMunicipio =// Convert.ToInt16(Request["municipioSlct"]);
                pEntrada.NombreColonia = Formulario.Detalle_peticionBusqueda.ColoniaPeticionario;
                //(string.IsNullOrEmpty(Request["coloniaTxt"].ToString())) ? "": Request["coloniaTxt"].ToString();
                pEntrada.Calle = Formulario.Detalle_peticionBusqueda.CallePeticionario;
                pEntrada.NumeroExterior = Formulario.Detalle_peticionBusqueda.NumeroExteriorPeticionario;
                pEntrada.NumeroInterior = Formulario.Detalle_peticionBusqueda.NumeroInteriorPeticionario;
                pEntrada.Lada = Formulario.Detalle_peticionBusqueda.LadaPeticionario;
                pEntrada.TelefonoFijo = Formulario.Detalle_peticionBusqueda.TelefonoFijoPeticionario;
                pEntrada.TelefonoMovil = Formulario.Detalle_peticionBusqueda.TelefonoMovilPeticionario;
                pEntrada.CorreoElectronico = Formulario.Detalle_peticionBusqueda.CorreoElectronicoPeticionario;
                #endregion

                #region Datos del afectado
                pEntrada.CurpAfectado = Formulario.Detalle_peticionBusqueda.CurpAfectado;
                pEntrada.RfcAfectado = Formulario.Detalle_peticionBusqueda.RfcAfectado;
                pEntrada.NombreAfectado = Formulario.Detalle_peticionBusqueda.NombreAfectado;
                pEntrada.ApellidoPaternoAfectado = Formulario.Detalle_peticionBusqueda.ApePaternoAfectado;
                pEntrada.ApellidoMaternoAfectado = Formulario.Detalle_peticionBusqueda.ApeMaternoAfectado;
                pEntrada.IdGeneroAfectado = Formulario.CataloGeneroAfectado.IdGenero;
                pEntrada.IdTipoDhbAfectado = Formulario.CatalogoTiposDerhabienteAfectado.IdTipoDerechohabiente;
                pEntrada.TelefonoFijoAfectado = Formulario.Detalle_peticionBusqueda.TelefonoFijoAfectado;
                pEntrada.CorreoElectronicoAfectado = Formulario.Detalle_peticionBusqueda.CorreoElectronicoAfectado;
                #endregion

                #region Descripción de la petición
                pEntrada.IdTipoUps = Convert.ToInt16(Request["CatalogoDeAreas"]);                       //area
                //pEntrada.IdUnidadAdministrativa = Convert.ToInt16(Request["delPeticionSlct"]);          //delegacion
                //pEntrada.IdUnidadPrestadoraServicio = Convert.ToInt16(Request["unidadPeticionSlct"]);
                pEntrada.IdUnidadAdministrativa = int.Parse(Request["CatalogoDelegacionHospital"].ToString());
                pEntrada.IdTipoOpinion = Convert.ToInt16(Request["CatalogoTipoOpinion"]); // Formulario.CatalogoTipoOpinion.IdTipoOpinion;
                if (string.IsNullOrEmpty(Request["CatlogoCausaAsunto"]))
                {
                    pEntrada.IdCausaAsunto = 0;
                }
                else
                {
                    pEntrada.IdCausaAsunto = Convert.ToInt16(Request["CatlogoCausaAsunto"]);
                }

                if (Formulario.Detalle_peticionBusqueda.FechaHechos.ToString() == "01/01/0001")
                    pEntrada.FechaHechos = "";
                else
                    pEntrada.FechaHechos = Formulario.Detalle_peticionBusqueda.FechaHechos.ToString();

                if (Formulario.Detalle_peticionBusqueda.FechaRegistro == null)
                    pEntrada.FechaRegistro = "";
                else
                    pEntrada.FechaRegistro = Formulario.Detalle_peticionBusqueda.FechaRegistro.ToString();

                if (Formulario.Detalle_peticionBusqueda.FechaRegistroFin == null)
                    pEntrada.FechaRegistroFin = "";
                else
                    pEntrada.FechaRegistroFin = Formulario.Detalle_peticionBusqueda.FechaRegistroFin.ToString();


                //pEntrada.IdServicioHecho = Formulario.CatalogoServicioHecho.IdServicioHecho;
                pEntrada.Descripcion = Formulario.Detalle_peticionBusqueda.Descripcion;
                #endregion

                TempData["BusquedaFiltros"] = 1;
                TempData["FiltrosActivados"] = pEntrada; //validarRegistros;

                ParametrosFiltros.Add(pEntrada);
                Session["Filtros"] = pEntrada;
                Session["BusquedaActivadaControl"] = 1;

                return RedirectToAction("BandejaIndex");
            }
        }

        public List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Usuario_Result> ResultadosBandejaDePeticiones
        (ParamEntradaGeneral BusquedaActivada, FiltrosPeticion FiltrosPeticionA, clsUsuario UsuarioAccesado)
        {

            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            ListPeticiones.Clear();

            FiltrosPeticion FiltrosPeticionB = (FiltrosPeticion)Session["Filtros"];
            //var Filtros = Session["Filtros"];

            if (BusquedaActivada.BusquedaActivada == 0)
            {
                Session["BusquedaActivadaControl"] = 0;


                ListPeticiones = BandejaDePeticionesc.Obtener_Peticiones_UsuarioRdn
                (UsuarioAccesado, errorProcedimientoAlmacenado).ToList();
            }
            if (BusquedaActivada.BusquedaActivada == 1)
            {

                ListPeticionesFiltradas = BandejaDePeticionesc.Obtener_Peticiones_FiltrosRdn(BusquedaActivada, FiltrosPeticionB, errorProcedimientoAlmacenado).ToList();


                foreach (pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Filtros_Result item in ListPeticionesFiltradas)
                {
                    pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Usuario_Result PeticionEnlazada
                    = new pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Usuario_Result();

                    PeticionEnlazada.IdOperador = item.IdOperador;
                    PeticionEnlazada.IdPeticion = item.IdPeticion;
                    PeticionEnlazada.Folio = item.Folio;
                    PeticionEnlazada.UPSNombre = item.UPSNombre;
                    PeticionEnlazada.FechaHechos = item.FechaHechos;
                    PeticionEnlazada.CausaAsunto = item.CausaAsunto;
                    PeticionEnlazada.NombreUsuario = item.NombreUsuario;
                    PeticionEnlazada.IdUPS = item.IdUPS;
                    PeticionEnlazada.SemaforoPeticion = item.SemaforoPeticion;
                    PeticionEnlazada.IdEstatusInterno = item.IdEstatusInterno;

                    ListPeticiones.Add(PeticionEnlazada);
                }
            }

            return ListPeticiones;
        }

        public ActionResult AsignarOperador(FormCollection EntradaPeticion)
        {
            clsPeticion DatosPeticion = new clsPeticion();
            clsUsuario UsuarioAutenticado = new clsUsuario();
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            DatosPeticion.IdUnidadPrestadoraServicio = Convert.ToInt32(Request["IdUPSPar"]);
            UsuarioAutenticado.IdUsuario = Convert.ToInt32(Session["IdUsuarioActivo"]);
            //string FolioPeticion = Request["IdFolioPar"].ToString();
            //string IdUPS 
            TempData["IdPeticion"] = Request["IdPeticion"].ToString();
            TempData["Reasigancionoperador"] = Request["Reasigancionoperador"].ToString();

            ListOperadores = BandejaDePeticionesc.ObtieneOperadorPorUnidadRdn
                                                  (DatosPeticion, UsuarioAutenticado, errorProcedimientoAlmacenado).ToList();
            return View(ListOperadores);
        }

        [HttpPost]
        public ActionResult AsignarOperador
        (pa_PeticionesWeb_Bandeja_Peticiones_Obtiene_Operador_Por_UPS_Result Formulario)
        {
            string IdUsuarioOperador = Formulario.NombreOperador.ToString().Substring(14);
            IdUsuarioOperador = Regex.Replace(IdUsuarioOperador, "}", "");
            int IdUsuarioOperadorPar = Convert.ToInt32(IdUsuarioOperador);
            clsUsuario ParametrosUsuario = new clsUsuario();
            clsPeticion pEntrada = new clsPeticion();
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            ParametrosUsuario.IdUsuario = Convert.ToInt32(Session["IdUsuarioActivo"]);
            pEntrada.IdOperador = IdUsuarioOperadorPar;
            pEntrada.IdPeticion = Convert.ToInt32(TempData["IdPeticion"]);
            bool OperadorNuevoReasignado = Convert.ToBoolean(TempData["Reasigancionoperador"]);

            BandejaDePeticionesc.AsignarOperadorRdn(ParametrosUsuario, pEntrada, OperadorNuevoReasignado, errorProcedimientoAlmacenado);

            return RedirectToAction("BandejaIndex");
        }
        public ActionResult DetalleSolicitudActualizacion()
        {
            FiltrosPeticion DetalleDePeticion = new FiltrosPeticion();
            clsPeticion PEntrada = new clsPeticion();
            pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result DetallePeticion =
            new pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result();
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();

            PEntrada.IdPeticion = 53;

            DetallePeticion = BandejaDePeticionesc.Obtener_Peticiones_DetalleRdn
            (PEntrada, errorProcedimientoAlmacenado).FirstOrDefault();

            #region Catalogos
            clsGenero cGenero = new clsGenero();
            cGenero.IdGenero = null;
            CrudGeneroRdn catGenero = new CrudGeneroRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result> respGenero =
            new List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result>();
            respGenero = catGenero.solicitarGeneros(cGenero, errorProcedimientoAlmacenado);
            ViewBag.IdGenero = new SelectList(respGenero, "IdGenero", "Nombre");

            clsTipoDerechoHabiente cTipoDereh = new clsTipoDerechoHabiente();
            cTipoDereh.IdTipoDerechohabiente = null;
            CatalogoTipoDerechoHabienteRdn catTipoDerecoh = new CatalogoTipoDerechoHabienteRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result> CatalogoTipoDerecoh =
            new List<pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result>();
            CatalogoTipoDerecoh = catTipoDerecoh.solicitarTipoDerechohabiente(cTipoDereh, errorProcedimientoAlmacenado);
            ViewBag.IdTipoDerechohabiente = new SelectList(CatalogoTipoDerecoh, "IdTipoDerechohabiente", "Nombre");

            clsEstado cEstado = new clsEstado();
            cEstado.IdPais = 1;
            CatalogoEstadoRdn catEstado = new CatalogoEstadoRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_Estados_Result> CatalogoEstado =
            new List<pa_PeticionesWeb_Catalogos_Obtener_Estados_Result>();
            CatalogoEstado = catEstado.solicitarEstados(cEstado, errorProcedimientoAlmacenado);
            ViewBag.CatalogoEstado = new SelectList(CatalogoEstado, "IdEstado", "Nombre");

            clsTipoOpinion cTipoOpinion = new clsTipoOpinion();
            cTipoOpinion.IdTiposOpinion = null;
            CatalogoTipoOpinionRdn catTipoOpinion = new CatalogoTipoOpinionRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result> CatalogoTipoOpinion =
            new List<pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result>();
            CatalogoTipoOpinion = catTipoOpinion.solicitarTipoOpinion(cTipoOpinion, errorProcedimientoAlmacenado);
            ViewBag.CatalogoTipoOpinion = new SelectList(CatalogoTipoOpinion, "IdTipoOpinion", "Nombre");

            clsCausaAsunto cCausaAsunto = new clsCausaAsunto();
            cCausaAsunto.IdCausaAsunto = null;
            CatalogoCausasAsuntoRdn catCausaAsunto = new CatalogoCausasAsuntoRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result> CatalogoCausasAsunto =
            new List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result>();
            CatalogoCausasAsunto = catCausaAsunto.solicitarCausasAsunto(cCausaAsunto, errorProcedimientoAlmacenado);
            ViewBag.CatalogoCausasAsunto = new SelectList(CatalogoCausasAsunto, "IdCausaAsunto", "Nombre");

            clsServicioHecho cServHecho = new clsServicioHecho();
            cServHecho.IdServicioHecho = null;
            CatalogoServiciosHechosRdn catServHecho = new CatalogoServiciosHechosRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result> CatalogoServHecho =
            new List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result>();
            CatalogoServHecho = catServHecho.solicitarServiciosHecho(cServHecho, errorProcedimientoAlmacenado);
            ViewBag.CatalogoServHecho = new SelectList(CatalogoServHecho, "IdServicioHecho", "Nombre");
            #endregion

            return View(DetallePeticion);
        }

        public ActionResult MenuDetalle(clsPeticion objPeticion)
        {
            FiltrosPeticion DetalleDePeticion = new FiltrosPeticion();
            clsPeticion PEntrada = new clsPeticion();
            pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result DetallePeticion =
            new pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result();
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            List<pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result> ListaDatosDeUsuarioActual =
            (List<pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result>)Session["DatosUsuarioActual"];

            ListaDatosUsuarioActivo = ListaDatosDeUsuarioActual;
            var IdRolUsuario = ListaDatosDeUsuarioActual.OrderBy(order => order.IdRol).Select(selectId => selectId.IdRol).FirstOrDefault();
            if (IdRolUsuario == 3)
            {
                @ViewBag.OcultaOpcionMenuDias = Session["OcultarControlDeMenuVar"].ToString();
                @ViewBag.OcultaOpcionMenuReportes = Session["OcultarControlDeMenuVar"].ToString();
                @ViewBag.OcultaOpcionMenuTablero = Session["OcultarControlDeMenuVar"].ToString();
            }



            if (Convert.ToInt32(Request["IdPeticion"]) == 0)
            {
                PEntrada.IdPeticion = Convert.ToInt32(Session["IdPeticionDetalle"]);
            }
            else
            {
                Session["IdPeticionDetalle"] = Convert.ToInt32(Request["IdPeticion"]);
                PEntrada.IdPeticion = Convert.ToInt32(Session["IdPeticionDetalle"]);
            }



            DetallePeticion = BandejaDePeticionesc.Obtener_Peticiones_DetalleRdn
            (PEntrada, errorProcedimientoAlmacenado).FirstOrDefault();

            Session["DetallePeticion"] = DetallePeticion;

            string OcultaMenu = string.Empty;
            string BotonCerrarPeticion = string.Empty;
            Session["IdEstatusInterno"] = DetallePeticion.IdEstatusInterno;

            // & (DetallePeticion.IdOperador == IdUsuarioIniciodeSeseion))
            if ((DetallePeticion.IdEstatusInterno < 2 || DetallePeticion.IdOperador != Convert.ToInt32(Session["IdUsuarioActivo"])))
            {
                OcultaMenu = "hidden='hidden'";
                @ViewBag.OcultaTab = OcultaMenu;
            }
            if ((DetallePeticion.IdEstatusInterno != 4))
            {
                BotonCerrarPeticion = "hidden='hidden'";
                @ViewBag.BotonCerrarPeticion = BotonCerrarPeticion;
            }
            if ((DetallePeticion.IdEstatusInterno == 4) & (DetallePeticion.IdOperador == Convert.ToInt32(Session["IdUsuarioActivo"])))
            {
                OcultaMenu = "hidden='hidden'";
                @ViewBag.OcultaTab = OcultaMenu;
                //BotonCerrarPeticion = "hidden='hidden'";
                @ViewBag.BotonCerrarPeticion = BotonCerrarPeticion;
            }
            if ((DetallePeticion.IdEstatusInterno == 5) & (DetallePeticion.IdOperador == Convert.ToInt32(Session["IdUsuarioActivo"])))
            {
                BotonCerrarPeticion = "hidden='hidden'";
                @ViewBag.BotonCerrarPeticion = BotonCerrarPeticion;
                OcultaMenu = "hidden='hidden'";
                @ViewBag.OcultaTab = BotonCerrarPeticion;

                @ViewBag.BotonesEditarPeticion = BotonCerrarPeticion;
            }

            if (DetallePeticion.IdEstatusInterno == 5)
            {
                string OculatarBotonesEditar = "hidden='hidden'";
                @ViewBag.BotonesEditarPeticion = OculatarBotonesEditar;
            }

            //Oculta Boton Cerrar peticion y Edicion para el  Operador 
            if (ListaDatosUsuarioActivo.Count == 1
                && ListaDatosUsuarioActivo.FirstOrDefault().IdRol == (int)DatosGenerales.IdRolUsuario.Operador)
            {
                @ViewBag.BotonCerrarPeticion = DatosGenerales.Ocultar;
                @ViewBag.BotonesEditarPeticion = DatosGenerales.Ocultar;
            }

            #region Catalogos
            clsGenero cGenero = new clsGenero();
            cGenero.IdGenero = null;
            CrudGeneroRdn catGenero = new CrudGeneroRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result> respGenero =
            new List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result>();


            List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result> GegeroEncontrado =
            new List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result>();
            int GeneroP = DetallePeticion.IdGeneroPeticionario;
            respGenero = catGenero.solicitarGeneros(cGenero, errorProcedimientoAlmacenado).Where(x => x.IdGenero == GeneroP).ToList();
            ViewBag.IdGenero = new SelectList(respGenero, "IdGenero", "Nombre");

            clsTipoDerechoHabiente cTipoDereh = new clsTipoDerechoHabiente();
            cTipoDereh.IdTipoDerechohabiente = null;
            CatalogoTipoDerechoHabienteRdn catTipoDerecoh = new CatalogoTipoDerechoHabienteRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result> CatalogoTipoDerecoh =
            new List<pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result>();
            int IdTipoDerechohabienteP = DetallePeticion.IdTipoDhbPeticionario;
            CatalogoTipoDerecoh = catTipoDerecoh.solicitarTipoDerechohabiente
            (cTipoDereh, errorProcedimientoAlmacenado).Where(x => x.IdTipoDerechohabiente == IdTipoDerechohabienteP).ToList();
            ViewBag.IdTipoDerechohabiente = new SelectList(CatalogoTipoDerecoh, "IdTipoDerechohabiente", "Nombre");

            clsTipoDerechoHabiente cTipoDerehAfectado = new clsTipoDerechoHabiente();
            cTipoDerehAfectado.IdTipoDerechohabiente = null;
            List<pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result> CatalogoTipoDerecohAfectado =
            new List<pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result>();
            int IdTipoDerechohabienteAfectadoP = DetallePeticion.IdTipoDhbAfectado;
            CatalogoTipoDerecohAfectado = catTipoDerecoh.solicitarTipoDerechohabiente
            (cTipoDerehAfectado, errorProcedimientoAlmacenado).ToList();
            ViewBag.IdTipoDerechohabienteAfectado = new SelectList(CatalogoTipoDerecohAfectado, "IdTipoDerechohabiente", "Nombre", IdTipoDerechohabienteAfectadoP);

            clsEstado cEstado = new clsEstado();
            cEstado.IdPais = 1;
            CatalogoEstadoRdn catEstado = new CatalogoEstadoRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_Estados_Result> CatalogoEstado =
            new List<pa_PeticionesWeb_Catalogos_Obtener_Estados_Result>();
            string EdoPeticionarioP = DetallePeticion.EdoPeticionario;
            CatalogoEstado = catEstado.solicitarEstados
            (cEstado, errorProcedimientoAlmacenado).Where(x => x.Nombre == EdoPeticionarioP).ToList();
            ViewBag.CatalogoEstado = new SelectList(CatalogoEstado, "IdEstado", "Nombre");


            List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result> GeneroPeti =
            new List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result>();
            int GeneroPeticionarioP = DetallePeticion.IdGeneroPeticionario;
            GeneroPeti = catGenero.solicitarGeneros(cGenero, errorProcedimientoAlmacenado).ToList();
            //ViewBag.IdGenero = new SelectList(departmentsQuery, "DepartmentID", "Name", selectedDepartment);
            ViewBag.IdGenero = new SelectList(GeneroPeti, "IdGenero", "Nombre", GeneroPeticionarioP);
            bool GeneroPetiMasculino = false;
            bool GeneroAPetiFemenino = false;
            GeneroPetiMasculino = (GeneroPeticionarioP == 1) ? true : false;
            GeneroAPetiFemenino = (GeneroPeticionarioP == 2) ? true : false;
            ViewData["GeneroPetiMasculino"] = GeneroPetiMasculino;
            ViewData["GeneroAPetiFemenino"] = GeneroAPetiFemenino;

            List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result> GeneroAfectado =
            new List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result>();
            int GeneroAfectadoP = DetallePeticion.IdGeneroAfectado;
            GeneroAfectado = catGenero.solicitarGeneros(cGenero, errorProcedimientoAlmacenado).ToList();
            //ViewBag.IdGenero = new SelectList(departmentsQuery, "DepartmentID", "Name", selectedDepartment);
            ViewBag.IdGeneroAfectado = new SelectList(GeneroAfectado, "IdGenero", "Nombre", GeneroAfectadoP);
            bool GeneroAfectadoMasculino = false;
            bool GeneroAfectadoFemenino = false;
            GeneroAfectadoMasculino = (GeneroAfectadoP == 1) ? true : false;
            GeneroAfectadoFemenino = (GeneroAfectadoP == 2) ? true : false;
            ViewData["GeneroAfectadoMasculino"] = GeneroAfectadoMasculino;
            ViewData["GeneroAfectadoFemenino"] = GeneroAfectadoFemenino;




            //Area
            //clsTipoUps cUnidadAdm = new clsTipoUps();
            //cUnidadAdm.EstatusRegistro = "A";
            //CatalogoTipoUpsRdn catUnidadAdm = new CatalogoTipoUpsRdn();
            //List<pa_PeticionesWeb_Catalogos_Obtener_TipoUps_Result> CatalogoTipoUPS =
            //new List<pa_PeticionesWeb_Catalogos_Obtener_TipoUps_Result>();
            //int TipoUpsAreaP = DetallePeticion.IdAreaPeticion;
            //CatalogoTipoUPS =
            //catUnidadAdm.solicitarTipoUps(cUnidadAdm, errorProcedimientoAlmacenado).Where(x => x.IdTipoUps == TipoUpsAreaP).ToList();
            //ViewBag.CatalogoTipoUPS = new SelectList(CatalogoTipoUPS, "IdTipoUps", "Nombre");

            List<pa_PeticionesWeb_Catalogos_Obtener_Areas_Result> CatalogoDeAreas =
            new List<pa_PeticionesWeb_Catalogos_Obtener_Areas_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_Areas_Result OpcionSeleccioneUPS = new pa_PeticionesWeb_Catalogos_Obtener_Areas_Result();
            pa_PeticionesWeb_Catalogos_Obtener_Areas_Result OpcionSeleccionar = new pa_PeticionesWeb_Catalogos_Obtener_Areas_Result();

            string NombreAreaDetalleP = DetallePeticion.NombreArea;
            int IdAreaDetalleP = DetallePeticion.IdArea;
            ParametrosCatalogoArea.EstatusRegistro = DatosGenerales.EstatusRegistroActivo;
            OpcionSeleccionar.IdArea =Convert.ToInt16(DatosGenerales.Seleccion.SeleccioneIdCero);
            OpcionSeleccionar.Nombre = DatosGenerales.OpcionSeleccionar;

            OpcionSeleccioneUPS = 
            CatalogosAreas.ObtenerAreas(ParametrosCatalogoArea, errorProcedimientoAlmacenado).Where(c => c.IdArea == IdAreaDetalleP).FirstOrDefault();
            CatalogoDeAreas = CatalogosAreas.ObtenerAreas(ParametrosCatalogoArea, errorProcedimientoAlmacenado).Where(c => c.IdArea != IdAreaDetalleP).ToList();
            CatalogoDeAreas.Insert(0, OpcionSeleccioneUPS);
            //CatalogoDeAreas.Insert(1, OpcionSeleccionar);

            SelectList ListCatalogoDeAreas = new SelectList(CatalogoDeAreas.ToList(), "IdArea", "Nombre", NombreAreaDetalleP);

            ViewBag.CatalogoDeAreas = ListCatalogoDeAreas;
            ViewData["CatalogoDeAreas"] = ListCatalogoDeAreas;

            //Delegación/Hospitales
            clsUnidadAdministrativa cUndPrestServ = new clsUnidadAdministrativa();
            cUndPrestServ.EstatusRegistro = "A";
            CatalogoUnidadAdministrativaRdn CatlogoDelHosp = new CatalogoUnidadAdministrativaRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_UndadesAdministrativas_Result> CatalogoDelegacionHospital =
            new List<pa_PeticionesWeb_Catalogos_Obtener_UndadesAdministrativas_Result>();
            int IdDelegacionP = DetallePeticion.IdUnidadAdministrativa;
            CatalogoDelegacionHospital =
            CatlogoDelHosp.solicitarUnidadAdministrativa(cUndPrestServ, errorProcedimientoAlmacenado).Where
            (x => x.IdUnidadAdministrativa == IdDelegacionP).ToList();
            ViewBag.CatalogoDelegacionHospital = new SelectList(CatalogoDelegacionHospital, "IdUnidadAdministrativa", "Nombre");

            clsTipoOpinion cTipoOpinion = new clsTipoOpinion();
            cTipoOpinion.IdTiposOpinion = null;
            CatalogoTipoOpinionRdn catTipoOpinion = new CatalogoTipoOpinionRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result> CatalogoTipoOpinion =
            new List<pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result Opinionseleccionada =
            new pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result();

            int IdOpcionSeleccionada = DetallePeticion.IdTipoOpinion;

            Opinionseleccionada =
            catTipoOpinion.solicitarTipoOpinion(cTipoOpinion, errorProcedimientoAlmacenado).Where(c => c.IdTipoOpinion == IdOpcionSeleccionada).FirstOrDefault();
            CatalogoTipoOpinion = 
            catTipoOpinion.solicitarTipoOpinion(cTipoOpinion, errorProcedimientoAlmacenado).Where(c => c.IdTipoOpinion != IdOpcionSeleccionada).ToList();

            CatalogoTipoOpinion.Insert(0, Opinionseleccionada);
            ViewBag.CatalogoTipoOpinion = new SelectList(CatalogoTipoOpinion, "IdTipoOpinion", "Nombre");

            //clsTipoOpinion cTipoOpinion = new clsTipoOpinion();
            ////cTipoOpinion.IdTiposOpinion = null;
            //CatalogoTipoOpinionRdn catTipoOpinion = new CatalogoTipoOpinionRdn();
            //List<pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result> CatalogoTipoOpinion =
            //new List<pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result>();
            //int IdTiposOpinionP = DetallePeticion.IdTipoOpinion;
            //CatalogoTipoOpinion = catTipoOpinion.solicitarTipoOpinion(cTipoOpinion, errorProcedimientoAlmacenado).ToList();
            //ViewBag.CatalogoTipoOpinion = new SelectList(CatalogoTipoOpinion, "IdTipoOpinion", "Nombre", IdTiposOpinionP);

            //CatalogoCausasAsunto
            clsCausaAsunto cCausaAsunto = new clsCausaAsunto();
            cCausaAsunto.IdTipoOpinion = DetallePeticion.IdTipoOpinion;
            CatalogoCausasAsuntoRdn catCausaAsunto = new CatalogoCausasAsuntoRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result> CatalogoCausasAsunto =
            new List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result CausasAsuntoSeleccionado =
            new pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result();
            int IdCausaAsuntoP = DetallePeticion.IdCausaAsunto;
            cCausaAsunto.IdArea = DetallePeticion.IdArea;
            cCausaAsunto.IdTipoOpinion = DetallePeticion.IdTipoOpinion;

            CausasAsuntoSeleccionado =
            catCausaAsunto.obtenerCausasAsuntoPorTipoOpinionYArea
            (cCausaAsunto, errorProcedimientoAlmacenado).Where(c => c.IdCausaAsunto == IdCausaAsuntoP).FirstOrDefault();
            CatalogoCausasAsunto =
            catCausaAsunto.obtenerCausasAsuntoPorTipoOpinionYArea(cCausaAsunto, errorProcedimientoAlmacenado).Where(c => c.IdCausaAsunto != IdCausaAsuntoP).ToList();
            CatalogoCausasAsunto.Insert(0, CausasAsuntoSeleccionado);
            ViewBag.CatalogoCausasAsunto = new SelectList(CatalogoCausasAsunto, "IdCausaAsunto", "Nombre", IdCausaAsuntoP);

            //catalogo Servicio Hechos
            clsServicioHecho cServHecho = new clsServicioHecho();
            CatalogoServiciosHechosRdn catServHecho = new CatalogoServiciosHechosRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result> CatalogoServHecho =
            new List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result ServicioHechoSeleccionado =
            new pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result();
            cServHecho.IdArea = DetallePeticion.IdArea;
            int IdServHechoP = DetallePeticion.IdServicioHecho;

            ServicioHechoSeleccionado =
            catServHecho.ObtenerServiciosHechosPorAreaRdn
            (cServHecho, errorProcedimientoAlmacenado).Where(c => c.IdServicioHecho == IdServHechoP).FirstOrDefault();
            CatalogoServHecho =
            catServHecho.ObtenerServiciosHechosPorAreaRdn(cServHecho, errorProcedimientoAlmacenado).Where(c => c.IdServicioHecho != IdServHechoP).ToList();
            CatalogoServHecho.Insert(0, ServicioHechoSeleccionado);

            CatalogoServHecho = catServHecho.ObtenerServiciosHechosPorAreaRdn(cServHecho, errorProcedimientoAlmacenado).ToList();
            ViewBag.CatalogoServHecho = new SelectList(CatalogoServHecho, "IdServicioHecho", "Nombre", IdServHechoP);

            clsUnidadPrestadoraServicio Miunidad = new clsUnidadPrestadoraServicio();
            Miunidad.IdUnidadAdministrativa = DetallePeticion.IdUnidadAdministrativa;
            Miunidad.NivelUps.TipoUps.IdTipoUps = DetallePeticion.IdArea;
            CatalogoUnidadesPrestadoraServicioRdn catUps = new CatalogoUnidadesPrestadoraServicioRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result> respuesta = new List<pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result>();
            int IdUnidadPrestadora = DetallePeticion.IdUps;
            respuesta = catUps.solicitarUnidadPrestServ(Miunidad, errorProcedimientoAlmacenado).Where
                (x => x.IdUnidadPrestadoraServicio == IdUnidadPrestadora).ToList();
            ViewBag.Miunidad = new SelectList(respuesta, "IdUnidadPrestadoraServicio", "Nombre");

            #endregion

            return View(DetallePeticion);
        }

        public ActionResult CerrarPeticion()
        {

            #region Cerrar Peticion
            UtileriasCorreo EnvioCorreo = new UtileriasCorreo();
            clsPeticion objPeticion = new clsPeticion();
            ErrorProcedimientoAlmacenado ParametrosError = new ErrorProcedimientoAlmacenado();
            objPeticion.IdPeticion = Convert.ToInt32(Session["IdPeticionDetalle"]);
            objPeticion.IdOperador = Convert.ToInt32(Session["IdUsuarioActivo"]); ;
            int resp = 0;
            resp = BandejaDePeticionesc.ConcluirCerrar_PeticionRdn(objPeticion, ParametrosError);
            string AppPath = Server.MapPath("~");
            EnvioCorreo.enviarCorreo(Convert.ToInt32(Session["IdPeticionDetalle"]), AppPath);


            #endregion

            return RedirectToAction("BandejaIndex");

        }

        public ActionResult ConcluirPeticion()
        {

            #region Cerrar Peticion
            clsPeticion objPeticion = new clsPeticion();
            ErrorProcedimientoAlmacenado ParametrosError = new ErrorProcedimientoAlmacenado();

            objPeticion.IdPeticion = Convert.ToInt32(Session["IdPeticionDetalle"]);
            objPeticion.IdOperador = Convert.ToInt32(Session["IdUsuarioActivo"]); ;
            int resp = 0;

            resp = BandejaDePeticionesc.ConcluirCerrar_PeticionRdn(objPeticion, ParametrosError);

            #endregion

            return RedirectToAction("BandejaIndex");

        }

        public JsonResult GetCausaAsunto(int idTipoOpinion)
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsCausaAsunto cCausaAsunto = new clsCausaAsunto();
            cCausaAsunto.IdTipoOpinion = idTipoOpinion;
            CatalogoCausasAsuntoRdn catCausaAsunto = new CatalogoCausasAsuntoRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result> CatalogoCausaAsunto =
            new List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result OpcionSelect =
            new pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result();
            OpcionSelect.IdCausaAsunto = 0;
            OpcionSelect.Nombre = "Seleccione";
            var CatalogoCausaAsuntoVar = catCausaAsunto.solicitarCausasAsunto(cCausaAsunto, errorErrror);
            CatalogoCausaAsuntoVar.Insert(0, OpcionSelect);
            return Json(CatalogoCausaAsuntoVar, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUnidPrestServ(int idUnidadAdministrativa, int idTipoUps)
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsUnidadPrestadoraServicio Miunidad = new clsUnidadPrestadoraServicio();
            Miunidad.IdUnidadAdministrativa = idUnidadAdministrativa; //6
            Miunidad.NivelUps.TipoUps.IdTipoUps = idTipoUps; //1
            CatalogoUnidadesPrestadoraServicioRdn catUps = new CatalogoUnidadesPrestadoraServicioRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result> CatalogoUnidadPrestServ =
                new List<pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result OpcSele =
                new pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result();
            OpcSele.Nombre = "Seleccione";
            OpcSele.IdUnidadPrestadoraServicio = 0;
            CatalogoUnidadPrestServ = catUps.solicitarUnidadPrestServ(Miunidad, errorErrror);
            CatalogoUnidadPrestServ.Insert(0, OpcSele);
            return Json(CatalogoUnidadPrestServ.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult PostUnidPrestServ(int IdUnidadAdministrativa)
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsUnidadPrestadoraServicio Miunidad = new clsUnidadPrestadoraServicio();
            Miunidad.IdUnidadAdministrativa = IdUnidadAdministrativa;
            Miunidad.NivelUps.TipoUps.IdTipoUps = 1;//pIdTipoUps;
            CatalogoUnidadesPrestadoraServicioRdn catUps = new CatalogoUnidadesPrestadoraServicioRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result> CatalogoUndsPrestadoraServicios =
            new List<pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result OpcionSelecciona = 
            new pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result();

            CatalogoUndsPrestadoraServicios = catUps.solicitarUnidadPrestServ(Miunidad, errorErrror);
            OpcionSelecciona.Nombre = "Seleccione";
            OpcionSelecciona.IdUnidadPrestadoraServicio = 0;

            CatalogoUndsPrestadoraServicios.Insert(0, OpcionSelecciona);
            return Json(CatalogoUndsPrestadoraServicios.ToList(), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult PostGetCausaAsunto(int IdArea, int idTipoOpinion)
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsCausaAsunto cCausaAsunto = new clsCausaAsunto();
            cCausaAsunto.IdArea = IdArea;
            cCausaAsunto.IdTipoOpinion = idTipoOpinion;
            CatalogoCausasAsuntoRdn catCausaAsunto = new CatalogoCausasAsuntoRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result> CatalogoCausaAsunto =
            new List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result OpcionSelect =
            new pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result();
            OpcionSelect.IdCausaAsunto = 0;
            OpcionSelect.Nombre = "Seleccione";
            var CatalogoCausaAsuntoVar = catCausaAsunto.obtenerCausasAsuntoPorTipoOpinionYArea(cCausaAsunto, errorErrror);
            CatalogoCausaAsuntoVar.Insert(0, OpcionSelect);

            return Json(CatalogoCausaAsuntoVar, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PostGetCausaAsuntoEdicion(int IdArea, int idTipoOpinion)
        {
            //pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result DetallePeticionSesion =
            //new pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result();
            //DetallePeticionSesion = (pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result)Session["DetallePeticion"];
            //int IdCausaAuntoPeticion = DetallePeticionSesion.IdCausaAsunto;

            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            clsCausaAsunto cCausaAsunto = new clsCausaAsunto();
            cCausaAsunto.IdArea = IdArea;
            cCausaAsunto.IdTipoOpinion = idTipoOpinion;
            CatalogoCausasAsuntoRdn catCausaAsunto = new CatalogoCausasAsuntoRdn();
            List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result> CatalogoCausaAsunto =
            new List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result>();
            pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result CausaAsuntoOpcionSeleccionar =
            new pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result();

            CausaAsuntoOpcionSeleccionar.IdCausaAsunto = Convert.ToInt16(DatosGenerales.Seleccion.SeleccioneIdCero);
            CausaAsuntoOpcionSeleccionar.Nombre = DatosGenerales.OpcionSeleccionar;

            CatalogoCausaAsunto = catCausaAsunto.obtenerCausasAsuntoPorTipoOpinionYArea(cCausaAsunto, errorErrror);
            CatalogoCausaAsunto.Insert(0, CausaAsuntoOpcionSeleccionar);

            return Json(CatalogoCausaAsunto, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult PostServicioHechos(int IdArea)
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result> CatalogoServicioHechos =
            new List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result>();
            ParametrosclsServicioHecho.IdArea = IdArea;
            pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result OpcSele =
            new pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result();
            OpcSele.Nombre = "Seleccione";
            OpcSele.IdServicioHecho = 0;
            CatalogoServicioHechos = CatalogoServicioHechosMetodos.ObtenerServiciosHechosPorAreaRdn(ParametrosclsServicioHecho,errorErrror);
            CatalogoServicioHechos.Insert(0, OpcSele);
            
            return Json(CatalogoServicioHechos.ToList(), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult PostServicioHechosEdicion(int IdArea)
        {
            ErrorProcedimientoAlmacenado errorErrror = new ErrorProcedimientoAlmacenado();
            List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result> CatalogoServicioHechos =
            new List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result>();
            ParametrosclsServicioHecho.IdArea = IdArea;
            pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result ServiciosHechosPorAreaOpcionSeleccionar =
            new pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result();
            ServiciosHechosPorAreaOpcionSeleccionar.IdServicioHecho = Convert.ToInt16(DatosGenerales.Seleccion.SeleccioneIdCero);
            ServiciosHechosPorAreaOpcionSeleccionar.Nombre = DatosGenerales.OpcionSeleccionar;

            CatalogoServicioHechos = CatalogoServicioHechosMetodos.ObtenerServiciosHechosPorAreaRdn(ParametrosclsServicioHecho, errorErrror);
            CatalogoServicioHechos.Insert(0,ServiciosHechosPorAreaOpcionSeleccionar);
            return Json(CatalogoServicioHechos.ToList(), JsonRequestBehavior.AllowGet);
        }



        public ActionResult PersonalInvolucrado()
        {
             List<pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result> ListaDatosDeUsuarioActual =
            (List<pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result>)Session["DatosUsuarioActual"];
            var IdRolUsuario = ListaDatosUsuarioActivo.OrderBy(order => order.IdRol).Select(selectId => selectId.IdRol).FirstOrDefault();

            if (IdRolUsuario == 3)
            {
                @ViewBag.OcultaOpcionMenuDias = Session["OcultarControlDeMenuVar"].ToString();
                @ViewBag.OcultaOpcionMenuReportes = Session["OcultarControlDeMenuVar"].ToString();
                @ViewBag.OcultaOpcionMenuTablero = Session["OcultarControlDeMenuVar"].ToString();
            }
            return View();
        }

        public JsonResult ListaSeguimiento(int IdPeticion, int IdUsuario)
        {
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            SeguimientoOperadorRdn objSeguimientoOperadorRdn = new SeguimientoOperadorRdn();
            clsDetallePeticionSeguimieto objSeguimiento = new clsDetallePeticionSeguimieto();
            objSeguimiento.IdPeticion = IdPeticion;
            objSeguimiento.IdUsuario = IdUsuario;

            //List<object> personal = new List<object>();
            var seguimiento = objSeguimientoOperadorRdn.Obtener_SeguimientoOperadorRdn(objSeguimiento, errorProcedimientoAlmacenado).ToList();

            return Json(seguimiento, JsonRequestBehavior.AllowGet);

        }

        public ActionResult InsertarSeguimientoOperador(int IdOperador, int IdPeticion, string Comentarios)
        {
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            SeguimientoOperadorRdn objSeguimientoOperadorRdn = new SeguimientoOperadorRdn();
            clsDetallePeticionSeguimientoOperador seguimiento = new clsDetallePeticionSeguimientoOperador();
            seguimiento.Comentarios = Comentarios;
            seguimiento.IdOperador = IdOperador;
            seguimiento.IdPeticion = IdPeticion;
            int resp = objSeguimientoOperadorRdn.Insertar_SeguimientoOperadorRdn(seguimiento, errorProcedimientoAlmacenado);
            return RedirectToAction("Seguimiento");
        }

        public ActionResult Eliminar_SeguimientoOperador(List<Seguimiento> removeRecordList, int IdOperador)
        {
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            SeguimientoOperadorRdn objSeguimientoOperadorRdn = new SeguimientoOperadorRdn();
            clsDetallePeticionSeguimientoOperador seguimiento = new clsDetallePeticionSeguimientoOperador();
            foreach (Seguimiento item in removeRecordList)
            {
                seguimiento.IdPeticion = item.IdPeticion;
                seguimiento.IdSeguimiento = item.IdSeguimiento;
                seguimiento.IdSeguimientoOperador = item.IdSeguimientoOperador;
                seguimiento.IdOperador = IdOperador;
                int resp = objSeguimientoOperadorRdn.Eliminar_SeguimientoOperadorRdn(seguimiento, errorProcedimientoAlmacenado);
            }
            return RedirectToAction("Seguimiento");
        }

        /// <summary>
        /// Obtiene el personal involucrado en una petición
        /// </summary>
        /// <param name="IdPeticion"></param>
        /// <returns></returns>

        public JsonResult Obtener_PersonalInvolucrado(int IdPeticion)
        {
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            PersonalInvolucradoRdn objPersonalInvoluvradoRdn = new PersonalInvolucradoRdn();
            Modelos.ClasesConcretas.clsPeticion objPeticion = new Modelos.ClasesConcretas.clsPeticion();
            objPeticion.IdPeticion = IdPeticion;
            //List<object> personal = new List<object>();
            var personal = objPersonalInvoluvradoRdn.Obtener_PersonalInvolucradoRdn(objPeticion, errorProcedimientoAlmacenado).ToList();
            return Json(personal, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Agrega el personal involucrado a una petición
        /// La clase involucrado que se pasa como parámetro debe contener: 
        /// IdPeticion, Nombre, ApellidoPaterno, ApellidoMaterno, IdTipoPersonal, IdUsuarioRegistro
        /// </summary>
        /// <param name="involucrado"></param>
        /// <returns></returns>
        public ActionResult Insertar_PersonalInvolucrado
        (int TipoPersonal, string Nombre, string ApellidoPaterno, string ApellidoMaterno, int IdUsuarioRegistro, int IdPeticion)
        {
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            PersonalInvolucradoRdn objPersonalInvoluvradoRdn = new PersonalInvolucradoRdn();
            clsDetallePeticionInvolucrado involucrado = new clsDetallePeticionInvolucrado();
            involucrado.IdTipoPersonal = TipoPersonal;
            involucrado.Nombre = Nombre.ToUpper();
            involucrado.ApellidoPaterno = ApellidoPaterno.ToUpper();
            involucrado.ApellidoMaterno = ApellidoMaterno.ToUpper();
            involucrado.IdUsuarioRegistro = IdUsuarioRegistro;
            involucrado.IdPeticion = IdPeticion;
            int resp = objPersonalInvoluvradoRdn.Insertar_PersonalInvolucradoRdn(involucrado, errorProcedimientoAlmacenado);
            return RedirectToAction("PersonalInvolucrado");
        }

        /// <summary>
        /// Elimina el personal involucrado de una petición
        /// </summary>
        /// <param name="IdPeticion"></param>
        /// <param name="IdInvolucrado"></param>
        /// <returns></returns>
        public ActionResult Eliminar_PersonalInvolucrado(List<PersonalInvolucrado> PerInv)
        {
            int IdUsuario = Convert.ToInt32(Session["IdUsuarioActivo"]);
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            PersonalInvolucradoRdn objPersonalInvoluvradoRdn = new PersonalInvolucradoRdn();
            clsDetallePeticionInvolucrado involucrado = new clsDetallePeticionInvolucrado();
            foreach (PersonalInvolucrado item in PerInv)
            {
                involucrado.IdPeticion = item.IdPeticion;
                involucrado.IdInvolucrado = item.IdInvolucrado;
                int resp = objPersonalInvoluvradoRdn.Eliminar_PersonalInvolucradoRdn(IdUsuario, involucrado, errorProcedimientoAlmacenado);
            }
            return RedirectToAction("PersonalInvolucrado");
        }

        public JsonResult Obtener_TiposPersonal()
        {
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            CatalogoTiposPersonalRdn objTiposPersonalRdn = new CatalogoTiposPersonalRdn();
            //List<object> personal = new List<object>();
            pa_PeticionesWeb_Catalogos_Obtener_TiposPersonal_Result opcionSeleccionar = new pa_PeticionesWeb_Catalogos_Obtener_TiposPersonal_Result();
            opcionSeleccionar.IdTipoPersonal = 0;
            opcionSeleccionar.Nombre = "Seleccione";
            var TiposPersonal = objTiposPersonalRdn.Obtener_TiposPersonalRdn(errorProcedimientoAlmacenado).ToList();
            TiposPersonal.Add(opcionSeleccionar);
            return Json(TiposPersonal.OrderBy(x => x.IdTipoPersonal).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Seguimiento()
        {
            List<pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result> ListaDatosDeUsuarioActual =
                     (List<pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result>)Session["DatosUsuarioActual"];
            var IdRolUsuario = ListaDatosUsuarioActivo.OrderBy(order => order.IdRol).Select(selectId => selectId.IdRol).FirstOrDefault();
            if (IdRolUsuario == 3)
            {
                @ViewBag.OcultaOpcionMenuDias = Session["OcultarControlDeMenuVar"].ToString();
                @ViewBag.OcultaOpcionMenuReportes = Session["OcultarControlDeMenuVar"].ToString();
                @ViewBag.OcultaOpcionMenuTablero = Session["OcultarControlDeMenuVar"].ToString();
            }
            return View();
        }

        public JsonResult DatosPeticionJson()
        {

            Seguimiento DatosDelaPeticion = new Seguimiento();

            clsPeticion PEntrada = new clsPeticion();
            pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result DetallePeticion =
                     new pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result();
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            List<pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result> ListaDatosUsuarioActivoSession =
               (List<pa_PeticionesWeb_Usuarios_Obtener_Usuario_Result>)Session["RolIdUsuario"];

            DatosDelaPeticion.IdEstatusInterno = Convert.ToInt32(Session["IdEstatusInterno"]);
            DatosDelaPeticion.IdOperador = Convert.ToInt32(Session["IdUsuarioActivo"]);
            DatosDelaPeticion.IdPeticion = Convert.ToInt32(Session["IdPeticionDetalle"]);
            DatosDelaPeticion.UserName = Session["NombreUsiario"].ToString();
            PEntrada.IdPeticion = DatosDelaPeticion.IdPeticion;
            DetallePeticion = BandejaDePeticionesc.Obtener_Peticiones_DetalleRdn
                     (PEntrada, errorProcedimientoAlmacenado).FirstOrDefault();

            if (DetallePeticion.IdOperador != DatosDelaPeticion.IdOperador)
                DatosDelaPeticion.AsigPeticion = false;
            else
                DatosDelaPeticion.AsigPeticion = true;

            DatosDelaPeticion.IdRol = ListaDatosUsuarioActivoSession.OrderBy(order => order.IdRol).Select(selectId => selectId.IdRol).FirstOrDefault();
            List<Seguimiento> DatosPetcionJson = new List<Seguimiento>();
            DatosPetcionJson.Add(DatosDelaPeticion);
            var DatosParametrosPeticion = from PeticionProcesar in DatosPetcionJson
                                          select new
                                          {
                                              IdOperador = PeticionProcesar.IdOperador,
                                              IdPeticion = PeticionProcesar.IdPeticion,
                                              UserName = PeticionProcesar.UserName,
                                              IdRol = PeticionProcesar.IdRol,
                                              IdEstatusInterno = PeticionProcesar.IdEstatusInterno,
                                              AsigPeticion = PeticionProcesar.AsigPeticion
                                          };

            return Json(DatosParametrosPeticion, JsonRequestBehavior.AllowGet);
        }

        public FileResult DetallePeticiones()
        {
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Usuario_Result> ListaDePeticiones =
            (List<pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Usuario_Result>)Session["PetionesDescarga"];

            ListPeticiones = ListaDePeticiones;

            string listacadena = "";
            foreach (pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Usuario_Result item in ListPeticiones)
            {
                if (listacadena != "")
                    listacadena = listacadena + "," + item.IdPeticion.ToString();
                else
                    listacadena = listacadena + item.IdPeticion.ToString();
            }
            var PeticionesExcel = BandejaDePeticionesc.ObtenerExcelPeticiones(listacadena, errorProcedimientoAlmacenado);

            using (TramitesDigitalesEntities _entities = new TramitesDigitalesEntities())
            {
                Warning[] warnings;
                string mimeType;
                string[] streamids;
                string encoding;
                string filenameExtension;

                var viewer = new ReportViewer();
                viewer.LocalReport.ReportPath = @"Reportes\ServiciosReportes\PlantillasReportes\DetallePeticiones.rdlc";
                ReportDataSource RDS = new ReportDataSource("DetallePeticionesExcel", PeticionesExcel);
                viewer.LocalReport.DataSources.Add(RDS);
                viewer.LocalReport.Refresh();
                var bytes = viewer.LocalReport.Render("EXCELOPENXML", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

                return new FileContentResult(bytes, mimeType);
            }
        }

        public JsonResult Upload()
        {
            try
            {
                int IdPeticion = Convert.ToInt32(Session["IdPeticionDetalle"]);
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i]; //Uploaded file

                    int IdUsuario = Convert.ToInt32(Session["IdUsuarioActivo"]);                                            //Use the following properties to get file's name, size and MIMEType
                    int fileSize = file.ContentLength;
                    string fileName = file.FileName;
                    string mimeType = file.ContentType;
                    Stream fileContent = file.InputStream;
                    //To save file, use SaveAs method
                    string baseurl = ConfigurationManager.AppSettings["pathAdjuntos"] + "\\" + IdPeticion;
                    if (!Directory.Exists(baseurl))
                    {
                        try
                        {
                            Directory.CreateDirectory(baseurl);
                        }
                        catch (Exception e)
                        {
                            ErrorSignal.FromCurrentContext().Raise(e);
                            return Json("Error: " + e.Message);
                        }

                    }
                    try
                    {
                        file.SaveAs(baseurl + "\\" + fileName);
                    }
                    catch (Exception e)
                    {
                        ErrorSignal.FromCurrentContext().Raise(e);
                        return Json("Error:" + e.Message);
                    }
                    //File will be saved in application root
                    ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
                    AdjuntosRdn objAdjuntosRdn = new AdjuntosRdn();
                    clsDetallePeticionArchivo objDetallePeticionArchivo = new clsDetallePeticionArchivo();
                    objDetallePeticionArchivo.IdPeticion = IdPeticion;
                    objDetallePeticionArchivo.RutaArchivo = baseurl;
                    objDetallePeticionArchivo.NombreArchivo = fileName;
                    int resp = objAdjuntosRdn.Insertar_AdjuntoRdn(IdUsuario, objDetallePeticionArchivo, errorProcedimientoAlmacenado);
                }

                return Json("Uploaded " + Request.Files.Count + " files");
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(e);
                return Json("Error:" + e.Message);
            }

        }

        public ActionResult ActualizarDatosDeLaPeticion
        (FormCollection FormularioHtml, pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result ModeloPeticion)
        {
            int IdUsuario = Convert.ToInt32(Session["IdUsuarioActivo"]);
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            ModeloPeticion.IdPeticion = Convert.ToInt32(Session["IdPeticionDetalle"]);
            ModeloPeticion.FechaHechos = new DateTime(2010, 1, 18);

            bool GeneroPetiMasculinoActivo = Convert.ToBoolean(Request["rdbGeneroMasculinoAfectado"].ToString());
            int GeneroPetiMasculino = (GeneroPetiMasculinoActivo == true) ? 1 : 2;
            //ModeloPeticion.IdGeneroAfectado = Convert.ToInt32(Request["IdGeneroAfectado"]);
            ModeloPeticion.IdGeneroAfectado = GeneroPetiMasculino;

            ModeloPeticion.IdOperador = IdUsuario;
            ModeloPeticion.IdTipoDhbAfectado = Convert.ToInt32(Request["IdTipoDerechohabienteAfectado"]);
            ModeloPeticion.IdArea = Convert.ToInt32(Request["CatalogoDeAreas"]);            
            ModeloPeticion.IdCausaAsunto = Convert.ToInt32(Request["CatlogoCausaAsunto"]);
            ModeloPeticion.IdServicioHecho = Convert.ToInt32(Request["CatalogoServicioHecho"]);

            BandejaDePeticionesc.ActualizarPeticionRdn(ModeloPeticion, errorProcedimientoAlmacenado);
            return RedirectToAction("MenuDetalle");
        }


        public JsonResult Obtener_Adjuntos(int IdPeticion)
        {
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            AdjuntosRdn objAdjuntosRdn = new AdjuntosRdn();
            clsDetallePeticionArchivo objDetallePeticionArchivo = new clsDetallePeticionArchivo();
            objDetallePeticionArchivo.IdPeticion = IdPeticion;

            var adjuntos = objAdjuntosRdn.Obtener_AdjuntosRdn(objDetallePeticionArchivo, errorProcedimientoAlmacenado);

            return Json(adjuntos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insertar_Adjunto(int IdPeticion, string RutaArchivo, string NombreArchivo)
        {
            int IdUsuario = Convert.ToInt32(Session["IdUsuarioActivo"]);
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            AdjuntosRdn objAdjuntosRdn = new AdjuntosRdn();
            clsDetallePeticionArchivo objDetallePeticionArchivo = new clsDetallePeticionArchivo();
            objDetallePeticionArchivo.IdPeticion = IdPeticion;
            objDetallePeticionArchivo.RutaArchivo = RutaArchivo;
            objDetallePeticionArchivo.NombreArchivo = NombreArchivo;
            int resp = objAdjuntosRdn.Insertar_AdjuntoRdn(IdUsuario, objDetallePeticionArchivo, errorProcedimientoAlmacenado);
            return RedirectToAction("Seguimiento");
        }

        public ActionResult Eliminar_Adjuntos(List<ArchivoAdjunto> removeRecordList)
        {
            try
            {
                int IdUsuario = Convert.ToInt32(Session["IdUsuarioActivo"]);
                int IdPeticion = Convert.ToInt32(Session["IdPeticionDetalle"]);
                string baseurl = ConfigurationManager.AppSettings["pathAdjuntos"] + "\\" + IdPeticion + "\\";
                ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
                AdjuntosRdn objAdjuntosRdn = new AdjuntosRdn();
                clsDetallePeticionArchivo adjunto = new clsDetallePeticionArchivo();
                foreach (ArchivoAdjunto item in removeRecordList)
                {
                    adjunto.IdPeticion = item.IdPeticion;
                    adjunto.IdRenglon = item.IdRenglon;
                    //int resp = objAdjuntosRdn.Eliminar_AdjuntoRdn(adjunto, errorProcedimientoAlmacenado);

                    if (System.IO.File.Exists(baseurl + item.NombreArchivo))
                    {
                        // Use a try block to catch IOExceptions, to
                        // handle the case of the file already being
                        // opened by another process.
                        try
                        {
                            objAdjuntosRdn.Eliminar_AdjuntoRdn(IdUsuario, adjunto, errorProcedimientoAlmacenado);
                            System.IO.File.Delete(baseurl + item.NombreArchivo);

                        }
                        catch (IOException e)
                        {
                            ErrorSignal.FromCurrentContext().Raise(e);
                            return RedirectToAction("Seguimiento");
                        }
                    }
                }
                return RedirectToAction("Seguimiento");
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(e);
                return RedirectToAction("Seguimiento");
            }

        }

        public ActionResult Download(string NombreArchivo)
        {
            try
            {
                //var FileVirtualPath = "C:/inetpub/wwwroot/archivos/"+ Convert.ToInt32(Session["IdPeticionDetalle"])+"/" + NombreArchivo;
                var FileVirtualPath = ConfigurationManager.AppSettings["pathAdjuntos"] + "\\" + Convert.ToInt32(Session["IdPeticionDetalle"]) + "\\" + NombreArchivo;
                if (System.IO.File.Exists(FileVirtualPath))
                {
                    var Archivo = File(FileVirtualPath, "application / force - download", Path.GetFileName(FileVirtualPath));
                    return Archivo;
                }
                else
                {
                    return RedirectToAction("Seguimiento");
                }

            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(e);
                return RedirectToAction("Seguimiento");
            }
        }
    }


}
