using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.ListarReporte
{
    public class FechaServidorRdn
    {
        FechaServidor procesosObtenerFecha = new FechaServidor();
        public List<DateTime?> obtenerFechaServidor(ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<DateTime?>();
            try
            {
                respuestaWeb = procesosObtenerFecha.obtenerFechaServidor(pError);
            }
            catch
            {
                throw;
            }
            return respuestaWeb;
        }
    }
}
