using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Guardllet_Desarrollo.Backend.Data.Accounts
{
    public class RegistroUsuario
    {
        public static int Registro(string correo, string contrasena)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    SqlCommand command = new SqlCommand("RegistroUsuario", Conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter param_correo = new SqlParameter("@CORREO", SqlDbType.VarChar);
                    param_correo.Direction = ParameterDirection.Input;
                    param_correo.Value = correo;
                    command.Parameters.Add(param_correo);

                    SqlParameter param_contrasenia = new SqlParameter("@CONTRASEÑA", SqlDbType.VarChar);
                    param_contrasenia.Direction = ParameterDirection.Input;
                    param_contrasenia.Value = contrasena;
                    command.Parameters.Add(param_contrasenia);

                    SqlParameter param_tipo = new SqlParameter("@TIPO_USUARIO", SqlDbType.Int);
                    param_tipo.Direction = ParameterDirection.Input;
                    param_tipo.Value = 1;
                    command.Parameters.Add(param_tipo);

                    SqlParameter param_estado = new SqlParameter("@ESTADO", SqlDbType.Int);
                    param_estado.Direction = ParameterDirection.Input;
                    param_estado.Value = 1;
                    command.Parameters.Add(param_estado);

                    SqlParameter param_salida = new SqlParameter("@ID_REGISTRO", SqlDbType.Int);
                    param_salida.Direction = ParameterDirection.Output;
                    command.Parameters.Add(param_salida);

                    command.ExecuteScalar();

                    Conexion.Close();

                    int resultado = Convert.ToInt16(command.Parameters["@ID_REGISTRO"].Value.ToString());

                    return resultado;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return 0;
            }
        }
    }
}