using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.PersonalInvolucrado
{
   public class PersonalInvolucradoRdn
   {
      public List<pa_PeticionesWeb_PersonalInvolucrado_Obtener_PersonalInvolucrado_Result> Obtener_PersonalInvolucradoRdn(clsPeticion ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
      {

         Procesos.Modulos.PersonalInvolucrado.PersonalInvolucrado objPersonalInvolucradoP = new Procesos.Modulos.PersonalInvolucrado.PersonalInvolucrado();

         List<pa_PeticionesWeb_PersonalInvolucrado_Obtener_PersonalInvolucrado_Result> PersonalInvolucrado = new List<pa_PeticionesWeb_PersonalInvolucrado_Obtener_PersonalInvolucrado_Result>();
         try
         {
            PersonalInvolucrado = objPersonalInvolucradoP.Obtener_PersonalInvolucradoP(ParametrosEntrada, ParametrosError);
         }
         catch (Exception)
         {
            #region Manejo de la excepcion
            throw;
            #endregion
         }
         return PersonalInvolucrado;
      }


      public int Insertar_PersonalInvolucradoRdn(clsDetallePeticionInvolucrado ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
      {
         Procesos.Modulos.PersonalInvolucrado.PersonalInvolucrado objPersonalInvolucradoP = new Procesos.Modulos.PersonalInvolucrado.PersonalInvolucrado();
         int resp = 0;
         try
         {
            resp = objPersonalInvolucradoP.Insertar_PersonalInvolucradoP(ParametrosEntrada, ParametrosError);
         }
         catch
         {
            #region Manejo de la excepcion
            throw;
            #endregion
         }
         return resp;
      }


      public int Eliminar_PersonalInvolucradoRdn(int IdUsuario, clsDetallePeticionInvolucrado ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
      {
         Procesos.Modulos.PersonalInvolucrado.PersonalInvolucrado objPersonalInvolucradoP = new Procesos.Modulos.PersonalInvolucrado.PersonalInvolucrado();
         int resp = 0;
         try
         {
            resp = objPersonalInvolucradoP.Eliminar_PersonalInvolucradoP(IdUsuario, ParametrosEntrada, ParametrosError);
         }
         catch
         {
            #region Manejo de la excepcion
            throw;
            #endregion
         }
         return resp;
      }

   }
}
