using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.BandejaPeticiones
{
    public class FiltrosPeticion
    {
        public int IdUsuario { get; set; }
        public string Folio { get; set; }
        public string Curp { get; set; }
        public string Rfc { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int IdGenero { get; set; }
        public int IdTipoDerechohabiente { get; set; }
        public string ClaveCP { get; set; }
        public int IdEstado { get; set; }
        public int IdMunicipio { get; set; }
        public string NombreColonia { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public string Lada { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
        public string CurpAfectado { get; set; }
        public string RfcAfectado { get; set; }
        public string NombreAfectado { get; set; }
        public string ApellidoPaternoAfectado { get; set; }
        public string ApellidoMaternoAfectado { get; set; }
        public int IdGeneroAfectado { get; set; }
        public int IdTipoDhbAfectado { get; set; }
        public string TelefonoFijoAfectado { get; set; }
        public string CorreoElectronicoAfectado { get; set; }
        public int IdTipoUps { get; set; }	//Área
        public int IdUnidadAdministrativa { get; set; }	//Delegacion
        public int IdUnidadPrestadoraServicio { get; set; }
        public int IdTipoOpinion { get; set; }
        public int IdCausaAsunto { get; set; }
        public string FechaHechos { get; set; }

        public string FechaRegistro { get; set; }
        public string FechaRegistroFin { get; set; }

        public int IdServicioHecho { get; set; }
        public string Descripcion { get; set; }
        public int IdEstatusInterno { get; set; }
    }
}
