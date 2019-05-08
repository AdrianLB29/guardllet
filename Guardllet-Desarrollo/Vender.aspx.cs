using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Guardllet_Desarrollo;

namespace Guardllet_Desarrollo.Frontend.Sellers
{
    public partial class Vender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    Usuario.Text = Session["usuario"].ToString();
                }
                else
                {
                    Response.AppendHeader("Cache-Control", "no-store");
                    Response.Redirect("default.aspx");
                }
            }

            int usuario = Convert.ToInt16(Session["usuario"]);

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int s, sa, st = 0;

            sa = Convert.ToInt16(lSaldo.Text);
            s = Convert.ToInt16(tbsaldo.Text);
            st = sa + s;
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection Conexion = new SqlConnection(StringConexion))
                try
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE MONEDERO Set SALDO = " + st + " where CODIGO = '" + tbNoMenedero.Text + "'", Conexion);
                    cmd.ExecuteNonQuery();


                    Convert.ToInt16(lFinal.Text);
                    SqlCommand cmd1 = new SqlCommand("insert into MOVIMIENTO_R  (ID_ADMINISTRADOR,ID_MONEDERO,MONTO) VALUES (" + Usuario.Text + "," + lFinal.Text + "," + s +")" , Conexion);
                    cmd1.ExecuteNonQuery();

                    Conexion.Close();
                    tbsaldo.Text = "";
                    lSaldo.Text = "";
                    tbNoMenedero.Text = "";
                }
                catch(Exception es)
                {

                }

            string script = @"<script type='text/javascript'>
                            alert('La recarga se realizo correctamente');
                            </script>";

            if (!Page.IsClientScriptBlockRegistered("alerta"))
                Page.RegisterStartupScript("alerta", script);   

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lFinal.Text = "";
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection Conexion = new SqlConnection(StringConexion))
            try  {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT  ID_MONEDERO, SALDO FROM MONEDERO where CODIGO = '" + tbNoMenedero.Text + "'", Conexion);
                SqlDataReader leer = cmd.ExecuteReader();
                    if (leer.Read() == true)
                    {
                    lFinal.Text = leer["ID_MONEDERO"].ToString();
                    lSaldo.Text = leer["SALDO"].ToString();
                }
                else
                {

                }

                Conexion.Close();
            }
                catch(Exception es)
                {

                }
        }

        protected void btnCerar_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.AppendHeader("Cache-Control", "no-store");
            Response.AppendHeader("Pragma", "no-cache");
            Response.CacheControl = "no-cache"; Response.Expires = -1;
            Response.Redirect("default.aspx");
        }
    }
}
  