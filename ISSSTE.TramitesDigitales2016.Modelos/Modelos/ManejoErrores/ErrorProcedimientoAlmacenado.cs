using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores
{
   public class ErrorProcedimientoAlmacenado
   {
      public ErrorProcedimientoAlmacenado()
      {
         Numero = new ObjectParameter("pi_errorNumero", typeof(Int32));
         Numero.Value = -1;

         Mensaje = new ObjectParameter("pnvc_errorMensaje", typeof(string));
         Mensaje.Value = "";

         Linea = new ObjectParameter("pi_errorLinea", typeof(Int32));
         Linea.Value = -1;

         ProcedimientoAlmacenado = new ObjectParameter("pnvc_errorProcAlm", typeof(string));
         ProcedimientoAlmacenado.Value = "";

         Severidad = new ObjectParameter("pi_errorSeveridad", typeof(Int32));
         Severidad.Value = -1;

         Estado = new ObjectParameter("pi_errorEstado", typeof(Int32));
         Estado.Value = -1;
      }

      public ObjectParameter Numero { get; set; }
      public ObjectParameter Mensaje { get; set; }
      public ObjectParameter Linea { get; set; }
      public ObjectParameter ProcedimientoAlmacenado { get; set; }
      public ObjectParameter Severidad { get; set; }
      public ObjectParameter Estado { get; set; }
   }
}
