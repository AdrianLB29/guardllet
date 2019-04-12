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

        public static bool Celular(string celular)
        {
            String exprecion_celular = ConfigurationManager.AppSettings["Regla_Telefono"];

            if (celular.Length == 10)
            {
                if (celular.Substring(0, 1) == "5" && celular.Substring(1, 1) == "5")
                {
                    Match M;
                    Regex Validador = new Regex(exprecion_celular, RegexOptions.IgnoreCase);
                    M = Validador.Match(celular);
                    return M.Success;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool Boleta(string boleta)
        {
            String exprecion_boleta = ConfigurationManager.AppSettings["Regla_Boleta"];

            if (boleta.Length == 10)
            {
                if (boleta.Substring(0, 1) == "2" && boleta.Substring(1, 1) == "0" && boleta.Substring(2, 1) == "1")
                {
                    if(boleta.Substring(4, 2) == "13")
                    {
                        Match M;
                        Regex Validador = new Regex(exprecion_boleta, RegexOptions.IgnoreCase);
                        M = Validador.Match(boleta);
                        return M.Success;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool Grupo(string grupo)
        {
            if (grupo.Length <= 5)
            {
                if (grupo.Substring(0, 1) == "1")
                {
                    if (grupo.Substring(1, 1) == "I")
                    {
                        if (grupo.Substring(2, 1) == "M")
                        {
                            return true;
                        }
                        else if (grupo.Substring(2, 1) == "V")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (grupo.Substring(0, 1) == "2")
                {
                    if (grupo.Substring(1, 1) == "I")
                    {
                        if (grupo.Substring(2, 1) == "M")
                        {
                            return true;
                        }
                        else if (grupo.Substring(2, 1) == "V")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (grupo.Substring(0, 1) == "3")
                {
                    if (grupo.Substring(1, 1) == "I")
                    {
                        if (grupo.Substring(2, 1) == "M")
                        {
                            return true;
                        }
                        else if (grupo.Substring(2, 1) == "V")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (grupo.Substring(0, 1) == "4")
                {
                    if (grupo.Substring(1, 1) == "I")
                    {
                        if (grupo.Substring(2, 1) == "M")
                        {
                            return true;
                        }
                        else if (grupo.Substring(2, 1) == "V")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (grupo.Substring(0, 1) == "5")
                {
                    if (grupo.Substring(1, 1) == "I")
                    {
                        if (grupo.Substring(2, 1) == "M")
                        {
                            return true;
                        }
                        else if (grupo.Substring(2, 1) == "V")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (grupo.Substring(0, 1) == "6")
                {
                    if (grupo.Substring(1, 1) == "I")
                    {
                        if (grupo.Substring(2, 1) == "M")
                        {
                            return true;
                        }
                        else if (grupo.Substring(2, 1) == "V")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}