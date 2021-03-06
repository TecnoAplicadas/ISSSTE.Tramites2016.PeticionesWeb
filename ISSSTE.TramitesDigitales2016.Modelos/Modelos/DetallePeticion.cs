﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DetallePeticion
    {
        public int IdPeticion { get; set; }
        public string Folio { get; set; }
        public string FolioPadre { get; set; }
        public int IdPeticionario { get; set; }
        public int IdAfectado { get; set; }
        public int IdCausaAsunto { get; set; }
        public int IdServicioHecho { get; set; }
        public int IdUps { get; set; }

        //[Required(ErrorMessage = "Fecha de Captura Inicio obligatorio.")]
        public  string FechaRegistro { get; set; }
        //[Required(ErrorMessage = "Fecha de Captura Fin obligatorio.")]
        public string FechaRegistroFin { get; set; }
        public Nullable <System.DateTime> FechaHechos { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdOperador { get; set; }
        public int IdEstatusInterno { get; set; }
        public string EstatusInterno { get; set; }
        public string UsernameOperador { get; set; }
        public string CurpPeticionario { get; set; }
        public string RfcPeticionario { get; set; }
        public string NombrePeticionario { get; set; }
        public string ApePaternoPeticionario { get; set; }
        public string ApeMaternoPeticionario { get; set; }
        public int IdGeneroPeticionario { get; set; }
        public string GeneroPeticionario { get; set; }
        public int IdTipoDhbPeticionario { get; set; }
        public string TipoDhbPeticionario { get; set; }
        public string CPPeticionario { get; set; }
        public string EdoPeticionario { get; set; }
        public string MpioPeticionario { get; set; }
        public int IdColoniaPeticionario { get; set; }
        public string ColoniaPeticionario { get; set; }
        public string CallePeticionario { get; set; }
        public string NumeroExteriorPeticionario { get; set; }
        public string NumeroInteriorPeticionario { get; set; }
        public string LadaPeticionario { get; set; }
        public string TelefonoFijoPeticionario { get; set; }
        public string TelefonoMovilPeticionario { get; set; }
        public string CorreoElectronicoPeticionario { get; set; }
        public string CurpAfectado { get; set; }
        public string RfcAfectado { get; set; }
        public string NombreAfectado { get; set; }
        public string ApePaternoAfectado { get; set; }
        public string ApeMaternoAfectado { get; set; }
        public int IdGeneroAfectado { get; set; }
        public string GeneroAfectado { get; set; }
        public int IdTipoDhbAfectado { get; set; }
        public string TipoDhbAfectado { get; set; }
        public string LadaAfectado { get; set; }
        public string TelefonoFijoAfectado { get; set; }
        public string TelefonoMovilAfectado { get; set; }
        public string CorreoElectronicoAfectado { get; set; }
        public int IdAreaPeticion { get; set; }
        public string AreaPeticion { get; set; }
        public int IdUnidadAdministrativa { get; set; }
        public string UnidadAdministrativa { get; set; }
        public string UPS { get; set; }
        public int IdTipoOpinion { get; set; }
        public string TipoOpinion { get; set; }
        public string CausaAsunto { get; set; }
        public string ServicioHecho { get; set; }
    }
}

