//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISSSTE.TramitesDigitales2016.Modelos.Contextos
{
    using System;
    
    public partial class pa_PeticionesWeb_Recordatorios_Obtener_Recordatorios_Result
    {
        public int IdPeticion { get; set; }
        public string Folio { get; set; }
        public int IdPeticionario { get; set; }
        public int ups { get; set; }
        public Nullable<int> antiguedad { get; set; }
        public int IdRecordatorio { get; set; }
        public string descripcionRecordatorio { get; set; }
        public int IdEstatusInterno { get; set; }
        public int IdMotivoRecordatorio { get; set; }
        public string descripcionMotivo { get; set; }
        public string mailDestinatario { get; set; }
        public string PlantillaAsunto { get; set; }
        public string PlantillaContenido { get; set; }
    }
}
