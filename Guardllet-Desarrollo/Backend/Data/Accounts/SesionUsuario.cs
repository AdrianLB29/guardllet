using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

/// <summary>
/// Accion de confirmar usuario y contrasena para iniciar sesion
/// </summary>
/// 
namespace Guardllet_Desarrollo.Backend.Data.Accounts
{
    public class SesionUsuario
    {
        public static bool IniciarSesion(string correo, string contrasena)
        {
            bool resultado = false;
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    SqlCommand command = new SqlCommand("LoginUsuario", Conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter param_correo = new SqlParameter("@CORREO", SqlDbType.Text);
                    param_correo.Direction = ParameterDirection.Input;
                    param_correo.Value = correo;
                    command.Parameters.Add(param_correo);

                    SqlParameter param_contrasena = new SqlParameter("@CONTRASEÑA", SqlDbType.Text);
                    param_contrasena.Direction = ParameterDirection.Input;
                    param_contrasena.Value = contrasena;
                    command.Parameters.Add(param_contrasena);

                    SqlParameter param_resultado = new SqlParameter("@RESULTADO", SqlDbType.Bit);
                    param_resultado.Direction = ParameterDirection.Output;
                    command.Parameters.Add(param_resultado);

                    command.ExecuteNonQuery();

                    resultado = bool.Parse(command.Parameters["@RESULTADO"].Value.ToString());

                    Conexion.Close();

                    return resultado;
                }
            }
            catch (Exception exc) 
            {
                Console.WriteLine(exc);
                return resultado;
            }
        }
    }
}