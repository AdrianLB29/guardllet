using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Text.RegularExpressions;

namespace Guardllet_Desarrollo.Backend.Data.Accounts
{
    public class Validar
    {
        public static string DatosGenerales(string Nom, string ApP, string ApM, string Cel)
        {
            if(Nom.Length <= 2)
            {
                if (ApP.Length <= 3)
                {
                    if (ApM.Length <= 3)
                    {
                        if (Cel.Length <= 10)
                        {
                            Cel.
                            


                            return "Ingresa un Numero Celular correcto";
                        }

                        return "Ingresa un Apellido Materno Correcto";
                    }

                    return "Ingresa un Apellido Paterno Correcto";
                }

                return "Ingresa un Nombre Correcto";
            }
        }

        public static bool Correo(string correo)
        {
            bool resultado = false;

            String exprecion_correo = ConfigurationManager.AppSettings["Regla_Correo"];

            if (correo.Trim().Length > 50 || correo.Trim().Length < 5)
            {
                return resultado;
            }
            else
            {
                Match M;
                Regex Validador = new Regex(exprecion_correo, RegexOptions.IgnoreCase);
                M = Validador.Match(correo);
                return M.Success;
            }
        }
    }
}