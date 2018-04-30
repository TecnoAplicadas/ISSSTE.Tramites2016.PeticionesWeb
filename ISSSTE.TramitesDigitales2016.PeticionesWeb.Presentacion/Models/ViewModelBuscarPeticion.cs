using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models
{
    public class ViewModelBuscarPeticion
    {
        public clsUsuario Usuario { get;  set; }
        public clsPeticion Peticiones { get; set; }
        public clsPeticionario Peticionario { get; set; }
        public clsAfectado afectado { get; set; }
        public pa_PeticionesWeb_Catalogos_EsatusInterno_Result CataloEstatus { get; set; }
        public pa_PeticionesWeb_Catalogos_Obtener_Generos_Result CataloGenero { get; set; }
        public pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result CatalogoTiposDerhabiente { get; set; }
        public pa_PeticionesWeb_Catalogos_Obtener_Estados_Result CatalogoEstado { get; set; }
        public pa_PeticionesWeb_Catalogos_Obtener_Generos_Result CataloGeneroAfectado { get; set; }
        public pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result CatalogoTiposDerhabienteAfectado { get; set; }
        public pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result CatalogoTipoOpinion { get; set; }
        public pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result CatalogoCausaAsunto { get; set; }
        public pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result CatalogoServicioHecho { get; set; }
        public pa_PeticionesWeb_Bandeja_Peticiones_Obtener_Peticiones_Detalle_Result Detalle_peticion { get; set; }
        public DetallePeticion Detalle_peticionBusqueda { get; set; }
        public  List<pa_PeticionesWeb_Bandeja_Peticiones_Obtiener_UsuariosQueCompartenUPS_Result> UsuariosMismaUps { get; set; }




    }
}