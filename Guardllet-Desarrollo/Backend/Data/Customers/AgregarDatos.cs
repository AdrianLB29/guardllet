using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Guardllet_Desarrollo.Backend.Data.Customers
{
    public class AgregarDatos
    {
        public static int Generales(string nombre, string apellido_p, string apellido_m, string celular)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    SqlCommand command = new SqlCommand("RegistroDatosGenerales", Conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter param_nombre = new SqlParameter("@NOMBRES", SqlDbType.VarChar);
                    param_nombre.Direction = ParameterDirection.Input;
                    param_nombre.Value = nombre;
                    command.Parameters.Add(param_nombre);

                    SqlParameter param_apellidop = new SqlParameter("@APELLIDO_P", SqlDbType.VarChar);
                    param_apellidop.Direction = ParameterDirection.Input;
                    param_apellidop.Value = apellido_p;
                    command.Parameters.Add(param_apellidop);

                    SqlParameter param_apellidom = new SqlParameter("@APELLIDO_M", SqlDbType.VarChar);
                    param_apellidom.Direction = ParameterDirection.Input;
                    param_apellidom.Value = apellido_m;
                    command.Parameters.Add(param_apellidom);

                    SqlParameter param_boleta = new SqlParameter("@CELULAR", SqlDbType.VarChar);
                    param_boleta.Direction = ParameterDirection.Input;
                    param_boleta.Value = celular;
                    command.Parameters.Add(param_boleta);

                    SqlParameter param_foto = new SqlParameter("@FOTO", SqlDbType.VarChar);
                    param_foto.Direction = ParameterDirection.Input;
                    param_foto.Value = "asdfg";
                    command.Parameters.Add(param_foto);

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

        public static int Escolares(int id_escuela, string boleta, string grupo, string edad)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    SqlCommand command = new SqlCommand("RegistroDatosEscolares", Conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter param_escuela = new SqlParameter("@ID_ESCUELA", SqlDbType.Int);
                    param_escuela.Direction = ParameterDirection.Input;
                    param_escuela.Value = id_escuela;
                    command.Parameters.Add(param_escuela);

                    SqlParameter param_boleta = new SqlParameter("@BOLETA", SqlDbType.VarChar);
                    param_boleta.Direction = ParameterDirection.Input;
                    param_boleta.Value = boleta;
                    command.Parameters.Add(param_boleta);

                    SqlParameter param_grupo = new SqlParameter("@GRUPO", SqlDbType.VarChar);
                    param_grupo.Direction = ParameterDirection.Input;
                    param_grupo.Value = grupo;
                    command.Parameters.Add(param_grupo);

                    SqlParameter param_edad = new SqlParameter("@EDAD", SqlDbType.VarChar);
                    param_edad.Direction = ParameterDirection.Input;
                    param_edad.Value = edad;
                    command.Parameters.Add(param_edad);

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