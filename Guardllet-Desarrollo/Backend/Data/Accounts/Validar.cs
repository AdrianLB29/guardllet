using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}