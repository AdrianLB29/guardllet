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
            int s,sa,st = 0;

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

                    tbsaldo.Text = "";
                    lSaldo.Text = "";
                    tbNoMenedero.Text = "";
                }
                catch(Exception es)
                {

                }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection Conexion = new SqlConnection(StringConexion))
            try  {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT  ID_MONEDERO, SALDO FROM MONEDERO where CODIGO = '" + tbNoMenedero.Text + "'", Conexion);
                SqlDataReader leer = cmd.ExecuteReader();
                if (leer.Read() == true)
                {

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
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.AppendHeader("Cache-Control", "no-store");
            Response.Redirect("default.aspx");
        }
    }
}
  