﻿using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Catalogos
{
    public class CatalogoTipoUps
    {
        public List<pa_PeticionesWeb_Catalogos_Obtener_TipoUps_Result> ObtenerTipoUps(clsTipoUps pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_TipoUps_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Catalogos_Obtener_TipoUps(
                        estatusRegistro: pEntrada.EstatusRegistro,
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
    }
}
