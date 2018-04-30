using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Interfaces
{
   public interface ICrud
   {
      void Agregar(Object pObjeto);
      void Modificar(Object pObjeto);
      void DarDeBaja(Object pObjeto);
      void Consultar(Object pObjeto);
   }
}
