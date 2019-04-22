using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Guardllet_Desarrollo.Backend.Data.Customers;
using Guardllet_Desarrollo.Backend.Data.Wallet;

namespace Guardllet_Desarrollo.Frontend.Customers
{
    public partial class MiDinero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    string id = Session["usuario"].ToString();

                    int id_datos = ObtenerDatos.id_datos(Convert.ToInt16(id));
                    int id_datos_escolares = ObtenerDatos.id_datos_escolares(id_datos);
                    int id_monedero = ObtenerMonedero.id_monedero(Convert.ToInt16(id));

                    Dictionary<string, string> datos = ObtenerDatos.Generales(id_datos);
                    Dictionary<string, string> datos_escolares = ObtenerDatos.Escolares(id_datos_escolares);

                    int saldo = ObtenerMonedero.Saldo(id_monedero);

                    Lb_Nombre.Text = datos["Nombre"]+" "+datos["Apellido_p"]+" "+datos["Apellido_m"];
                    Lb_Escuela.Text = "CECyT 13 'Ricardo Flores Magon'";
                    Lb_Boleta.Text = datos_escolares["Boleta"];

                    Lb_Saldo.Text = "Saldo actual: "+ saldo.ToString();


                    Byte[] monedero = ObtenerMonedero.CodigoImg(id_monedero);

                    string ConvercionImg = "Data:image/jpg;base64," + Convert.ToBase64String(monedero);
                    Monedero.ImageUrl = ConvercionImg;

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
    }
}