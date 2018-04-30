using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Controllers
{
    public class PruebaModelo
    {
            [Range(1, 100, ErrorMessage = "Positivo menor que 100")]
            [NumeroPar(ErrorMessage = "El número debe ser par.")]
            public int ValorPar { get; set; }       
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NumeroParAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                var number = Convert.ToInt32(value);
                return number % 2 == 0;
            }
            catch (Exception)
            {
                return base.IsValid(value);
            }
        }
    }
}