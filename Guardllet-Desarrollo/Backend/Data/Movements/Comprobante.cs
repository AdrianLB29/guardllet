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
    public class Comprobante
    {
        public static int Crear(int id_monedero, string nombre, int numero_autorizacion, int precio, string materia, int tipo)
        {
            DateTime fecha = System.DateTime.Now;

            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            try
            {
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                {
                    Conexion.Open();
                    SqlCommand command = new SqlCommand("RegistroComprobante", Conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter param_id = new SqlParameter("@ID_MONEDERO ", SqlDbType.Int);
                    param_id.Direction = ParameterDirection.Input;
                    param_id.Value = id_monedero;
                    command.Parameters.Add(param_id);

                    SqlParameter param_prod = new SqlParameter("@FECHA", SqlDbType.DateTime);
                    param_prod.Direction = ParameterDirection.Input;
                    param_prod.Value = fecha;
                    command.Parameters.Add(param_prod);

                    SqlParameter param_mond = new SqlParameter("@NOMBRE_ARTICULO", SqlDbType.VarChar);
                    param_mond.Direction = ParameterDirection.Input;
                    param_mond.Value = nombre;
                    command.Parameters.Add(param_mond);

                    SqlParameter param_estado = new SqlParameter("@NUMERO_AUTORIZACION", SqlDbType.Int);
                    param_estado.Direction = ParameterDirection.Input;
                    param_estado.Value = numero_autorizacion;
                    command.Parameters.Add(param_estado);

                    SqlParameter param_fecha = new SqlParameter("@PRECIO", SqlDbType.Int);
                    param_fecha.Direction = ParameterDirection.Input;
                    param_fecha.Value = precio;
                    command.Parameters.Add(param_fecha);

                    SqlParameter param_num = new SqlParameter("@MATERIAS", SqlDbType.VarChar);
                    param_num.Direction = ParameterDirection.Input;
                    param_num.Value = materia;
                    command.Parameters.Add(param_num);

                    SqlParameter param_mensj = new SqlParameter("@TIPO", SqlDbType.Int);
                    param_mensj.Direction = ParameterDirection.Input;
                    param_mensj.Value = tipo;
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

        public static Dictionary<string, Dictionary<string, string>> Obtener(int id_monedero)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            using (SqlConnection Conexion = new SqlConnection(StringConexion))
            {

                Conexion.Open();
                string cmd = string.Format("SELECT * FROM COMPROBANTE Where ID_MONEDERO = {0}", id_monedero);
                DataSet Datos = new DataSet();
                SqlDataAdapter DP = new SqlDataAdapter(cmd, Conexion);
                DP.Fill(Datos);
                Conexion.Close();
                int numero_tickets = Datos.Tables[0].Rows.Count;

                try
                {
                    Dictionary<string, Dictionary<string, string>> Tickets = new Dictionary<string, Dictionary<string, string>>();

                    for (int contador = 0; contador < numero_tickets; contador++)
                    {
                        Dictionary<string, string> Ticket = new Dictionary<string, string>();

                        string fecha = Datos.Tables[0].Rows[contador]["FECHA"].ToString();
                        string nombre = Datos.Tables[0].Rows[contador]["NOMBRE_ARTICULO"].ToString();
                        string numero = Datos.Tables[0].Rows[contador]["NUMERO_AUTORIZACION"].ToString();
                        string precio = Datos.Tables[0].Rows[contador]["PRECIO"].ToString();
                        string materia = Datos.Tables[0].Rows[contador]["MATERIAS"].ToString();
                        string tipo = Datos.Tables[0].Rows[contador]["TIPO"].ToString();

                        Ticket.Add("Nombre", nombre);
                        Ticket.Add("Fecha", fecha);
                        Ticket.Add("Numero", numero);
                        Ticket.Add("Precio", precio);
                        Ticket.Add("Materia", materia);
                        Ticket.Add("Tipo", tipo);

                        Tickets.Add(string.Format("{0} Ticket", contador), Ticket);
                    }
                   
                    return Tickets;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                    Dictionary<string, Dictionary<string, string>> Tickets = new Dictionary<string, Dictionary<string, string>>();
                    return Tickets;
                }
            }
        }
    }
}