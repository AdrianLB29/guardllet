using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guardllet_Desarrollo
{
    public partial class Servicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                }
                else
                {
                    Response.AppendHeader("Cache-Control", "no-store");
                    Response.Redirect("default.aspx");
                }

            } 
        }

        protected void BotonSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.AppendHeader("Cache-Control", "no-store");
            Response.AppendHeader("Pragma", "no-cache");
            Response.CacheControl = "no-cache"; Response.Expires = -1;
            Response.Redirect("default.aspx");
        }

        protected void BotonHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiDinero.aspx");
        }

        protected void BotonServicios_Click(object sender, EventArgs e)
        {
            Response.Redirect("Servicios.aspx");
        }

        protected void BotonPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }

        protected void BotonPagar_Click(object sender, EventArgs e)
        {
            string id = Session["usuario"].ToString();
            Session["articulo"] = "Examen";
            Response.Redirect("Carrito.aspx?" + id, false);
        }

        protected void BotonPagardos_Click(object sender, EventArgs e)
        {
            string id = Session["usuario"].ToString();
            Session["articulo"] = "Credencial";
            Response.Redirect("Carrito.aspx?" + id, false);
        }

        protected void BotonPagartres_Click(object sender, EventArgs e)
        {
            string id = Session["usuario"].ToString();
            Session["articulo"] = "Deuda";
            Response.Redirect("Carrito.aspx?" + id, false);
        }

        protected void BotonPagarcuatro_Click(object sender, EventArgs e)
        {
            string id = Session["usuario"].ToString();
            Session["articulo"] = "Papeleria";
            Response.Redirect("Carrito.aspx?" + id, false);
        }
    }
}