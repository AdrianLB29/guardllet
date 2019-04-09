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
    public class Datos
    {
        public static Dictionary<int, Dictionary<string, string>> ObtenerEscuelas() 
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    string cmd = string.Format("SELECT * FROM ESCUELAS");
                    DataSet Datos = new DataSet();
                    SqlDataAdapter DP = new SqlDataAdapter(cmd, Conexion);
                    DP.Fill(Datos);
                    Conexion.Close();
                    try
                    {
                        int numero_escuelas = Datos.Tables[0].Rows.Count;
                        Dictionary<int, Dictionary<string, string>> Escuelas = new Dictionary<int, Dictionary<string, string>>();
                        for (int contador = 0; contador < numero_escuelas; contador++)
                        {
                            string id = Datos.Tables[0].Rows[contador]["ID_ESCUELA"].ToString();
                            string nombre = Datos.Tables[0].Rows[contador]["NOMBRE"].ToString();
                            Dictionary<string, string> Escuela = new Dictionary<string, string>();
                            Escuela.Add("Id", id);
                            Escuela.Add("Nombre", nombre);
                            Escuelas.Add(contador, Escuela);
                        }
                        return Escuelas;
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc);
                        Dictionary<int, Dictionary<string, string>> Escuelas = new Dictionary<int, Dictionary<string, string>>();
                        return Escuelas;
                    }
                }
            }
            catch (Exception exc) 
            {
                Console.WriteLine(exc);
                Dictionary<int, Dictionary<string, string>> Escuelas = new Dictionary<int, Dictionary<string, string>>();
                return Escuelas;
            }
        }

        public static int ObtenerID(string correo) 
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    string cmd = string.Format("SELECT ID_USUARIO FROM USUARIO WHERE CORREO ='{0}'", correo);
                    DataSet Datos = new DataSet();
                    SqlDataAdapter DP = new SqlDataAdapter(cmd, Conexion);
                    DP.Fill(Datos);
                    Conexion.Close();

                    int Id = Convert.ToInt32(Datos.Tables[0].Rows[0]["ID_USUARIO"].ToString());

                    return Id;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return 0;
            }     
        }

        public static int ObtenerTipoUsuario(int id_usuario) 
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    string cmd = string.Format("SELECT TIPO_USUARIO FROM USUARIO WHERE ID_USUARIO = {0}", id_usuario);
                    DataSet Datos = new DataSet();
                    SqlDataAdapter DP = new SqlDataAdapter(cmd, Conexion);
                    DP.Fill(Datos);
                    Conexion.Close();

                    int Id = Convert.ToInt32(Datos.Tables[0].Rows[0]["TIPO_USUARIO"].ToString());

                    return Id;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return 0;
            }     
        }

        public static int ObtenerEstadoUsuario(int id_usuario)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    string cmd = string.Format("SELECT ESTADO FROM USUARIO WHERE ID_USUARIO = {0}", id_usuario);
                    DataSet Datos = new DataSet();
                    SqlDataAdapter DP = new SqlDataAdapter(cmd, Conexion);
                    DP.Fill(Datos);
                    Conexion.Close();

                    int Id = Convert.ToInt32(Datos.Tables[0].Rows[0]["ESTADO"].ToString());

                    return Id;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return 0;
            }
        }

        public static int VincularDatosGenerales(int id_usuario, int id_datos_generales)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    SqlCommand command = new SqlCommand("VincularDatosUsuario", Conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter param_id_usuario = new SqlParameter("@ID_USUARIO", SqlDbType.Int);
                    param_id_usuario.Direction = ParameterDirection.Input;
                    param_id_usuario.Value = id_usuario;
                    command.Parameters.Add(param_id_usuario);

                    SqlParameter param_id_datos = new SqlParameter("@ID_DATOS_GENERALES", SqlDbType.Int);
                    param_id_datos.Direction = ParameterDirection.Input;
                    param_id_datos.Value = id_datos_generales;
                    command.Parameters.Add(param_id_datos);

                    SqlParameter param_estado = new SqlParameter("@ESTADO", SqlDbType.Int);
                    param_estado.Direction = ParameterDirection.Input;
                    param_estado.Value = 2;
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

        public static int VincularDatosEscolares(int datos_generales, int datos_escolares)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    SqlCommand command = new SqlCommand("VincularDatosEscolares", Conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter param_id_usuario = new SqlParameter("@ID_DATOS_GENERALES", SqlDbType.Int);
                    param_id_usuario.Direction = ParameterDirection.Input;
                    param_id_usuario.Value = datos_generales;
                    command.Parameters.Add(param_id_usuario);

                    SqlParameter param_id_datos = new SqlParameter("@ID_DATOS_ESCOLARES", SqlDbType.Int);
                    param_id_datos.Direction = ParameterDirection.Input;
                    param_id_datos.Value = datos_escolares;
                    command.Parameters.Add(param_id_datos);

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