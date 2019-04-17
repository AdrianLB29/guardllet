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
    public class ObtenerMonedero
    {

        public static int id_monedero(int id_usuario) 
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            using (SqlConnection Conexion = new SqlConnection(StringConexion))
            {
                Conexion.Open();
                string cmd = string.Format("SELECT ID_MONEDERO FROM USUARIO Where ID_USUARIO = {0}", id_usuario);
                DataSet Datos = new DataSet();
                SqlDataAdapter DP = new SqlDataAdapter(cmd, Conexion);
                DP.Fill(Datos);
                Conexion.Close();

                int id = Convert.ToInt16(Datos.Tables[0].Rows[0]["ID_MONEDERO"].ToString());

                return id;
            }
        }

        public static Byte[] CodigoImg(int id_monedero)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            using (SqlConnection Conexion = new SqlConnection(StringConexion))
            {

                Conexion.Open();
                string cmd = string.Format("SELECT IMAGEN_CODIGO FROM MONEDERO Where ID_MONEDERO = {0}", id_monedero);
                DataSet Datos = new DataSet();
                SqlDataAdapter DP = new SqlDataAdapter(cmd, Conexion);
                DP.Fill(Datos);
                Conexion.Close();

                try
                {
                    Byte[] bytes = new Byte[0];
                    bytes = (Byte[])Datos.Tables[0].Rows[0]["IMAGEN_CODIGO"];

                    return bytes;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                    Byte[] bytes = new Byte[0];
                    return bytes;
                }
            }
        }

        public static int Saldo(int id_monedero) 
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            using (SqlConnection Conexion = new SqlConnection(StringConexion))
            {

                Conexion.Open();
                string cmd = string.Format("SELECT SALDO FROM MONEDERO Where ID_MONEDERO = {0}", id_monedero);
                DataSet Datos = new DataSet();
                SqlDataAdapter DP = new SqlDataAdapter(cmd, Conexion);
                DP.Fill(Datos);
                Conexion.Close();

                int saldo = Convert.ToInt16(Datos.Tables[0].Rows[0]["SALDO"]);

                return saldo;
            }
        }
    }
}