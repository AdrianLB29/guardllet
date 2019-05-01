using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Guardllet_Desarrollo.Backend.Data.Wallet
{
    public class Monedero
    {
        public static int Crear(string codigo, Byte[] img_codigo)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    SqlCommand command = new SqlCommand("RegistroMonedero", Conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter param_saldo = new SqlParameter("@CODIGO", SqlDbType.VarChar);
                    param_saldo.Direction = ParameterDirection.Input;
                    param_saldo.Value = codigo;
                    command.Parameters.Add(param_saldo);

                    SqlParameter param_n_codigo = new SqlParameter("@IMAGEN_CODIGO", SqlDbType.Image);
                    param_n_codigo.Direction = ParameterDirection.Input;
                    param_n_codigo.Value = img_codigo;
                    command.Parameters.Add(param_n_codigo);

                    SqlParameter param_i_codigo = new SqlParameter("@SALDO", SqlDbType.Int);
                    param_i_codigo.Direction = ParameterDirection.Input;
                    param_i_codigo.Value = 0;
                    command.Parameters.Add(param_i_codigo);

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

        public static int Vincular(int id_usuario, int id_monedero)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    SqlCommand command = new SqlCommand("VincularMonedero", Conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter param_saldo = new SqlParameter("@ID_USUARIO", SqlDbType.Int);
                    param_saldo.Direction = ParameterDirection.Input;
                    param_saldo.Value = id_usuario;
                    command.Parameters.Add(param_saldo);

                    SqlParameter param_n_codigo = new SqlParameter("@ID_MONEDERO", SqlDbType.Int);
                    param_n_codigo.Direction = ParameterDirection.Input;
                    param_n_codigo.Value = id_monedero;
                    command.Parameters.Add(param_n_codigo);

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

        public static bool ActualizarSaldo(int id_monedero, int nuevo_saldo)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    SqlCommand command = new SqlCommand("ActualizarSaldo", Conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter param_mond = new SqlParameter("@ID_MONEDERO", SqlDbType.Int);
                    param_mond.Direction = ParameterDirection.Input;
                    param_mond.Value = id_monedero;
                    command.Parameters.Add(param_mond);

                    SqlParameter param_n_saldo = new SqlParameter("@NUEVO_SALDO", SqlDbType.Int);
                    param_n_saldo.Direction = ParameterDirection.Input;
                    param_n_saldo.Value = nuevo_saldo;
                    command.Parameters.Add(param_n_saldo);

                    command.ExecuteScalar();

                    Conexion.Close();

                    return true;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return false;
            }
        }
    }
}