using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.RegistroPeticion
{
    public class PeticionPro
    {
        public List<pa_PeticionesWeb_Peticion_Guardar_Peticion_Result> GuardarPeticion(Peticion pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Peticion_Guardar_Peticion_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Peticion_Guardar_Peticion(
                     pEntrada.Peticionario.Curp,
                     pEntrada.Peticionario.Rfc,
                     pEntrada.Peticionario.Nombre,
                     pEntrada.Peticionario.ApellidoPaterno,
                     pEntrada.Peticionario.ApellidoMaterno,
                     pEntrada.Peticionario.IdGenero,
                     pEntrada.Peticionario.IdTipoDerechohabiente,
                     pEntrada.Peticionario.IdPoblacionOColonia,
                     pEntrada.Peticionario.Calle,
                     pEntrada.Peticionario.NumeroExterior,
                     pEntrada.Peticionario.NumeroInterior,
                     pEntrada.Peticionario.Lada,
                     pEntrada.Peticionario.TelefonoFijo,
                     pEntrada.Peticionario.TelefonoMovil,
                     pEntrada.Peticionario.CorreoElectronico,
                     pEntrada.Afectado.Curp,
                     pEntrada.Afectado.Rfc,
                     pEntrada.Afectado.Nombre,
                     pEntrada.Afectado.ApellidoPaterno,
                     pEntrada.Afectado.ApellidoMaterno,
                     pEntrada.Afectado.IdGenero,
                     pEntrada.Afectado.IdTipoDerechohabiente,
                     pEntrada.Afectado.TelefonoFijo,
                     pEntrada.Afectado.CorreoElectronico,
                     pEntrada.IdArea,
                     pEntrada.IdUnidadPrestadoraServicio,
                     pEntrada.IdServicioHecho,
                     pEntrada.IdCausaAsunto,
                     pEntrada.FechaHechos,
                     pEntrada.Descripcion,
                     pEntrada.IdFlujoNotificacion,
                     pEntrada.IdFlujoRecordatorio,
                     pEntrada.IdFlujoSemaforo,
                     pEntrada.IdFlujoEstatus,
                     pEntrada.IdEstatusInterno,
                     pError.Numero,
                     pError.Mensaje,
                     pError.Linea,
                     pError.ProcedimientoAlmacenado,
                     pError.Severidad,
                     pError.Estado
                         ).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return respuestaWeb;
        }
    }
}
