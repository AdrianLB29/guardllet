using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Guardllet_Desarrollo.Backend.Data.Movements
{
    public class MovimientoCV
    {
        public static int Registrar(int id_producto, int id_monedero, int estado, int numero_autorizacion) 
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    SqlCommand command = new SqlCommand("RegistroMovimientoCV", Conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter param_prod = new SqlParameter("@ID_PRODUCTO", SqlDbType.Int);
                    param_prod.Direction = ParameterDirection.Input;
                    param_prod.Value = id_producto;
                    command.Parameters.Add(param_prod);

                    SqlParameter param_mond = new SqlParameter("@ID_MONEDERO", SqlDbType.Int);
                    param_mond.Direction = ParameterDirection.Input;
                    param_mond.Value = id_monedero;
                    command.Parameters.Add(param_mond);

                    SqlParameter param_estado = new SqlParameter("@ESTADO", SqlDbType.Int);
                    param_estado.Direction = ParameterDirection.Input;
                    param_estado.Value = estado;
                    command.Parameters.Add(param_estado);

                    DateTime fecha = System.DateTime.Now; 

                    SqlParameter param_fecha = new SqlParameter("@FECHA", SqlDbType.DateTime);
                    param_fecha.Direction = ParameterDirection.Input;
                    param_fecha.Value = fecha;
                    command.Parameters.Add(param_fecha);

                    SqlParameter param_num = new SqlParameter("@NUMERO_AUTORIZACION", SqlDbType.Int);
                    param_num.Direction = ParameterDirection.Input;
                    param_num.Value = numero_autorizacion;
                    command.Parameters.Add(param_num);

                    SqlParameter param_mensj = new SqlParameter("@MENSAJE", SqlDbType.VarChar);
                    param_mensj.Direction = ParameterDirection.Input;
                    param_mensj.Value = "Correcto";
                    command.Parameters.Add(param_mensj);

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