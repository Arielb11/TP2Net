using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Logic
{
    public static class Validaciones
    {
        //Programar usando expresión regular para validar email.
        //Reg Expression 



        //Googlear expresión para validar emails.
        public static bool IsMailValue(string cadena)
        {
            bool bandera = true;
            if(!Regex.IsMatch(cadena, "@"))
            {
                bandera = false;
            }

            return bandera;
        }

        public static bool IsFieldEmpty(string cadena)
        {
            bool bandera = true;
            if (Regex.IsMatch(cadena, "^$"))
            {
                bandera = false;
            }
            
            return bandera;
        }



        //Fechas válidas, números, etc.
        //Validar para el tema de años bisiestos.
        //Nota entre 0 y 10 como ejemplo



    }
}
