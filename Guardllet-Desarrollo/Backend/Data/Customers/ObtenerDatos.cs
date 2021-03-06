﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Guardllet_Desarrollo.Backend.Data.Customers
{
    public class ObtenerDatos
    {
        public static int id_datos(int id_usuario) 
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            using (SqlConnection Conexion = new SqlConnection(StringConexion))
            {
                Conexion.Open();
                string cmd = string.Format("SELECT ID_DATOS_GENERALES FROM USUARIO Where ID_USUARIO = {0}", id_usuario);
                DataSet Datos = new DataSet();
                SqlDataAdapter DP = new SqlDataAdapter(cmd, Conexion);
                DP.Fill(Datos);
                Conexion.Close();

                int id = Convert.ToInt16(Datos.Tables[0].Rows[0]["ID_DATOS_GENERALES"].ToString());

                return id;
            }
        }

        public static int id_datos_escolares(int id_datos)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            using (SqlConnection Conexion = new SqlConnection(StringConexion))
            {
                Conexion.Open();
                string cmd = string.Format("SELECT ID_DATOS_ESCOLARES FROM DATOS_GENERALES Where ID_DATOS_GENERALES = {0}", id_datos);
                DataSet Datos = new DataSet();
                SqlDataAdapter DP = new SqlDataAdapter(cmd, Conexion);
                DP.Fill(Datos);
                Conexion.Close();

                int id = Convert.ToInt16(Datos.Tables[0].Rows[0]["ID_DATOS_ESCOLARES"].ToString());

                return id;
            }
        }

        public static Dictionary<string, string> Generales (int id_datos) 
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            using (SqlConnection Conexion = new SqlConnection(StringConexion))
            {

                Conexion.Open();
                string cmd = string.Format("SELECT * FROM DATOS_GENERALES Where ID_DATOS_GENERALES = {0}", id_datos);
                DataSet Datos = new DataSet();
                SqlDataAdapter DP = new SqlDataAdapter(cmd, Conexion);
                DP.Fill(Datos);
                Conexion.Close();

                try
                {
                    string nombre = Datos.Tables[0].Rows[0]["NOMBRES"].ToString();
                    string apellido_p = Datos.Tables[0].Rows[0]["APELLIDO_P"].ToString();
                    string apellido_m = Datos.Tables[0].Rows[0]["APELLIDO_M"].ToString();
                    string celular = Datos.Tables[0].Rows[0]["CELULAR"].ToString();

                    Dictionary<string, string> Usuario = new Dictionary<string, string>();

                    Usuario.Add("Nombre", nombre);
                    Usuario.Add("Apellido_p", apellido_p);
                    Usuario.Add("Apellido_m", apellido_m);
                    Usuario.Add("Celular", celular);

                    return Usuario;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                    Dictionary<string, string> Usuario = new Dictionary<string, string>();
                    Usuario.Add("Resultado", exc.ToString());
                    return Usuario;
                }
            }
        }

        public static Dictionary<string, string> Escolares(int id_datos)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            using (SqlConnection Conexion = new SqlConnection(StringConexion))
            {

                Conexion.Open();
                string cmd = string.Format("SELECT * FROM DATOS_ESCOLARES Where ID_DATOS_ESCOLARES = {0}", id_datos);
                DataSet Datos = new DataSet();
                SqlDataAdapter DP = new SqlDataAdapter(cmd, Conexion);
                DP.Fill(Datos);
                Conexion.Close();

                try
                {
                    string boleta = Datos.Tables[0].Rows[0]["BOLETA"].ToString();
                    string grupo = Datos.Tables[0].Rows[0]["GRUPO"].ToString();
                    string edad = Datos.Tables[0].Rows[0]["EDAD"].ToString();

                    Dictionary<string, string> Usuario = new Dictionary<string, string>();

                    Usuario.Add("Boleta", boleta);
                    Usuario.Add("Grupo", grupo);
                    Usuario.Add("Edad", edad);

                    return Usuario;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                    Dictionary<string, string> Usuario = new Dictionary<string, string>();
                    Usuario.Add("Resultado", exc.ToString());
                    return Usuario;
                }
            }
        }
    }
}