using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Utilerias
{
    public class AcentosEspeciales
    {
        private const string consignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑçÇ";
        private const string sinsignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC";

        public static string removerSignosAcentos(String texto)
        {
            StringBuilder textoSinAcentos = new StringBuilder(texto.Length);
            int indexConAcento;
            foreach (char caracter in texto)
            {
                indexConAcento = consignos.IndexOf(caracter);
                if (indexConAcento > -1)
                    textoSinAcentos.Append(sinsignos.Substring(indexConAcento, 1));
                else
                    textoSinAcentos.Append(caracter);
            }
            return textoSinAcentos.ToString();
        }
    }
}