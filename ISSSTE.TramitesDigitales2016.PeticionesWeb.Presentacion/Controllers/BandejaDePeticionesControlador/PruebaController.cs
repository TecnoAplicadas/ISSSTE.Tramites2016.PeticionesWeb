using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.BandejaPeticionesRdn;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Controllers.BandejaDePeticionesControlador
{
    public class PruebaController : Controller
    {

        BandejaDePeticionesRdn BandejaDePeticionesc = new BandejaDePeticionesRdn();

        private List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiene_Operador_Por_UPS_Result> ListOperadores =
        new List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiene_Operador_Por_UPS_Result>();
        // GET: Prueba
        public ActionResult Index()
        {

            clsPeticion DatosPeticion = new clsPeticion();
            clsUsuario UsuarioAutenticado = new clsUsuario();
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            DatosPeticion.IdUnidadPrestadoraServicio = 1;
            UsuarioAutenticado.IdUsuario = 1;

            ListOperadores = 
            BandejaDePeticionesc.ObtieneOperadorPorUnidadRdn
            (DatosPeticion, UsuarioAutenticado, errorProcedimientoAlmacenado).ToList();
            return View(ListOperadores);

            //return View();
        }
    }



}