using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models
{
    public class DatosGenerales
    {

        public enum IdRolUsuario { Administrador = 1, Delagacional, Operador }

        public enum ConsultaPorTipo { Inicio = 0, Asignadas }

        public const string Mostrar = "";
        public const string Ocultar = "hidden='hidden'";

        public const string HabilitaOperadoresActivo = "on";

        // Datos para catalogos
        public const string EstatusRegistroActivo = "A";

        public enum Seleccion { SeleccioneIdCero = 0 }
        public const string OpcionSeleccionar = "-Seleccionar-";


        //tablero de control
        #region 
        public const int ColorVerde = 50;   //"#47B376";
        public const int ColorAmarillo = 44;  //"#E8F352";
        public const int ColorRojo = 3;  //"#F74B4B";

        public enum IdTableroCDiasAsignados
        {
            Aviso_recepcion = 1,
            Contestacion,
            Turnado,
            Respuesta,
            Total,
            Paremtro_Semaforo_Contestacion_amarillo,
            Paremtro_Semaforo_Turnado_amarillo,
            Paremtro_Semaforo_Respuesta_amarillo
        }

        // Valores para la colocacion de la imagen del excel
        public const int ImagenIzquierda = 32;
        public const int ImagenArriba = 15;
        public const int ImagenAncho = 300;
        public const int ImagenAlto = 50;


        //Valores columnas excel
        public const int ColumnaUno = 1;
        public const int ColumnaDos = 2;
        public const int ColumnaTres = 3;
        public const int ColumnaCuatro = 4;
        public const int ColumnaCinco = 5;
        public const int ColumnaSeis = 6;
        public const int ColumnaSiete = 7;
        public const int ColumnaOcho = 8;
        public const int ColumnaNueve = 9;
        public const int ColumnaDiez = 10;

        //Valores  filas 
        public const int FilaUno = 1;
        public const int FilaDos = 2;
        public const int FilaTres = 3;
        public const int FilaCuatro = 4;
        public const int FilaCinco = 5;
        public const int FilaSeis = 6;
        public const int FilaSiete = 7;
        public const int FilaOcho = 8;
        public const int FilaNueve = 9;
        public const int FilaDiez = 10;

        public const int FilaCatorce = 14;
        public const int FilaQuince = 15;
        public const int FilaDiezsiceis = 16;

        #endregion





    }
}